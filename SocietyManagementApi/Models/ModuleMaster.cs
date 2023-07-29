using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class ModuleMaster
    {
        public long ModuleId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public long? ParentFk { get; set; }
        public bool IsMaster { get; set; }
        public int Position { get; set; }
        public int DashboardPosition { get; set; }
    }
}
