using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class GetSaleDataModel : PagingParams
    {
        public string SaleNo { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime Date2 { get; set; }
    }
}