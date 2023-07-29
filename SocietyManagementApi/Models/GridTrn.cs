using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class GridTrn
    {
        public long GrdAvou { get; set; }
        public long GrdAgrdVou { get; set; }
        public int? GrdAhideYn { get; set; }
        public int GrdAposition { get; set; }
        public string GrdAcolNm { get; set; }
        public string GrdAnewColNm { get; set; }
        public string GrdAdbFld { get; set; }
        public string GrdAdbFld2 { get; set; }
        public int GrdAdataType { get; set; }
        public int GrdAwidth { get; set; }
        public int? GrdAdecUpTo { get; set; }
        public int GrdAalign { get; set; }
        public int? GrdAtotYn { get; set; }
        public int? GrdAlinkYn { get; set; }
        public string GrdAsuppressIfval { get; set; }
        public int? GrdAsrNo { get; set; }
        public bool? CanGrow { get; set; }
    }
}
