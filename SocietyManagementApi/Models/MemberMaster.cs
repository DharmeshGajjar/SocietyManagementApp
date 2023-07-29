using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class MemberMaster
    {
        public long MemberId { get; set; }
        public long? SocietyId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? Type { get; set; }
        public string Address { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingEmail { get; set; }
        public int? BillingMobile { get; set; }
        public string Gstno { get; set; }
        public string PanNo { get; set; }
        public string OccupationType { get; set; }
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? AltMobile { get; set; }
        public string AltEmail { get; set; }
        public long UserId { get; set; }

        public virtual SocietyMaster Society { get; set; }
        public virtual UserMaster User { get; set; }
    }
}
