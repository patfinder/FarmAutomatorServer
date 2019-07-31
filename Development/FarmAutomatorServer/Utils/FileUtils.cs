using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Utils
{
    public static class FileUtils
    {
        public static string GetPictureStorePath()
        {
            return GetPictureStorePath(DateTime.Now);
        }

        public static string GetPictureStorePath(DateTime time)
        {
            var monthPath = time.ToString("yyyy-MM");
            return $"{ConfigurationManager.AppSettings["ScanImagePath"]}/{monthPath}";
        }
    }
}