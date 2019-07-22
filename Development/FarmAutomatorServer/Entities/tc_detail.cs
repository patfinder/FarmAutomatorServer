namespace FarmAutomatorServer.Entities
{
    public class tc_detail
    {
        public string tc_no { get; set; }

        public int s_no { get; set; }

        public string product_no { get; set; }

        public double packing_type { get; set; }

        public double qty { get; set; }

        public double unit_price { get; set; }

        public tc_master tc_master { get; set; }

        public product product { get; set; }
    }
}