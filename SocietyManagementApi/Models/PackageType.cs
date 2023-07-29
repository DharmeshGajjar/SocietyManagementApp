using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class PackageType
    {
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public double? Cost { get; set; }
        public int? Days { get; set; }
        public int? NoOfUser { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
