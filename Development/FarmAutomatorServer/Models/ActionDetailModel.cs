using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Lưu thông tin gắn với từng chuồng (đặc trưng bơi QR code)
    /// </summary>
    public class ActionDetailModel
    {
        public string Id { get; set; }

        public string ActionId { get; set; }

        public string QrCode { get; set; }

        public double Quanity { get; set; }

        public string Picture1 { get; set; }

        public string Picture2 { get; set; }

        public string Picture3 { get; set; }

    }
}
