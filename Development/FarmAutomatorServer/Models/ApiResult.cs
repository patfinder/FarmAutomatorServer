using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
//using MongoDB.Bson;

namespace VisitMeServer.Models
{
    public class ApiResult
    {
        public ApiResultCode ResultCode { get; set; }

        public List<string> ResultMessages { get; set; }

        public ApiResult()
        {
            ResultCode = ApiResultCode.Success;
            ResultMessages = new List<string>();
        }

        public ApiResult(ApiResult result)
        {
            ResultCode = result.ResultCode;
            ResultMessages = result.ResultMessages;
        }

        public ApiResult(ApiResultCode resultCode, List<string> resultMessages)
        {
            ResultCode = resultCode;
            ResultMessages = resultMessages;
        }

        public static ApiResult Ok()
        {
            return new ApiResult() { ResultMessages = new List<string> { "Command successfully." } };
        }

        public static ApiResult NotFound(string message = "Item not found.")
        {
            return new ApiResult(ApiResultCode.GenericError, new[] { message }.ToList());
        }

        public static ApiResult InternalServerError(string message)
        {
            return new ApiResult(ApiResultCode.GenericError, new[] { message }.ToList());
        }

        public static ApiResult ParametersError(string message)
        {
            return new ApiResult(ApiResultCode.ParametersError, new[] { message }.ToList());
        }

        public static ApiResult<object> FromResult(object result)
        {
            return new ApiResult<object> { Result = result };
        }
    }

    public class ApiResult<T> : ApiResult
    {
        public T Result { get; set; }

        public ApiResult()
        {
            ResultCode = ApiResultCode.Success;
            ResultMessages = new List<string>();
        }

        public ApiResult(ApiResult result)
        {
            ResultCode = result.ResultCode;
            ResultMessages = result.ResultMessages;
        }

        public ApiResult(ApiResultCode resultCode, string resultMessage)
        {
            ResultCode = resultCode;
            ResultMessages = new List<string> { resultMessage };
        }

        public ApiResult(ApiResultCode resultCode, List<string> resultMessages)
        {
            ResultCode = resultCode;
            ResultMessages = resultMessages;
        }

        public ApiResult(T result)
        {
            Result = result;
        }

        public ApiResult(T result, ApiResultCode resultCode, List<string> resultMessages)
        {
            Result = result;
            ResultCode = resultCode;
            ResultMessages = resultMessages;
        }

        public static ApiResult<T> FromResult(T result)
        {
            return new ApiResult<T> { Result = result };
        }
    }

    public class ObjectApiResult : ApiResult<object>
    {
        public ObjectApiResult() { }

        public ObjectApiResult(ApiResult result) : base(result) { }

        public ObjectApiResult(ApiResultCode resultCode, string resultMessage) : base(resultCode, resultMessage) { }

        public ObjectApiResult(ApiResultCode resultCode, List<string> resultMessages) : base(resultCode, resultMessages) { }

        public ObjectApiResult(object result, ApiResultCode resultCode, List<string> resultMessages)
            : base(result, resultCode, resultMessages)
        { }
    }

    public class StringApiResult : ApiResult<string>
    {
        public StringApiResult() { }

        public StringApiResult(ApiResult result) : base(result) { }

        public StringApiResult(ApiResultCode resultCode, string resultMessage) : base(resultCode, resultMessage) { }

        public StringApiResult(ApiResultCode resultCode, List<string> resultMessages) : base(resultCode, resultMessages) { }

        public StringApiResult(string result, ApiResultCode resultCode, List<string> resultMessages)
            : base(result, resultCode, resultMessages)
        { }
    }

    //public class ObjectIdApiResult : ApiResult<ObjectId>
    //{
    //    public ObjectIdApiResult() { }

    //    public ObjectIdApiResult(ApiResult result) : base(result) { }

    //    public ObjectIdApiResult(ApiResultCode resultCode, string resultMessage) : base(resultCode, resultMessage) { }

    //    public ObjectIdApiResult(ApiResultCode resultCode, List<string> resultMessages) : base(resultCode, resultMessages) { }

    //    public ObjectIdApiResult(ObjectId result, ApiResultCode resultCode, List<string> resultMessages)
    //        : base(result, resultCode, resultMessages)
    //    { }
    //}

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApiResultCode
    {
        Unknown,
        Success,
        GenericError,
        ParametersError,

        AccountAuthorizationInconsistency,
        StripeTokenNotProvided,
    }

    static class SystemErrorCodeMethods
    {
        public static String ToString(this ApiResultCode resultCode)
        {
            return "E" + (int)resultCode;
        }
    }
}