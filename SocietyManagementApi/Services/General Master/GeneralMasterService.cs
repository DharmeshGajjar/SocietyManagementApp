using SocietyManagementApi.IServices.IGeneralMaster;
using SocietyManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.GeneralMasterViewModel;

namespace SocietyManagementApi.Services.General_Master
{
    public class GeneralMasterService : IGeneralMaster
    {
        #region Private Objects

        private Society_ManagementContext entity;

        #endregion

        #region CTOR
        public GeneralMasterService(Society_ManagementContext _entity)
        {
            entity = _entity;

        }

        #endregion

        #region Methods

        public async Task<List<StateMasterModel>> GetAllState()
        {
            if (entity != null)
            {
                var result = entity.StateMasters.Select(e => new StateMasterModel
                {
                    StateId = e.StateId,
                    StateName = e.StateName,
                    Code = e.Code
                }).ToList();
                return result;
            }

            return null;
        }

        public async Task<List<CityMasterModel>> GetCityByState(int stateid)
        {
            if (entity != null)
            {
                var result = entity.CityMasters.Where(e=>e.StateId==stateid).Select(e => new CityMasterModel
                {
                    CityId = e.CityId,
                    CityName = e.CityName,
                    Code = e.Code
                }).ToList();
                return result;
            }

            return null;
        }

        #endregion


    }
}
