using log4net;
using System.Web.Http.Filters;

namespace FarmAutomatorServer.Controllers
{
    public class VMExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(VMExceptionFilterAttribute));

        public override void OnException(HttpActionExecutedContext context)
        {
            Log.Error("VM API", context.Exception);
        }
    }
}