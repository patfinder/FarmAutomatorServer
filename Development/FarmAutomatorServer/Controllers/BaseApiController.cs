using System.Net;
using System.Web.Http;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Controllers
{
    [VmActionLogFilter, VMExceptionFilter]
    public class BaseApiController : ApiController
    {
        public IHttpActionResult ApiContent(ApiResult apiResult)
        {
            return Content(apiResult.ResultCode == ApiResultCode.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest, apiResult);
        }
    }
}
