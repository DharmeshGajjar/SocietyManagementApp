using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.ViewModels
{
    public class PaymentViewModel
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
