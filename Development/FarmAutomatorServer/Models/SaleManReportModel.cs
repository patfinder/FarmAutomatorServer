using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmAutomatorServer.Entities;
using VisitMeServer.Models;

namespace FarmAutomatorServer.Models
{
    public class SalemanReportModel
    {
        public string sale_no { get; set; }

        public string part_kind { get; set; }

        public DateTime tc_date1 { get; set; }

        public DateTime tc_date2 { get; set; }
    }

    public class SaleManReportResultModel
    {
        public string sale_ename { get; set; }

        public string PartKindName { get; set; }

        public List<SalemanReportP1> P1List { get; set; } = new List<SalemanReportP1>();

        public List<string> Customers { get; set; } = new List<string>();
    }

    public class SalemanReportP1 : ReportP1
    {
        new public List<SalemanReportP2> P2List { get; set; } = new List<SalemanReportP2>();
    }

    public class SalemanReportP2 : ReportP2
    {
        public double TotalQuantity
        {
            get { return Products.Sum(p => p.Customers.Sum(c => c.Item2)); }
        }

        new public List<SalemanReportProduct> Products { get; set; } = new List<SalemanReportProduct>();
    }

    public class SalemanReportProduct : product
    {
        /// <summary>
        /// Tuple of Customer_no and Quantity
        /// </summary>
        public List<Tuple2<string, double>> Customers { get; set; } = new List<Tuple2<string, double>>();
    }
}