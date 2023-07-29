using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.ViewModels
{
    public class GeneralMasterViewModel
    {
        public class StateMasterModel
        {
            public long StateId { get; set; }
            public string StateName { get; set; }
            public string Code { get; set; }
        }
        public class CityMasterModel
        {
            public long CityId { get; set; }
            public string CityName { get; set; }
            public string Code { get; set; }
            public long? StateId { get; set; }
        }

        public class RoomTypeModel
        {
            public int Id { get; set; }
            public string Type { get; set; }
        }
    }
}
