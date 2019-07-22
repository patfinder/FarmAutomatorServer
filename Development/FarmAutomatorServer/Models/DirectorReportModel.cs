using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class DirectorReportModel
    {
        public string sale_no { get; set; }

        /// <summary>
        /// Area (khu vực)
        /// </summary>
        public string cust_type { get; set; }

        /// <summary>
        /// Loại Khách hàng hay Thương hiệu (1: nupak; 3: Dachan; 5:Redstar)
        /// </summary>
        public string label_flag { get; set; }

        public float packing_type { get; set; }

        public string p_1 { get; set; }

        public string p_2 { get; set; }

        public string product_no { get; set; }
        
        public DateTime tc_date { get; set; }

        public PeriodType PeriodType { get; set; }
    }

    public enum PeriodType
    {
        Unknown,
        /// <summary>
        /// Not supported
        /// </summary>
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        /// <summary>
        /// Quý
        /// </summary>
        Quarterly,
        Yearly = 5,
        Annualy = 5,
    }

    public class DirectorQueryResult
    {
        public string chief_no { get; set; }

        public string chief_ename { get; set; }

        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public string mobile { get; set; }

        public double LastPeriod { get; set; }

        public double ThisPeriod { get; set; }

        public double ThisDay { get; set; }

        public double Offset { get; set; }

        public double OffsetPercent { get; set; }
    }

    public class DirectorReportResultModel
    {
        public string director_ename { get; set; }
        
        public List<DirectorReport_Chief> Chiefs = new List<DirectorReport_Chief>();

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public double ThisDaySale => Chiefs.Sum(c => c.ThisDaySale);

        public double LastPeriodSale => Chiefs.Sum(c => c.LastPeriodSale);

        public double ThisPeriodSale => Chiefs.Sum(c => c.ThisPeriodSale);
    }

    public class DirectorReport_Chief
    {
        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public List<DirectorReport_Saleman> Salemans = new List<DirectorReport_Saleman>();

        public double LastPeriodSale => Salemans.Sum(s => s.LastPeriodSale);

        public double ThisPeriodSale => Salemans.Sum(s => s.ThisPeriodSale);

        public double ThisDaySale => Salemans.Sum(s => s.ThisDaySale);

        public double Offset => ThisPeriodSale - LastPeriodSale;

        public double PercentOffset => Offset/ LastPeriodSale;
    }

    public class DirectorReport_Saleman
    {
        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public string mobile { get; set; }

        public double LastPeriodSale { get; set; }

        public double ThisPeriodSale { get; set; }

        public double ThisDaySale { get; set; }
        
        public double Offset => ThisPeriodSale - LastPeriodSale;

        public double PercentOffset => Offset/LastPeriodSale;
    }
}