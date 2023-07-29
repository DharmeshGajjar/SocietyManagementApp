using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            MemberMasters = new HashSet<MemberMaster>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int? ActiveUser { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Imieno { get; set; }
        public string TokenId { get; set; }
        public int? Otp { get; set; }
        public int? Device { get; set; }
        public string DeviceName { get; set; }
        public double? AppVersion { get; set; }
        public DateTime? SignUpdate { get; set; }
        public DateTime? LastSeen { get; set; }
        public DateTime? OtpCrtDate { get; set; }
        public string Image { get; set; }

        public virtual ICollection<MemberMaster> MemberMasters { get; set; }
    }
}
