using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class BlockMaster
    {
        public BlockMaster()
        {
            UnitMasters = new HashSet<UnitMaster>();
        }

        public long BlockId { get; set; }
        public long SocietyId { get; set; }
        public string Name { get; set; }
        public int? DisplayPosition { get; set; }
        public int? TotalFloor { get; set; }
        public int? TotalFlatPerFloor { get; set; }
        public int? BlockFormate { get; set; }

        public virtual SocietyMaster Society { get; set; }
        public virtual ICollection<UnitMaster> UnitMasters { get; set; }
    }
}
