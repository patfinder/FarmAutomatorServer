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

        /// <summary>
        /// Case Id. Mã chuồng, lấy từ QR code.
        /// </summary>
        public string CaseId { get; set; }

        public double Quanity { get; set; }

        public string[] PictureIds { get; set; }
    }
}
