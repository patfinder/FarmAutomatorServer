﻿using FarmAutomatorServer.Models;
using log4net;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using Oracle.ManagedDataAccess.Client;
using AttributeRouting.Web.Mvc;
//using AttributeRouting.Web.Mvc;
using Dapper;

namespace FarmAutomatorServer.Controllers
{
    [System.Web.Http.Authorize]
    public class ActionController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthController));

        public ActionResult UploadTask(TaskModel model)
        {
            return Json("OK");
        }
    }
}
