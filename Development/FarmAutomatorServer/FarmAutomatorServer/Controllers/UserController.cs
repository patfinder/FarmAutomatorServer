using FarmAutomatorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FarmAutomatorServer.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(LoginModel loginModel)
        {
            const string userEmail = "testemail";

            if(loginModel.Email != userEmail)
            {
                return new HttpNotFoundResult();
            }

            var user = new UserModel {
                UserName = "Found user"
            };

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, userEmail),
                new Claim(ClaimTypes.Role, "role"),
                // can add more claims
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignIn(new AuthenticationProperties
            { IsPersistent = loginModel.RememberMe }, identity);
        }
    }
}
