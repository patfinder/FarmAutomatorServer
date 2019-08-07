using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Lưu thông tin gắn với từng chuồng (đặc trưng bởi QR code)
    /// </summary>
    public class ActionCageModel
    {
        /// <summary>
        /// Cage Id. Mã chuồng, lấy từ QR code.
        /// </summary>
        public string Id { get; set; }

        public string ActionId { get; set; }

        public double Quanity { get; set; }

        public string[] Pictures { get; set; }
    }
}
