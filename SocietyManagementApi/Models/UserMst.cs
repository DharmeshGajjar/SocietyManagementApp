using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class UserMst
    {
        public long UserVou { get; set; }
        public decimal? UserEmpVou { get; set; }
        public string UserEmpNm { get; set; }
        public string UserId { get; set; }
        public string UserCd { get; set; }
        public string UserPass { get; set; }
        public DateTime? UserUseDt { get; set; }
        public string UserMobNo { get; set; }
        public string UserEmail { get; set; }
        public int? ClientId { get; set; }
        public int IsAdministrator { get; set; }
        public decimal? UserRolVou { get; set; }
        public string UserPhoto { get; set; }
        public string UserActYn { get; set; }
    }
}
