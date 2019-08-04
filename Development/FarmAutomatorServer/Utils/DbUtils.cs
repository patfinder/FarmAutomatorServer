using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace FarmAutomatorServer.Utils
{
    public static class DbUtils
    {
        public static IDbConnection Connection
        {
            get
            {
#if USESQLITE
                return new SQLiteConnection(ConnectionString);
#elif USEORACLE
                return new OracleConnection(ConnectionString);
#else
#endif
            }
        }

        public static string ConnectionString
        {
            get =>
#if USESQLITE
                ConfigurationManager.ConnectionStrings["SqlLiteDb"].ConnectionString;
#elif USEORACLE
                ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
#else
#endif
        }

        public static string _T(string sql)
        {
#if USESQLITE
            return sql.Replace("#", ":");
#elif USEORACLE
            return sql.Replace("#", ":");
#else
            // sql server
            //return sql.Replace("#", "@");
#endif
        }
    }
}
