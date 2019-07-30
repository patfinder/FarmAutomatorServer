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
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using Oracle.ManagedDataAccess.Client;
using AttributeRouting.Web.Mvc;
//using AttributeRouting.Web.Mvc;
using Dapper;
using FarmAutomatorServer.Utils;

namespace FarmAutomatorServer.Controllers
{
    [System.Web.Http.Authorize]
    public class ActionController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthController));

        public ActionResult UploadTask(TaskModel model)
        {
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                conn.Open();

                //var command = new CommandDefinition(
                //    "INSERT INTO ACTION_TABLE(a,b,c) VALUES"
                //    //params_
                //);

                //// Cattle cases
                //var user = conn.Query<UserModel>(command).SingleOrDefault();

                //if (user == null)
                //{
                //    return new HttpNotFoundResult("Invalid name or password");
                //}

                //var identity = new ClaimsIdentity(new[]{
                //    new Claim(ClaimTypes.Name, user.Name),
                //    new Claim(ClaimTypes.NameIdentifier, user.Id),
                //    new Claim(ClaimTypes.Role, user.Role.ToString()),
                //}, SystemConstants.AuthenticationCookie);

                //Authentication.SignIn(new AuthenticationProperties
                //{
                //    IsPersistent = true, // input.RememberMe
                //}, identity);

                return Json(new ApiResult
                {
                    Data = null
                });
            }
        }

        public ActionResult UploadFeed(FeedModel model)
        {
            return Json("OK");
        }
    }
}
