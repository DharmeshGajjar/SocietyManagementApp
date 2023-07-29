using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class CompanyYearMapping
    {
        public int Id { get; set; }
        public int? CmpId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Year { get; set; }
    }
}
