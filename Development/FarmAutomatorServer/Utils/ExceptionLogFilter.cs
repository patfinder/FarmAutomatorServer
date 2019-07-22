using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
//using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Newtonsoft.Json;
using FarmAutomatorServer.Controllers;

namespace FarmAutomatorServer.Utils
{
    public class ExceptionLogFilter : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogActionFilter));

        public override void OnException(HttpActionExecutedContext context)
        {
            var routeData = context.Request.GetRouteData();
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var params_ = JsonConvert.SerializeObject(context.Request.GetActionDescriptor().GetParameters());

            var message = $"API Exception Log: controller:{controllerName} action:{actionName}, params: {params_}";

            Log.Debug(message);
        }
    }
}