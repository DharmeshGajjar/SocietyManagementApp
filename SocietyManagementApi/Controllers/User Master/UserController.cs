using Microsoft.AspNetCore.Mvc;
using SocietyManagementApi.Helper;
using SocietyManagementApi.IServices.IUser;
using SocietyManagementApi.ViewModels;
using System;
using System.Threading.Tasks;


namespace SocietyManagementApi.Controllers.User_Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private Object

        private IUser iuserService;

        #endregion

        #region CTOR

        public UserController(IUser _iuserService)
        {
            iuserService = _iuserService;
        }
        #endregion

        #region Methods

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUP(UserViewModel userViewModel)
        {
            try
            {
                UserValidation model = new UserValidation();
                model.Email = userViewModel.EmailId;
                model.Mobile = userViewModel.MobileNumber;

                var checkValidation = iuserService.CheckValidation(model);
                if (checkValidation.Status)
                {
                    var userRegister = await iuserService.SignUpAsync(userViewModel);
                    return Ok(new ApiResponse(checkValidation.Status, GeneralKey.Success, userRegister));
                }
                else
                {
                    return Ok(new ApiResponse(checkValidation.Status, checkValidation.Message, userViewModel));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            try
            {
                var login = iuserService.Login(model);
                if (login == null)
                {
                    return Ok(new ApiResponse(false, "email/mobile number and password does not match", model));
                }
                else
                {
                    return Ok(new ApiResponse(true, "Login successfully", login));

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        [HttpPost]
        [Route("updateprofile")]
        public IActionResult UpdateProfile([FromForm] UpdateViewModel model)
        {
            try
            {

                UserValidation validateModel = new UserValidation();
                validateModel.UserId = model.UserId;
                validateModel.Email = model.Email;
                validateModel.Mobile = model.MobileNumber;

                var checkValidation = iuserService.CheckValidation(validateModel);
                if (checkValidation.Status)
                {

                    var login = iuserService.UpdateUser(model);
                    if (login == null)
                    {
                        return Ok(new ApiResponse(false, "Record could not be updated", model));
                    }
                    else
                    {
                        return Ok(new ApiResponse(true, "User profile updated successfully", login.Result));

                    }
                }
                else
                {
                    return Ok(new ApiResponse(checkValidation.Status, checkValidation.Message, validateModel));
                }


            }

            catch (Exception ex)
            {
                return BadRequest();

            }

        }

        [HttpGet]
        [Route("getUserByID")]
        public IActionResult getUserByID(int ID)
        {
             iuserService.GetUserByID(ID);
            return Ok(new ApiResponse(true, "success", ID));
        }
        //[HttpPut]
        //[Route("updateprofile")]
        //[RequestSizeLimit(5 * 1024 * 1024)]
        //public async Task<ActionResult> UpdateProfile(UpdateViewModel model)
        //{
        //    try
        //    {
        //        //await iuserService.UpdateUser(model);
        //        //return Ok(new ApiResponse(false, "Update successfull", model));
        //        var result = iuserService.UpdateUser(model);
        //        if (result == null)
        //        {
        //            return Ok(new ApiResponse(false, "Record could not be updated", model));
        //        }
        //        else
        //        {
        //            return Ok(new ApiResponse(true, "User updated successfully", result));

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        [Route("forgotpassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
           var result=await iuserService.ForgotPasssword(model);
            if (result == true)
            {
                return Ok(new ApiResponse(true, "success", GeneralKey.OtpMessage));

            }
            else
            {
                string message = model.type == 1 ? GeneralKey.MobileNotExits : GeneralKey.EmailNotExits;
                return Ok(new ApiResponse(false, message, message));
            }
           
        }
        [HttpGet]
        [Route("validateotp")]
        public async Task<ActionResult> ValidatOtp(int otp)
        {
            var result = await iuserService.ValidateOtp(otp);
            if (result >0)
            {
                return Ok(new ApiResponse(true, "Your otp is valid", result));
            }
            else
            {
                return Ok(new ApiResponse(false, GeneralKey.OtpInvalid, ""));
            }

        }

        [HttpPost]
        [Route("resetpassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            var result = await iuserService.ResetPassword(model);
            if (result > 0)
            {
                return Ok(new ApiResponse(true, "Your password reset successfully", result));
            }
            else
            {
                return Ok(new ApiResponse(false, "Something went wrongs", ""));
            }

        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<ActionResult> ChangePassword(ResetPasswordModel model)
        {
            var result = await iuserService.ChangePassword(model);
            if (result > 0)
            {
                return Ok(new ApiResponse(true, "Your password changed successfully", result));
            }
            else
            {
                return Ok(new ApiResponse(false, "Your old password is not valid", model));
            }

        }

        #endregion
    }
}
