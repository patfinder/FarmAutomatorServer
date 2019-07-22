using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using Dapper;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
//using Oracle.ManagedDataAccess.Client;
using FarmAutomatorServer.Entities;
using FarmAutomatorServer.Models;
using FarmAutomatorServer.Utils;
using VisitMeServer.Admin.Models;
using VisitMeServer.API.Models;
using VisitMeServer.Models;
using WebGrease.Css.Extensions;

namespace FarmAutomatorServer.Controllers
{
    [LogActionFilter]
    [Authorize]
    //[ExceptionLogFilter]
    public class AuthController : Controller // SalesController // Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController__));

        Dictionary<PeriodType, string> Periods = new Dictionary<PeriodType, string>
        {
            {PeriodType.Daily, "month"},
            {PeriodType.Weekly, "week"},
            {PeriodType.Monthly, "month"},
            {PeriodType.Quarterly, "quarter"},
            {PeriodType.Yearly, "year"},
        };

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
            => _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());

        public ApplicationUserManager UserManager
            => _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            var identity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, "sale_ename"),
                    new Claim(ClaimTypes.NameIdentifier, "sale_no"),
                    new Claim(ClaimTypes.Role, "role"),
                }, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(identity);

            return Json(new { UserName = "User1", Role = "Manager" });
        }
    }
}
