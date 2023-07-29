using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.ViewModels
{
    public class SocietyViewModel
    {
        public class BuildingViewModel
        {
            public long Id { get; set; }
            public string TypeName { get; set; }
        }
        public class SocietyMasterViewModel
        {
            public long SocietyId { get; set; }
            public long? ClientId { get; set; }
            public string RegisteredName { get; set; }
            public string Name { get; set; }
            public int Code { get; set; }
            public string Address { get; set; }
            public string PinCode { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public int? BlockCount { get; set; }
            public int? Units { get; set; }
            public string Language { get; set; }
            public string RegisterNo { get; set; }
            public string PanNo { get; set; }
            public string Gstno { get; set; }
            public int? MobileNumber { get; set; }
            public string EmailId { get; set; }
            public bool? IsActive { get; set; }
            public string Image { get; set; }
            public string UFirstNme { get; set; }
            public string ULastNme { get; set; }
            public string UMobile { get; set; }
            public string UEmail { get; set; }
            public string UPassword { get; set; }
            public IFormFile file { get; set; }
            public long UserId { get; set; }
            public List<BlockModel> lstBlockList { get; set; } = new List<BlockModel>();
        }

        public class SocietyMasterResponseModel
        {

            public long SocietyId { get; set; }
            public long? ClientId { get; set; }
            public string RegisteredName { get; set; }
            public string Name { get; set; }
            public int? Code { get; set; }
            public string Address { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public int? BlockCount { get; set; }
            public int? Units { get; set; }
            public bool? IsActive { get; set; }
            public string Image { get; set; }
        }
        public class BlockModel
        {
            public long BlockId { get; set; }
            public long SocietyId { get; set; }
            public string Name { get; set; }
            public int? TotalFloor { get; set; }
            public int? TotalFlatPerFloor { get; set; }
            public int? BlockFormate { get; set; }
            public List<UnitViewModel> lstUnitModel { get; set; } = new List<UnitViewModel>();
        }
        public partial class UnitViewModel
        {
            public long UnitId { get; set; }
            public long SocietyId { get; set; }
            public long BlockId { get; set; }
            public int FloorNo { get; set; }
            public string UnitNo { get; set; }
            public bool? Status { get; set; }
            public int? SquareFoot { get; set; }
            public int? RoomType { get; set; }

        }
        public partial class UnitFilterModel
        {
            public long SocietyId { get; set; }
            public long BlockId { get; set; }
        }

        public partial class FlatNoRequestForBookingModel
        {
            public long SocietyId { get; set; }
            public long BlockId { get; set; }
            public string BlockName { get; set; }
            public long UnitNo { get; set; }
            public long OwnerId { get; set; } = 0;
            public long TenentID { get; set; } = 0;
            public bool Status { get; set; } = false;
            public string PersonName { get; set; }

        }


    }
}
