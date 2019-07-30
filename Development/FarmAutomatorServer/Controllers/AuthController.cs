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
//using AttributeRouting.Web.Mvc;
using Dapper;
using FarmAutomatorServer.Utils;
using FarmAutomatorServer.Constants;

namespace FarmAutomatorServer.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthController));

        //ApplicationSignInManager _signInManager;
        //public ApplicationSignInManager SignInManager
        //    => _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());

        //private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

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
                conn.Open();

                var params_ = new
                {
                    userName = model.Email,
                    model.Password,
                };

                var command = new CommandDefinition(
                    //"SELECT * FROM USER_TABLE WHERE USER_NAME = @userName AND PASSWORD = @password",
                    "SELECT USER_NO ID, USER_VNAME NAME FROM USER_TABLE WHERE USER_NAME = 'User 1' AND PASSWORD = 'password'",
                    params_
                );

                // Cattle cases
                var user = conn.Query<UserModel>(command).SingleOrDefault();

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

                return Json(new ApiResult {
                    Data = user
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
        public ActionResult CheckAnonymous()
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Anonymous User");
        }

        //[Route("Auth/TestDbAccess")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult TestDbAccess()
        {
            // Connect to Oracle
            string constr = "User Id=mbs_db;Password=123456;Data Source=OracleDataSource";
            using (var conn = new OracleConnection(constr))
            {
                conn.Open();

                // Display Version Number
                Console.WriteLine("Connected to Oracle " + conn.ServerVersion);

                var users = conn.Query<UserModel>("SELECT * FROM ADMIN_WZ_USERS").Take(3);

                // Close and Dispose OracleConnection
                conn.Close();
                conn.Dispose();

                return Json(users);
            }
        }
    }
}
