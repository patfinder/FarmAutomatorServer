using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class ChiefReportModel
    {
        public string chief_no { get; set; }

        /// <summary>
        /// Area (khu vực)
        /// </summary>
        public string cust_type { get; set; }

        /// <summary>
        /// Loại Khách hàng hay Thương hiệu (1: nupak; 3: Dachan; 5:Redstar)
        /// </summary>
        public string label_flag { get; set; }

        public DateTime tc_date { get; set; }
    }
    
    public class ChiefQueryResult
    {
        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public string cust_no { get; set; }

        public double M1 { get; set; }
        public double M2 { get; set; }
        public double M3 { get; set; }
        public double M4 { get; set; }
        public double M5 { get; set; }
        public double M6 { get; set; }
        public double M7 { get; set; }
        public double M8 { get; set; }
        public double M9 { get; set; }
        public double M10 { get; set; }
        public double M11 { get; set; }
        public double M12 { get; set; }
    }
    
    public class ChiefReportResultModel
    {
        public string chief_ename { get; set; }
        
        public List<ChiefReport_SaleMan> SaleMans = new List<ChiefReport_SaleMan>();
    }

    public class ChiefReport_SaleMan
    {
        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public List<ChiefReport_Agent> Agents = new List<ChiefReport_Agent>();

        public Dictionary<int, double> MonthTotals { get; set; } = new Dictionary<int, double>();
    }

    public class ChiefReport_Agent
    {
        public string cust_no { get; set; }

        public string cust_vname { get; set; }

        public Dictionary<int, double> MonthSales { get; set; } = new Dictionary<int, double>();

        public double Total => MonthSales.Sum(m => m.Value);
    }
}