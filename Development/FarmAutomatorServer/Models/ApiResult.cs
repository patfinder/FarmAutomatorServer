using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Models
{
    public class ApiResult
    {
        public ResultCode ResultCode { get; set; }

        public string ErrorMessages { get; set; }
    }

    public enum ResultCode
    {
        Unknown = 0,
        Success = 1,
        GenericError,
    }
}