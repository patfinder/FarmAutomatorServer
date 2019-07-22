using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class ProductMarginReportModel
    {
        public string report_month { get; set; }
    }

    public class ProductMarginReportQueryResult
    {
        public string p_1 { get; set; }

        public string big_name { get; set; }

        public string p_2 { get; set; }

        public string medium_name { get; set; }

        public string product_no { get; set; }

        public string product_vname { get; set; }

        public string packing_type { get; set; }

        public double qty { get; set; }

        public double unit_margin { get; set; }

        public double margin { get; set; }
    }

    public class ProductMarginReportResultModel
    {
        public string director_ename { get; set; }

        public List<DirectorReport_Chief> Chiefs = new List<DirectorReport_Chief>();

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public double ThisDaySale => Chiefs.Sum(c => c.ThisDaySale);

        public double LastPeriodSale => Chiefs.Sum(c => c.LastPeriodSale);

        public double ThisPeriodSale => Chiefs.Sum(c => c.ThisPeriodSale);
    }
}
