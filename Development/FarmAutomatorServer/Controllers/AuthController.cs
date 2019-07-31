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
using FarmAutomatorServer.Constants;
using SalesManagement.Controllers;

namespace FarmAutomatorServer.Controllers
{
    [Authorize, ActionLog, ExceptionLog]
    public class AuthController : BaseController // BaseController Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            using (var conn = new OracleConnection(DbUtils.ConnectionString))
            {
                var command = new CommandDefinition(
                    "SELECT USER_NO ID, USER_VNAME NAME FROM USER_TABLE WHERE USER_NAME = :userName AND PASSWORD = :Password",
                    model
                );

                var user = conn.Query<UserModel>(command).FirstOrDefault();

                if (user == null)
                {
                    return new HttpNotFoundResult("Invalid name or password");
                }

                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }, SystemConstants.AuthenticationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true, // input.RememberMe
                }, identity);

                return Json(new ApiResult
                {
                    Data = new {
                        user.Id,
                        user.Name,
                        user.Role,
                    }
                });
            }
        }

        /// <summary>
        /// This API is for checking current user session token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CheckLogin()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Login Ok");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CheckAnonymous()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Anonymous User");
        }
    }
}
