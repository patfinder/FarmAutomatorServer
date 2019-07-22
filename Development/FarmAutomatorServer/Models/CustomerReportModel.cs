using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmAutomatorServer.Entities;
using VisitMeServer.API;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class CustomerReportModel
    {
        public string cust_no { get; set; }

        public string part_kind { get; set; }

        public DateTime tc_date1 { get; set; }

        public DateTime tc_date2 { get; set; }
    }
}
