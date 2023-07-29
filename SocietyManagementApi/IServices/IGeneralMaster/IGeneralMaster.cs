using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.GeneralMasterViewModel;

namespace SocietyManagementApi.IServices.IGeneralMaster
{
   public interface IGeneralMaster
    {
        Task<List<StateMasterModel>> GetAllState();
        Task<List<CityMasterModel>> GetCityByState(int stateid);
    }
}
