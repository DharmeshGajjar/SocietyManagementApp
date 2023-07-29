using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementApi.Helper;
using SocietyManagementApi.IServices.IUser;
using SocietyManagementApi.IServices.Society_Master;
using SocietyManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.SocietyViewModel;

namespace SocietyManagementApi.Controllers.Society_Master
{
    [Route("api/[controller]")]
    [ApiController]

    public class SocietyController : ControllerBase
    {


        private ISocietyMaster isocietyMaster;
        private IUser iuserService;
        public SocietyController(ISocietyMaster _isocietyMaster, IUser _iuserService)
        {
            isocietyMaster = _isocietyMaster;
            iuserService = _iuserService;
        }

        [HttpGet]
        [Route("getbuildingtype")]
        public async Task<IActionResult> GetBuildingType()
        {
            try
            {

                var allstate = await isocietyMaster.GetBuildingType();
                if (allstate == null)
                {
                    return NotFound();
                }

                return Ok(new ApiResponse(true, GeneralKey.Success, allstate));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("addupdatesociety")]
        public async Task<IActionResult> AddUpdateSociety([FromForm] SocietyMasterViewModel societymodel)
        {
            try
            {
                long userid = societymodel.UserId;

                var result = isocietyMaster.AddUpdateSociety(societymodel).Result;
                if (result != null)
                {
                    if (societymodel.SocietyId == 0)
                    {
                        bool role = await iuserService.UpdateRole(userid, result.SocietyId, Roles.Admin);
                    }
                }

                UserValidation model = new UserValidation();
                model.Email = societymodel.UEmail;
                model.Mobile = societymodel.UMobile;
                UserViewModel user = new UserViewModel();
                if (!string.IsNullOrEmpty(model.Email) || !string.IsNullOrEmpty(model.Mobile))
                {
                    var checkValidation = iuserService.CheckValidation(model);

                    if (checkValidation.Status)
                    {

                        user.FirstName = societymodel.UFirstNme;
                        user.LastName = societymodel.ULastNme;
                        user.EmailId = societymodel.UEmail;
                        user.MobileNumber = societymodel.UMobile;
                        user.Password = societymodel.UPassword;
                        user.SocietyId = result.SocietyId;
                        var userRegister = await iuserService.SignUpAsync(user);

                    }
                    else
                    {
                        return Ok(new ApiResponse(checkValidation.Status, checkValidation.Message, user));
                    }
                }

                return Ok(new ApiResponse(true, "Society add successfully", result));

            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }

        [HttpGet]
        [Route("getallsociety")]
        public async Task<IActionResult> GetAllSociety(int userid)
        {
            try
            {

                var allSociety = isocietyMaster.GetAllSociety(userid);
                return Ok(new ApiResponse(true, GeneralKey.Success, allSociety));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getsocietybycode")]
        public async Task<IActionResult> GetSocietyByCode(int code = 0)
        {
            try
            {
                if (code > 0)
                {
                    var allSociety = isocietyMaster.GetSocietyByCode(code);
                    if (allSociety == null)
                        return Ok(new ApiResponse(false, "Please provide valid code", ""));

                    return Ok(new ApiResponse(true, GeneralKey.Success, allSociety));
                }
                else
                {
                    return Ok(new ApiResponse(false, "Please provide valid code", ""));
                }

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, "Please provide valid code", ""));
            }

        }

        [HttpGet]
        [Route("deletesociety")]
        public async Task<IActionResult> DeleteSociety(int societyid)
        {

            try
            {
                if (societyid == 0)
                {
                    return Ok(new ApiResponse(false, "Please provide society id", "Please provide society id"));
                }
                else
                {
                    await isocietyMaster.DeleteSociety(societyid);
                    return Ok(new ApiResponse(true, "Society deleted successfully", "Society deleted successfully"));
                }


            }
            catch (Exception ex)
            {

                return Ok(new ApiResponse(false, "Something went to wrong", "Something went to wrong"));
            }
        }
        [HttpPut]
        [Route("UpdateSociety")]
        public async Task<IActionResult> UpdatePost([FromForm] SocietyMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await isocietyMaster.UpdateSociety(model);

                    return (IActionResult)model;
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("getblocks")]
        public async Task<IActionResult> GetALlBlocks(int societyid)
        {
            try
            {

                var allblocks = await isocietyMaster.GetBlocks(societyid);
                if (allblocks == null)
                {
                    return Ok(new ApiResponse(false, "Something went to wrong", "Something went to wrong"));
                }

                return Ok(new ApiResponse(true, GeneralKey.Success, allblocks));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("addblockunit")]
        public IActionResult AddBlockUnit(BlockModel model)
        {
            try
            {

                var result = isocietyMaster.AddUnits(model).Result;
                return Ok(new ApiResponse(true, result, result));

            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }
        [HttpPost]
        [Route("getunits")]
        public async Task<IActionResult> GetAllUnits(UnitFilterModel model)
        {
            try
            {

                var allblocks = await isocietyMaster.GetUnitByBlock(model);
                if (allblocks == null)
                {
                    return Ok(new ApiResponse(false, "Something went to wrong", "Something went to wrong"));
                }

                return Ok(new ApiResponse(true, GeneralKey.Success, allblocks));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("requesttojoinsociety")]
        public async Task<IActionResult> RequestToJoinSociety(FlatNoRequestForBookingModel model)
        {
            try
            {
                long userid = model.OwnerId > 0 ? model.OwnerId : model.TenentID;
                var result = isocietyMaster.RequestToAdd(model).Result;
                if (result == false)
                {
                    return Ok(new ApiResponse(false, "Flat no not found", ""));
                }
                else
                {
                    if (result == true)
                    {
                        bool role = await iuserService.UpdateRole(userid, model.SocietyId,Roles.Member);
                    }

                    return Ok(new ApiResponse(true, "Request sent to admin successully for join society.", model));
                }

            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }

        [HttpPost]
        [Route("viewmembers")]
        public IActionResult ViewMembersRequest(FlatNoRequestForBookingModel model)
        {
            try
            {

                var result = isocietyMaster.ViewRequest(model).Result;
                if (result == null)
                {
                    return Ok(new ApiResponse(false, "Data not found", ""));
                }
                else
                {
                    return Ok(new ApiResponse(true, "Success", result));
                }

            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }
        [HttpPost]
        [Route("acceptmemberrequest")]
        public IActionResult AccpetMemberRequest(FlatNoRequestForBookingModel model)
        {
            try
            {

                var result = isocietyMaster.AcceptRequest(model).Result;
                if (result == false)
                {
                    return Ok(new ApiResponse(false, "Flat no not found", ""));
                }
                else
                {
                    return Ok(new ApiResponse(true, "Request accept by admin successully", model));
                }

            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }
    }
}
