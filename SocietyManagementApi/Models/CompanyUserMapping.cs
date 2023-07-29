using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class CompanyUserMapping
    {
        public int Id { get; set; }
        public int? CmpId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Doc { get; set; }
    }
}
