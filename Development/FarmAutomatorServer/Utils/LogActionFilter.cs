using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Newtonsoft.Json;
using FarmAutomatorServer.Controllers;

namespace FarmAutomatorServer.Utils
{
    public class LogActionFilter : ActionFilterAttribute

    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogActionFilter));

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var routeData = filterContext.RouteData;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var params_ = JsonConvert.SerializeObject(filterContext.ActionParameters);

            var message = $"API Log: controller:{controllerName} action:{actionName}, params: {params_}";

            Log.Debug(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Log("OnResultExecuted", filterContext.RouteData);
        }


        private void Log2(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            //routeData.re
            var message = $"{methodName} controller:{controllerName} action:{actionName}";

            Log.Debug($"API Log: {message}");
        }
    }
}