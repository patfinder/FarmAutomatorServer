using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Task table. Store info like: "Tiem Thuoc", "Cho An".
    /// Store stask definition. Not real task taken by workers.
    /// </summary>
    public class TaskModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
