using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class GenSetting
    {
        public long? GenVou { get; set; }
        public long? GenCmpVou { get; set; }
        public string GenEmail { get; set; }
        public string GenPass { get; set; }
        public int? GenSmtp { get; set; }
        public string GenWhtMob { get; set; }
        public string GenTokenId { get; set; }
        public string GenInstId { get; set; }
        public string GenHost { get; set; }
        public string GenSkruApi { get; set; }
        public string GenSurl { get; set; }
    }
}
