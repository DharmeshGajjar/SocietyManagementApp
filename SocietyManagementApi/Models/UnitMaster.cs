using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class UnitMaster
    {
        public long UnitId { get; set; }
        public long SocietyId { get; set; }
        public long BlockId { get; set; }
        public int FloorNo { get; set; }
        public string UnitNo { get; set; }
        public bool? Status { get; set; }
        public int? SquareFoot { get; set; }
        public long OwnerId { get; set; }
        public long TenentId { get; set; }
        public int? RoomType { get; set; }

        public virtual BlockMaster Block { get; set; }
    }
}
