using FarmAutomatorServer.Constants;
using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Thuốc/Thức ăn
    /// </summary>
    public class FeedModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FeedType FeedType { get; set; }
    }
}
