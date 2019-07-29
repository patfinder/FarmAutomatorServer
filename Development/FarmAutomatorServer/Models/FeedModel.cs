using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Loại Thuốc/Thức ăn
    /// </summary>
    public class FeedModel
    {
        public string Id { get; set; }

        public FeedType FeedType { get; set; }

        public string TaskId { get; set; }

        public string Name { get; set; }
    }

    public enum FeedType
    {
        Unknown,
        Food,
        Medicine,
    }
}
