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

namespace FarmAutomatorServer.Controllers
{
    [Authorize]
    public class ActionController : BaseController
    {
        public ActionResult UploadTask(TaskModel model)
        {
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                return null;
            }
        }

        public ActionResult UploadFeed(FeedModel model)
        {
            return Json("OK");
        }
    }
}
