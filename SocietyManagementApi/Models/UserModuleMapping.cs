using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class UserModuleMapping
    {
        public long UserModuleId { get; set; }
        public long UserId { get; set; }
        public long ModuleId { get; set; }
        public bool IsList { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
    }
}
