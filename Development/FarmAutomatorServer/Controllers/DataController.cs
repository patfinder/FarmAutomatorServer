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
using Dapper;
using FarmAutomatorServer.Utils;
using SalesManagement.Controllers;
using FarmAutomatorServer.Constants;

namespace FarmAutomatorServer.Controllers
{
    [Authorize, ActionLog, ExceptionLog]
    public class DataController : BaseController
    {
        public ActionResult ActionData() // DateTime lastUpdate = default(DateTime)
        {
            // TODO: Check update
            //if not update
            //return HttpStatusCodeResult();

            // Connect to Oracle
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                var cattles = conn.Query<CattleModel>("SELECT BIG_CODE Id, BIG_NAME Name FROM BIG_KIND").ToList();
                var feeds = conn.Query<FeedModel>("SELECT MEDIUM_CODE Id, MEDIUM_NAME Name FROM MEDIUM_KIND").ToList();
                var feedTypes = Enum.GetValues(typeof(FeedType)).Cast<FeedType>().ToArray();

                var actionData = new
                {
                    LastUpdate = DateTime.Now,
                    Cattles = cattles,
                    FeedTypes = feedTypes,
                    Feeds = feeds,
                };

                return Json(new ApiResult
                {
                    Data = actionData
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
