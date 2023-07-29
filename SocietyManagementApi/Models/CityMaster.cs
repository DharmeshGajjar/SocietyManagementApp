using System;
using System.Collections.Generic;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class CityMaster
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
        public long? StateId { get; set; }

        public virtual StateMaster State { get; set; }
    }
}
