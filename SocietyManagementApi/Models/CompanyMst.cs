using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class CompanyMst
    {
        public long CmpVou { get; set; }
        public string CmpCode { get; set; }
        public string CmpName { get; set; }
        public int ClientId { get; set; }
        public DateTime? CmpStDt { get; set; }
        public DateTime? CmpEndDt { get; set; }
    }
}
