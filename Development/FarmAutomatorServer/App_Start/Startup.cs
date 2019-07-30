using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(FarmAutomatorServer.Startup))]

namespace FarmAutomatorServer
{
    public class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Startup));

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            XmlConfigurator.Configure();

            Log.Info("Startup.Configuration called.");

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "auth-cookie", // DefaultAuthenticationTypes.ApplicationCookie
                LoginPath = new PathString("/auth/login"),
                ExpireTimeSpan = new TimeSpan(0, 0, 15, 0), // 0, 0, AppSettings.AuthenticationTokenMinutes, 0
                SlidingExpiration = true
            });

            var config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Other configurations

            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
