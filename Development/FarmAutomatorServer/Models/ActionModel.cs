using FarmAutomatorServer.Constants;
using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Lưu công việc thực tế đã thực hiện bởi công nhân.
    /// Lưu thông chung của nhiều chuồng.
    /// </summary>
    public class ActionModel
    {
        public string Id { get; set; }

        public string CattleId { get; set; }

        public string FeedId { get; set; }

        public FeedType FeedType { get; set; } // No-need, infer from FeedId

        public string UserId { get; set; }

        public DateTime ActionTime { get; set; }

        /// <summary>
        /// Quanity value is common between ActionDetails.
        /// Store the value here only for copying to ActionDetails
        /// </summary>
        public double Quanity { get; set; }
    }
}
