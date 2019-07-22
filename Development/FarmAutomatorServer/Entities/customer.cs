namespace FarmAutomatorServer.Entities
{
    public class customer
    {
        public string cust_no { get; set; }

        public string cust_vname { get; set; }

        public string address_name { get; set; }

        public string sale_no { get; set; }

        /// <summary>
        /// Brand or Customer Type: loại khách hành. VD: 1: nupak; 3: Dachan; 5:Redstar,,,,,,
        /// </summary>
        public string label_flag { get; set; }

        /// <summary>
        /// Area (Khu vực): 1x, 2x, 3x, 4x, 5x
        /// </summary>
        public string cust_type { get; set; }

        public string cust_kind { get; set; }
    }
}