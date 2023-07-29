using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class ApartmentType
    {
        public long ApartmentId { get; set; }
        public string ApartmentName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
