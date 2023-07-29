using Microsoft.AspNetCore.Identity;
using SocietyManagementApi.Models;
using SocietyManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.IServices.IUser
{
    public interface IUser
    {
        //Task<int> SignUpAsync(UserMaster userMaster);

        public Task<List<UserViewModel>> GetAllUsers();


        public UserViewModel GetUserByID(long userID);


        Task<int> AddUser(UserViewModel userViewModel);

        Task<int> DeleteUser(int? userID);
        Task<UserViewModel> SignUpAsync(UserViewModel userViewModel);

        UserViewModel Login(SignInModel model);
        UserValidation CheckValidation(UserValidation model);

        Task<UpdateViewModel> UpdateUser(UpdateViewModel model);
        Task<bool> ForgotPasssword(ForgotPasswordModel model);
        Task<int> ValidateOtp(int otp);
        Task<int> ResetPassword(ResetPasswordModel model);
        Task<int> ChangePassword(ResetPasswordModel model);
        Task<bool> UpdateRole(long userid, long societyid,int role);
    }

}

