using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using VisitMeServer.API.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;
using FarmAutomatorServer.Entities;
using FarmAutomatorServer.Models;

namespace VisitMeServer.API
{
    public class DbServices
    {
        public static Dictionary<string, string> GetP1List()
        {
            using (
                IDbConnection db =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var detailRows = db.Query("SELECT p_1 Item1, big_name Item2 FROM dbo.big_table");

                return Slapper.AutoMapper.MapDynamic<Tuple2<string, string>>(detailRows)
                    .ToDictionary(kv => kv.Item1, kv => kv.Item2);
            }
        }

        public static List<Tuple3<string, string, string>> GetP2List()
        {
            using (
                IDbConnection db =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var detailRows = db.Query("SELECT p_1 Item1, p_2 Item2, medium_name Item3 FROM dbo.medium_table");

                return Slapper.AutoMapper.MapDynamic<Tuple3<string, string, string>>(detailRows).ToList();
            }
        }
    }
}