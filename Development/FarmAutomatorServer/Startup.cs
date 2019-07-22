using VisitMeServer.API.Providers;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using FarmAutomatorServer.Utils;

//using WebGrease;

[assembly: OwinStartup(typeof(FarmAutomatorServer.Startup))]
namespace FarmAutomatorServer
{
    public class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Startup));

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions GoogleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            XmlConfigurator.Configure();

            Log.Info("Startup.Configuration called.");

            var config = new HttpConfiguration();

            //HttpRouteCollection routeColl = new HttpRouteCollection();
            //var rootbase = RouteTable.Routes.First();

            // Hangfire init
            //Hangfire.SqlServerStorageExtensions.UseSqlServerStorage(Hangfire.GlobalConfiguration.Configuration,
            //    "AuthContext", new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });
            //Hangfire.AppBuilderExtensions.UseHangfireDashboard(app);
            //Hangfire.AppBuilderExtensions.UseHangfireServer(app);

            //ConfigureOAuth(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                // LoginPath = new PathString("/Home/Login")
                ExpireTimeSpan = new TimeSpan(0, 0, AppSettings.AuthenticationTokenMinutes, 0),
                SlidingExpiration = true
            });

            //WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, VisitMeServer.API.Migrations.Configuration>());

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(AppSettings.AuthenicationTokenHours),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }

}