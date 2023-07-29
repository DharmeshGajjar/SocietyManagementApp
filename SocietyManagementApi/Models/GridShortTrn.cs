using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class GridShortTrn
    {
        public long GrdbVou { get; set; }
        public long? GrdBgrdVou { get; set; }
        public string GrdBdbFld { get; set; }
        public string GrdBcolNm { get; set; }
        public int? GrdBdefYn { get; set; }
        public int? GrdBsrNo { get; set; }
    }
}
