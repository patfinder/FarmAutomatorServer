using FarmAutomatorServer.Models;
using log4net;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;
using AttributeRouting.Web.Mvc;
using Dapper;
using FarmAutomatorServer.Utils;
using FarmAutomatorServer.Constants;
using System.IO;

namespace FarmAutomatorServer.Controllers
{
    [Authorize]
    public class ActionController : BaseController
    {
        public ActionResult UploadTask(ActionModel model)
        {
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                var result = conn.Execute("INSERT INTO ACTION_TABLE(BIG_CODE, MEDIUM_CODE, USER_NO, TIME, QUANTITY) VALUES(:BIG_CODE, :MEDIUM_CODE, :USER_NO, :TIME, :QUANTITY)",
                    new {
                        BIG_CODE = model.CattleId,
                        MEDIUM_CODE = model.FeedId,
                        USER_NO = model.UserId,
                        TIME = DateTime.Now,
                        QUANTITY = model.Quanity,
                    });

                if(result > 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK, "Upload successfully.");
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Upload unsuccessfully.");
            }
        }

        public ActionResult UploadFeed(ActionCageModel model)
        {
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                // Find action
                var action = conn.Query<ActionModel>("SELECT * FROM ACTION_TABLE WHERE ID_ACTION = :ID_ACTION", new { ID_ACTION = model.ActionId }).SingleOrDefault();

                if(action == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Action not found");
                }

                // Collecting pics
                var pictures = Enumerable.Range(0, SystemConstants.MaxScanPictureCount).Select(i => (string)null).ToArray();

                // Save to picture store
                for (int i = 0; i < Math.Min(Request.Files.Count, SystemConstants.MaxScanPictureCount); i++)
                {
                    pictures[i] = $"ACT-{model.ActionId}";
                    Request.Files[i].SaveAs(Path.Combine(FileUtils.GetPictureStorePath(action.ActionTime), pictures[i]));
                }

                var result = conn.Execute("INSERT INTO SCAN_TABLE(ID_SCAN, ID_ACTION, QUANTITY, PIC1, PIC2, PIC3) VALUES(:ID_SCAN, :ID_ACTION, :QUANTITY, :PIC1, :PIC2, :PIC3)",
                    new
                    {
                        ID_SCAN = model.Id,
                        ID_ACTION = model.ActionId,
                        QUANTITY = model.Quanity,
                        PIC1 = pictures[0],
                        PIC2 = pictures[1],
                        PIC3 = pictures[2],
                    });

                if (result > 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK, "Upload successfully.");
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Upload unsuccessfully.");
            }
        }
    }
}
