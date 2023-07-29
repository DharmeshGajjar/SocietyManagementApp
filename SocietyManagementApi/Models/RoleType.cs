using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class RoleType
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
    }
}
