using System;
//using AttributeRouting.Web.Mvc;

namespace FarmAutomatorServer.Models
{
    /// <summary>
    /// Lưu loại công việc: Cho ăn/Uống thuốc
    /// </summary>
    public class TaskModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CattleId { get; set; }
    }
}
