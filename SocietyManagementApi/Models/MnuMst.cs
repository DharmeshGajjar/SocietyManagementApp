using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class MnuMst
    {
        public decimal MnuVou { get; set; }
        public string MnuNm { get; set; }
        public string MnuCd { get; set; }
        public string MnuIcon { get; set; }
        public string MnuDesc { get; set; }
        public decimal? MnuPmnuVou { get; set; }
        public string MnuLink { get; set; }
        public int? MnuPos { get; set; }
        public int? MnuDpos { get; set; }
    }
}
