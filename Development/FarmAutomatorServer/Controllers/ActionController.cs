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
            using (var conn = DbUtils.Connection)
            {
                var result = conn.Execute(DbUtils._T("INSERT INTO ACTION_TABLE(BIG_CODE, MEDIUM_CODE, USER_NO, TIME, QUANTITY) VALUES(#BIG_CODE, #MEDIUM_CODE, #USER_NO, #TIME, #QUANTITY)"),
                    new {
                        BIG_CODE = model.CattleId,
                        MEDIUM_CODE = model.FeedId, // TODO: FeedType?
                        QUANTITY = model.Quanity,
                        USER_NO = User.Identity.Name,
                        TIME = model.ActionTime,
                    });

                if(result > 0)
                {
                    return Json(new ApiResult
                    {
                        ResultCode = ResultCode.Success,
                        Messages = new[] { "UploadTask successfully" },
                    }, JsonRequestBehavior.AllowGet);
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Upload unsuccessfully.");
            }
        }

        public ActionResult UploadCage(ActionCageModel model)
        {
            using (var conn = DbUtils.Connection)
            {
                // Find action
                //var action = conn.Query<ActionModel>(DbUtils._T("SELECT * FROM ACTION_TABLE WHERE ID_ACTION = #ID_ACTION"), new { ID_ACTION = model.ActionId }).SingleOrDefault();
                var action = conn.Query<ActionModel>(DbUtils._T("SELECT * FROM ACTION_TABLE"), new { ID_ACTION = model.ActionId }).FirstOrDefault();

                if (action == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Action not found");
                }

                // TODO: TEST
                model.ActionId = new Random().Next().ToString();

                // nonpic fields
                //var nonPicsFiedls = [nameof(model.ActionId)]

                // Collecting pics
                var pictures = Enumerable.Range(0, SystemConstants.MaxScanPictureCount).Select(i => (string)null).ToArray();

                //Request.Files[i].SaveAs(Path.Combine(FileUtils.GetPictureStorePath(action.ActionTime), pictures[i]));
                var fileNames = Request.Form.AllKeys.Where(k => k.StartsWith("Picture-")).ToList();

                var picFolder = FileUtils.GetPictureStorePath(action.ActionTime);
                if (!Directory.Exists(picFolder)) Directory.CreateDirectory(picFolder);

                for (int i = 0; i < Math.Min(fileNames.Count, SystemConstants.MaxScanPictureCount); i++)
                {
                    pictures[i] = $"APIC-{model.ActionId}-{(i+1):D02}.jpg";
                    var path = Path.Combine(picFolder, pictures[i]);
                    
                    // Save to picture store
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(Convert.FromBase64String(Request.Form[fileNames[i]]));
                    }
                }

                var result = conn.Execute(DbUtils._T("INSERT INTO SCAN_TABLE(ID_SCAN, ID_ACTION, QUANTITY, PIC1, PIC2, PIC3) VALUES(#ID_SCAN, #ID_ACTION, #QUANTITY, #PIC1, #PIC2, #PIC3)"),
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
                    return Json(new ApiResult
                    {
                        ResultCode = ResultCode.Success,
                        Messages = new[] { "UploadCage successfully" },
                    }, JsonRequestBehavior.AllowGet);
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Upload unsuccessfully.");
            }
        }
    }
}
