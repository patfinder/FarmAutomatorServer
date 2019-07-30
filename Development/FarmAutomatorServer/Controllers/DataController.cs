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

namespace FarmAutomatorServer.Controllers
{
    [Authorize, ActionLog, ExceptionLog]
    public class DataController : BaseController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthController));

        public ActionResult ActionData(DateTime lastUpdate = default(DateTime))
        {
            // TODO: Check update
            //if not update
            //return HttpStatusCodeResult();

            // Connect to Oracle
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                conn.Open();

                // Cattle cases
                var cattles = conn.Query<CattleModel>("SELECT * FROM BIG_KIND").ToList();
                var tasks = conn.Query<TaskModel>("SELECT * FROM BIG_KIND").ToList();
                var feeds = conn.Query<FeedModel>("SELECT * FROM Task").ToList();

                return Json(new
                {
                    LastUpdate = DateTime.Now,
                    Cattles = cattles,
                    Tasks = tasks,
                    Feeds = feeds,
                });
            }
        }
    }
}
