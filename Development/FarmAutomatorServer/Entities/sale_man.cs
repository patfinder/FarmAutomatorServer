namespace FarmAutomatorServer.Entities
{
    public class sale_man
    {
        public string sale_no { get; set; }

        public string sale_ename { get; set; }

        public string mobile { get; set; }

        public string dir_no { get; set; }

        public string chief_no { get; set; }

        /// <summary>
        /// Extra field.
        /// </summary>
        public string chief_ename { get; set; }

        public string lead_no { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public sale_role role { get; set; }
    }

    public enum sale_role
    {
        // general director
        gen = 0,
        dir = 1,
        chief = 2,
        lead = 3,
        sale = 4,
    }
}
