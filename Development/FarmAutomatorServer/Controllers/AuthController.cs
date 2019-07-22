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
//using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Controllers
{
    [Authorize]
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

        [Route("Auth/Login")]
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
    }
}