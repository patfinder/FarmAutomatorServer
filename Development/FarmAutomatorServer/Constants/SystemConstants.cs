using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Constants
{
    public static class SystemConstants
    {
        public static string AuthenticationCookie => "auth-cookie";
    }

    /// <summary>
    /// Cho ăn hoặc uống thuốc.
    /// </summary>
    public enum TaskType
    {
        Feed,
        Medicine
    }
}
