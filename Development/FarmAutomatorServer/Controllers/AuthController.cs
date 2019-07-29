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

namespace FarmAutomatorServer.Controllers
{
    [System.Web.Http.Authorize]
    public class AuthController : Controller
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

        //[POST("Auth")]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            var identity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, "sale_ename"),
                    new Claim(ClaimTypes.NameIdentifier, "sale_no"),
                    new Claim(ClaimTypes.Role, "role"),
                }, "auth-cookie");

            Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = false, // input.RememberMe
            }, identity);

            //return Json(new { ResultCode = 0, UserName = "User1", Role = "Manager" }, "application/json");
            return Json(new { ResultCode = 0, UserName = "User1", Role = "User" });
        }

        [System.Web.Http.HttpGet]
        [AllowAnonymous]
        public string Test1()
        {
            //return Json(new { Name = 1, Age = 100 });
            return "Ok";
        }

        //[Route("Auth/Test2")]
        [System.Web.Http.HttpGet]
        [AllowAnonymous]
        public ActionResult Test2()
        {
            // Connect to Oracle
            string constr = "User Id=mbs_db;Password=123456;Data Source=OracleDataSource";
            var conn = new OracleConnection(constr);
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
