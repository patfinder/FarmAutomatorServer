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

            return Json(new { UserName = "User1", Role = "Manager" });
        }

        public ActionResult Test1()
        {
            return Json(new { Name = 1, Age = 100 });
        }

        //[Route("Auth/Test2")]
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

    public class UserModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string FULLNAME { get; set; }
        public string CMND { get; set; }
        public string DATE_PLACE_CMND { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESS_CONTACT { get; set; }
        public string HOME_PHONE { get; set; }
        public string MOBILE_PHONE { get; set; }
        public string HOME_PHONE_CONTACT { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public int GENDER { get; set; }
        public string HEIGHT { get; set; }
        public string WEIGHT { get; set; }
        public int MIRITAL { get; set; }
        public string MIRITAL_OTHER { get; set; }
        public DateTime DOB { get; set; }
        public string POB { get; set; }
        public string IMAGE { get; set; }
        public string RELATE_EXP { get; set; }
        public string CONTACT_LEADER { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string TOKEN { get; set; }
        public int STATUS { get; set; }
        public DateTime MODIFIED { get; set; }
        public DateTime CREATED { get; set; }
    }
}
