using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyManagementApi.IServices.IPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.Controllers.Payment_Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private IPayment ipayment;
        public PaymentController(IPayment _ipayment)
        {
            ipayment = _ipayment;
        }

        //[HttpGet]
        //[Route("Getpackage")]
        //public async Task<IActionResult> GetAllPackage()
        //{
        //    try
        //    {
        //        var allstate = await igeneralMaster.GetAllState();
        //        if (allstate == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(new ApiResponse(true, VeriableSetup.Success, allstate));
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //}

    }
}
