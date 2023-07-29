using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class StateMaster
    {
        public StateMaster()
        {
            CityMasters = new HashSet<CityMaster>();
        }

        public long StateId { get; set; }
        public string StateName { get; set; }
        public string Code { get; set; }

        public virtual ICollection<CityMaster> CityMasters { get; set; }
    }
}
