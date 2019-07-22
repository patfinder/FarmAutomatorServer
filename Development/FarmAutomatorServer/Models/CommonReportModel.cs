using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmAutomatorServer.Entities;
using VisitMeServer.API;

namespace FarmAutomatorServer.Models
{

    public class ReportP1
    {
        public string P1 { get; set; }

        /// <summary>
        /// ID, Name
        /// </summary>
        static internal Dictionary<string, string> _P_1List;

        public string P1Name
        {
            get
            {
                if (_P_1List == null)
                {
                    _P_1List = DbServices.GetP1List();
                }

                return _P_1List.ContainsKey(P1) ? _P_1List[P1] : P1;
            }
        }

        public double TotalWeight
        {
            get { return P2List.Sum(p => p.TotalWeight); }
        }

        public double TotalAmount
        {
            get { return P2List.Sum(p => p.TotalAmount); }
        }

        public List<ReportP2> P2List { get; set; } = new List<ReportP2>();
    }

    public class ReportP2
    {
        public string P2 { get; set; }

        /// <summary>
        /// P1 ID, P2 ID, P2 Name
        /// ("00", "0001", "Bán thành phẩm")
        /// </summary>
        static internal List<Tuple3<string, string, string>> _P_2List;

        public string P2Name
        {
            get
            {
                if (_P_2List == null)
                {
                    _P_2List = DbServices.GetP2List();
                }
                return _P_2List.FirstOrDefault(p => p.Item2 == P2)?.Item3 ?? P2;
            }
        }

        public double TotalWeight
        {
            get { return Products.Sum(p => p.weight); }
        }

        public double TotalAmount
        {
            get { return Products.Sum(p => p.amount); }
        }

        public List<ReportProduct> Products { get; set; } = new List<ReportProduct>();
    }

    public class ReportProduct : product
    {
        /// <summary>
        /// packing_type * qty
        /// </summary>
        public double weight { get; set; }

        public double amount { get; set; }
    }

    public class CommonQueryResult
    {
        public string p_1 { get; set; }

        public string p_2 { get; set; }

        public string p_no { get; set; }

        public string product_vname { get; set; }

        public double packing_type { get; set; }

        public string cust_no { get; set; }
        
        public double weight { get; set; }

        public double amount { get; set; }
    }

}