using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Task table. Store top level info: Loại heo
    /// Store stask definition. Not real task taken by workers.
    /// </summary>
    public class CattleModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        Unknown,
        Worker,
    }
}
