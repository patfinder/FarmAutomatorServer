using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisitMeServer.Admin.VMAdminUtils
{
    public class BaseController : Controller
    {
        protected internal new JsonNetResult Json(object data)
        {
            return new JsonNetResult { Data = data };
        }
    }
}