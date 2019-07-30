using FarmAutomatorServer.Controllers;
using log4net;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace SalesManagement.Controllers
{
    public class ExceptionLogAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ExceptionLogAttribute));

        public void OnException(ExceptionContext context)
        {
            var userId = "<unknown>";
            if (context.Controller is BaseController controller && controller.HttpContext.User.Identity.IsAuthenticated)
                userId = controller.HttpContext.User.Identity.Name;

            var routeData = context.Controller.ControllerContext.RouteData.Values.Select(v => new { v.Key, v.Value });

            var logData = new
            {
                userId,
                routeData,
                context.RequestContext.HttpContext.Request.HttpMethod,
                context.RequestContext.HttpContext.Request.RawUrl
            };

            Log.Debug($"Request Data: {JsonConvert.SerializeObject(logData)}");
            Log.Error($"App Exception: {context.Exception}");
        }
    }
}
