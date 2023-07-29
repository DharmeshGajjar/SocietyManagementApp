using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class YearMst
    {
        public int YearVou { get; set; }
        public int CmpVou { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public int IsDefault { get; set; }
    }
}
