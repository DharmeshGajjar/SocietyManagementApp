using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class GridMst
    {
        public long GrdVou { get; set; }
        public long GrdMnuVou { get; set; }
        public string GrdType { get; set; }
        public string GrdName { get; set; }
        public int? GrdMultiSelYn { get; set; }
        public string GrdQryFields { get; set; }
        public string GrdQryJoin { get; set; }
        public string GrdQryOrderBy { get; set; }
        public DateTime? GrdDate { get; set; }
        public DateTime? GrdUsrDt { get; set; }
        public int? GrdDftYno { get; set; }
        public string GrdTitle { get; set; }
        public int PageSize { get; set; }
    }
}
