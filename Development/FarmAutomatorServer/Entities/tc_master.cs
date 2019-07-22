using System;
using System.Collections.Generic;

namespace FarmAutomatorServer.Entities
{
    public class tc_master
    {
        public string tc_no { get; set; }

        public DateTime tc_date { get; set; }

        public string bill_no { get; set; }

        public string symbol_no { get; set; }

        public string cust_no { get; set; }

        /// <summary>
        /// Custom field
        /// </summary>
        public string cust_vname { get; set; }

        public double total_vnd { get; set; }

        public double total_qty { get; set; }

        public string sale_no { get; set; }

        public string kv_no { get; set; }

        public sale_man sale_man { get; set; }

        public List<tc_detail> Details { get; set; } = new List<tc_detail>();

    }
}