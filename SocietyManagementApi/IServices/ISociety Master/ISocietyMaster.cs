using SocietyManagementApi.Models;
using SocietyManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.SocietyViewModel;

namespace SocietyManagementApi.IServices.Society_Master
{
   public interface ISocietyMaster
    {
        public Task<List<BuildingViewModel>> GetBuildingType();
        Task<SocietyMasterResponseModel> AddUpdateSociety(SocietyMasterViewModel societyMasterViewModel);
        public List<SocietyMasterViewModel> GetAllSociety( int UserID);
        SocietyMasterViewModel GetSocietyByCode(int societycode);
        Task<int> DeleteSociety(int? societyId);
        Task UpdateSociety(SocietyMasterViewModel model);
        Task<List<BlockModel>> GetBlocks(long societyid);
        Task<string> AddUnits(BlockModel model);
       
        Task<List<UnitViewModel>> GetUnitByBlock(UnitFilterModel model);
        Task<bool> RequestToAdd(FlatNoRequestForBookingModel model);
        Task<List<FlatNoRequestForBookingModel>>  ViewRequest(FlatNoRequestForBookingModel model);
        Task<bool> AcceptRequest(FlatNoRequestForBookingModel model);
    }
}
