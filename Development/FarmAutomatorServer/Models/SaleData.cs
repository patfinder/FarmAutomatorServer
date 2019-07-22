using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Models
{
    public class SaleData
    {
        public string TcNo { get; set; }

        public string CustNo { get; set; }

        public float SumTotalQty { get; set; }
    }
}