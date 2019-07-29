using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Utils
{
    public  class DbUtils
    {
        public static string ConnectionString
        {
            get => ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
        }
    }
}