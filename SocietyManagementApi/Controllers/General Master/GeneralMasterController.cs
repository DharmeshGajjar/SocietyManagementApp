using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementApi.Helper;
using SocietyManagementApi.IServices.IGeneralMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.Controllers.General_Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralMasterController : ControllerBase
    {

       private IGeneralMaster igeneralMaster;
        public GeneralMasterController(IGeneralMaster _igeneralMaster)
        {
            igeneralMaster = _igeneralMaster;
        }

        [HttpGet]
        [Route("getstate")]
        public async Task<IActionResult> GetAllState()
        {
            try
            {
               
                var allstate = await igeneralMaster.GetAllState();
                if (allstate == null)
                {
                    return NotFound();
                }

                return Ok(new ApiResponse (true, GeneralKey.Success, allstate ));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getcitybystate")]
        public async Task<IActionResult> GetCityByState(int stateid)
        {
            try
            {
                var allcitybystate = await igeneralMaster.GetCityByState(stateid);
                if (allcitybystate == null)
                {
                    return NotFound();
                }

                return Ok(new ApiResponse(true, "Success", allcitybystate));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("getroomtype")]
        public async Task<IActionResult> GetRoomType()
        {
            try
            {
                var allcitybystate = await RoomType.getroomtype();
                if (allcitybystate == null)
                {
                    return NotFound();
                }

                return Ok(new ApiResponse(true, "Success", allcitybystate));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}