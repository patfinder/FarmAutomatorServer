using System;
using System.Web;

namespace FarmAutomatorServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;
            context.Response.SuppressFormsAuthenticationRedirect = true;
        }

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    HttpApplication context = (HttpApplication)sender;
        //    context.Response.SuppressFormsAuthenticationRedirect = true;
        //}
    }
}
