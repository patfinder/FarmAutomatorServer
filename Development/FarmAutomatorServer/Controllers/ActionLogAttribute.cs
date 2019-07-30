using FarmAutomatorServer.Controllers;
using log4net;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Mvc;
//using System.Web.Http.Filters;
//using VisitMeServer.VisitMeUtils;

namespace SalesManagement.Controllers
{
    public class ActionLogAttribute : ActionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActionLogAttribute));

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (!Log.IsDebugEnabled)
                    return;

                var userId = "<unknown>";
                if (context.Controller is BaseController controller && controller.HttpContext.User.Identity.IsAuthenticated)
                    userId = controller.HttpContext.User.Identity.Name;

                var logData = new
                {
                    userId,
                    context.ActionDescriptor.ControllerDescriptor.ControllerName,
                    context.ActionDescriptor.ActionName,
                    context.RequestContext.HttpContext.Request.HttpMethod,
                    QueryString = context.RequestContext.HttpContext.Request.QueryString.ToString(),
                    context.RequestContext.HttpContext.Request.RawUrl,
                };

                Log.Debug($"Action Data: {JsonConvert.SerializeObject(logData)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}