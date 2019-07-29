using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string FULLNAME { get; set; }
        public string CMND { get; set; }
        public string DATE_PLACE_CMND { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESS_CONTACT { get; set; }
        public string HOME_PHONE { get; set; }
        public string MOBILE_PHONE { get; set; }
        public string HOME_PHONE_CONTACT { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public int GENDER { get; set; }
        public string HEIGHT { get; set; }
        public string WEIGHT { get; set; }
        public int MIRITAL { get; set; }
        public string MIRITAL_OTHER { get; set; }
        public DateTime DOB { get; set; }
        public string POB { get; set; }
        public string IMAGE { get; set; }
        public string RELATE_EXP { get; set; }
        public string CONTACT_LEADER { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string TOKEN { get; set; }
        public int STATUS { get; set; }
        public DateTime MODIFIED { get; set; }
        public DateTime CREATED { get; set; }
    }
}
