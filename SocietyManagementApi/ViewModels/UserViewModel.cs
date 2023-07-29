using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocietyManagementApi.ViewModels
{
    public class UserViewModel
    {
        public long UserId { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string Password { get; set; }

       
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int? ActiveUser { get; set; }
       
        public string MobileNumber { get; set; }
       
        public string EmailId { get; set; }
        public string Imieno { get; set; }
        public string TokenId { get; set; }
        public int? Otp { get; set; }
        public int? Device { get; set; }
        public string DeviceName { get; set; }
        public double? AppVersion { get; set; }
        public DateTime? SignUpdate { get; set; }
        public DateTime? LastSeen { get; set; }
        public string Image { get; set; }
        public long SocietyId { get; set; }
    }
    public class UserValidation
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class SignInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class UpdateViewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public string Image { get; set; }

        public IFormFile file { get; set; }
    }

    public  class ResetPasswordModel
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
    }
    public class ForgotPasswordModel
    {
        public int type { get; set; }
        public string username { get; set; }
    }

}
