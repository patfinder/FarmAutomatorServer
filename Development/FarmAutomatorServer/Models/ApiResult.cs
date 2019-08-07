using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Models
{
    public class ApiResult
    {
        public ResultCode ResultCode { get; set; }

        public string[] Messages { get; set; }

        public object Data { get; set; }

        public ApiResult()
        {
            ResultCode = ResultCode.Success;
            Messages = new string[0];
            Data = null;
        }
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ResultCode
    {
        Unknown = 0,
        Success = 1,
        GenericError,
        Unauthenticated,
    }
}
