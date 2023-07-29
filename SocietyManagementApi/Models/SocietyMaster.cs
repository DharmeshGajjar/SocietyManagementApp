using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class SocietyMaster
    {
        public SocietyMaster()
        {
            BlockMasters = new HashSet<BlockMaster>();
            MemberMasters = new HashSet<MemberMaster>();
        }

        public long SocietyId { get; set; }
        public long? ClientId { get; set; }
        public string RegisteredName { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? BlockCount { get; set; }
        public int? Units { get; set; }
        public string Language { get; set; }
        public string RegisterNo { get; set; }
        public string PanNo { get; set; }
        public string Gstno { get; set; }
        public int? MobileNumber { get; set; }
        public string EmailId { get; set; }
        public bool? IsActive { get; set; }
        public string Image { get; set; }

        public virtual ICollection<BlockMaster> BlockMasters { get; set; }
        public virtual ICollection<MemberMaster> MemberMasters { get; set; }
    }
}
