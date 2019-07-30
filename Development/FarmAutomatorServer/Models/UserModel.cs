using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }
    }

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        Unknown,
        Worker,
    }
}
