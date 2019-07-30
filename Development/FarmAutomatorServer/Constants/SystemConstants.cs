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

    public enum TaskType
    {
        Feed,
        Medicine
    }
}
