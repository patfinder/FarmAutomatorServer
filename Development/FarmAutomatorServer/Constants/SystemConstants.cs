using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Constants
{
    public static class SystemConstants
    {
        public const string AuthenticationCookie = "auth-cookie";

        /// <summary>
        /// Should not < 3
        /// </summary>
        public const int MaxScanPictureCount = 3;
    }

    public enum FeedType
    {
        Food,
        Medicine,
    }

    /// <summary>
    /// Cho ăn hoặc Cho uống thuốc.
    /// </summary>
    public enum TaskType
    {
        Feed,
        GiveMedicine,
    }
}
