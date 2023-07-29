using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocietyManagementApi.Helper;
using SocietyManagementApi.IServices.IUser;
using SocietyManagementApi.Models;
using SocietyManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.Services.User
{
    public class UserService : IUser
    {
        #region Private Objects

        public readonly Society_ManagementContext _societyDbContext;
        private readonly IWebHostEnvironment _environment;

        #endregion

        #region CTOR
        public UserService(Society_ManagementContext societyDbContext, IWebHostEnvironment environment)
        {
            _societyDbContext = societyDbContext;
            _environment = environment;
        }

        #endregion

        #region Methods

        public Task<int> AddUser(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUser(int? userID)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewModel>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserByID(long userid)
        {
            var userbyID = _societyDbContext.UserMasters.FirstOrDefault(a => a.UserId == userid);
            UserMaster userMaster = new UserMaster();
            UserViewModel userViewModel = new UserViewModel
            {
                UserId = userMaster.UserId,
                FirstName = userMaster.FirstName,
                LastName = userMaster.LastName,
                EmailId = userMaster.EmailId,
                MobileNumber = userMaster.MobileNumber,

            };

            return userViewModel;
        }

        public UserViewModel Login(SignInModel model)
        {
            UserViewModel userViewModel = new UserViewModel();
            model.Password = EncodeDecodePassword.EncodePasswordToBase64(model.Password);
            var checkUser = _societyDbContext.UserMasters.FirstOrDefault(a => (a.EmailId.ToLower() == model.UserName.ToLower() || a.MobileNumber == model.UserName) && a.Password == model.Password);
            if (checkUser != null)
            {
                userViewModel.FirstName = checkUser.FirstName;
                userViewModel.LastName = checkUser.LastName;
                userViewModel.EmailId = checkUser.EmailId;
                userViewModel.UserId = checkUser.UserId;
                userViewModel.MobileNumber = checkUser.MobileNumber;
                userViewModel.TokenId = checkUser.TokenId;
                userViewModel.Imieno = checkUser.Imieno;
                userViewModel.Image = GeneralKey.BaseUrl + "Profile/" + checkUser.Image;
                return userViewModel;
            }
            return null;
        }
        public async Task<UserViewModel> SignUpAsync(UserViewModel userViewModel)
        {

            UserMaster userMaster = new UserMaster();
            userMaster.FirstName = userViewModel.FirstName;
            userMaster.LastName = userViewModel.LastName;
            userMaster.Imieno = userViewModel.Imieno;
            userMaster.EmailId = userViewModel.EmailId;
            userMaster.Password = EncodeDecodePassword.EncodePasswordToBase64(userViewModel.Password);
            userMaster.MobileNumber = userViewModel.MobileNumber;
            userMaster.TokenId = userViewModel.TokenId;
            userMaster.ActiveUser = 1;
            userMaster.SignUpdate = DateTime.Now;
            await _societyDbContext.UserMasters.AddAsync(userMaster);
            await _societyDbContext.SaveChangesAsync();
            userViewModel.UserId = userMaster.UserId;
            AddMember(userViewModel);
            return userViewModel;
        }

        public async Task<bool> AddMember(UserViewModel userViewModel)
        {

            MemberMaster memberMaster = new MemberMaster();
            memberMaster.Name = userViewModel.FirstName;
            memberMaster.SurName = userViewModel.LastName;
            //memberMaster.Type = Roles.Admin;
            memberMaster.Type = Roles.Guest;
            memberMaster.BillingName = userViewModel.FirstName;
            memberMaster.UserId = userViewModel.UserId;
            memberMaster.SocietyId = userViewModel.SocietyId>0? userViewModel.SocietyId:null;

            try
            {
                await _societyDbContext.MemberMasters.AddAsync(memberMaster);
                await _societyDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }

        public UserValidation CheckValidation(UserValidation model)
        {
            if (_societyDbContext.UserMasters.Any(a => a.EmailId == model.Email && a.UserId != model.UserId))
            {
                model.Status = false;
                model.Message = "Email id already exits";
                return model;
            }
            if (_societyDbContext.UserMasters.Any(a => a.MobileNumber == model.Mobile && a.UserId != model.UserId))
            {
                model.Status = false;
                model.Message = "Mobile number already exits";
                return model;
            }
            else
            {
                model.Status = true;
            }
            return model;
        }
        #endregion

        //public async Task SavePostImageAsync(UpdateViewModel userRequest)
        //{
        //    var uniqueFileName = FileHelper.GetUniqueFileName(userRequest.Image.FileName);
        //    var uploads = Path.Combine(_environment.WebRootPath, "Profile", userRequest.UserId.ToString());
        //    var filePath = Path.Combine(uploads, uniqueFileName);
        //    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        //    await userRequest.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
        //    userRequest.ImagePath = filePath;

        //    var user = GetUserById(userRequest.UserId);
        //    if (user != null)
        //    {
        //        user.Result.FirstName = userRequest.FirstName;
        //        user.Result.LastName = userRequest.LastName;
        //        user.Result.MobileNumber = userRequest.MobileNumber;
        //        //user.Result. = userRequest.FirstName;
        //    }
        //    return;
        //}
        public async Task<UserMaster> GetUserById(long userid)
        {
            return await _societyDbContext.UserMasters.Where(e => e.UserId == userid).FirstOrDefaultAsync();
        }
        public async Task<MemberMaster> GetMemberById(long userid, long societyid)
        {
            return await _societyDbContext.MemberMasters.Where(e => e.UserId == userid && e.Type==4 && e.SocietyId==null).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateRole(long userid,long societyid,int role)
        {
            var result =  GetMemberById(userid, societyid).Result;
            if (result != null)
            {
                result.Type= role;
                result.SocietyId = societyid;
                _societyDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<UpdateViewModel> UpdateUser(UpdateViewModel userViewModel)
        {
            UserMaster userMaster = new UserMaster();
            var user = _societyDbContext.UserMasters.Where(e => e.UserId == userViewModel.UserId).FirstOrDefault();
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.MobileNumber = userViewModel.MobileNumber;
            user.EmailId = userViewModel.Email;
            if (userViewModel.file!=null)
            {
                var imagename = await SavePostImageAsync(userViewModel);
                user.Image = imagename;
                userViewModel.Image = GeneralKey.BaseUrl + "Profile/" + imagename;
            }
            else
            {
                userViewModel.Image = GeneralKey.BaseUrl + "Profile/" + user.Image;

            }
            _societyDbContext.SaveChanges();
            userViewModel.file = null;
            return userViewModel;
        }

        public async Task<string> SavePostImageAsync(UpdateViewModel societyMasterViewModel)
        {

            var uniqueFileName = FileHelper.GetUniqueFileName(societyMasterViewModel.file.FileName);
            var uploads = Path.Combine(_environment.WebRootPath, "Profile", uniqueFileName);
            var filePath = Path.Combine(uploads, uniqueFileName);
            await societyMasterViewModel.file.CopyToAsync(new FileStream(uploads, FileMode.Create));
            societyMasterViewModel.Image = filePath;
            return uniqueFileName;

        }

        public async Task<bool> ForgotPasssword(ForgotPasswordModel model)
        {
            var result = await _societyDbContext.UserMasters.Where(a => a.MobileNumber == model.username || a.EmailId == model.username).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            else
            {
                if (model.type == 1)
                {

                    result.Otp = RendomKey.getrenadomkey();

                    NotificationService.SendCode("tpiodemo", "tpiodemo", "1707162080497255983", "Dear Customer, Verification code : " + result.Otp + " For Society Master Registration PS", "" + model.username + "", "T", "1707162080497255983", "1707162349864516298");

                    _societyDbContext.SaveChanges();
                }
                if (model.type == 2)
                {
                    Random rnd = new Random();
                    string randomNumber = (rnd.Next(100000, 999999)).ToString();
                    result.Otp = Convert.ToInt32(randomNumber);

                    NotificationService.SendMail("Dear Customer,Your Forgot Password Verification code Is : " + randomNumber, model.username);

                    _societyDbContext.SaveChanges();
                }
                return true;
            }
        }

        public async Task<int> ValidateOtp(int otp)
        {
            var result = _societyDbContext.UserMasters.Where(d => d.Otp == otp).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                return (int)result.UserId;

            }
        }
        public async Task<int> ResetPassword(ResetPasswordModel model)
        {
            var result = _societyDbContext.UserMasters.Where(d => d.UserId == model.UserId).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                result.Password = EncodeDecodePassword.EncodePasswordToBase64(model.Password); ;
                _societyDbContext.SaveChanges();
                return (int)result.UserId;
            }
        }

        public async Task<int> ChangePassword(ResetPasswordModel model)
        {
            model.OldPassword = EncodeDecodePassword.EncodePasswordToBase64(model.OldPassword);
            var result = _societyDbContext.UserMasters.Where(d => d.UserId == model.UserId && d.Password == model.OldPassword).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                result.Password = EncodeDecodePassword.EncodePasswordToBase64(model.Password);
                _societyDbContext.SaveChanges();
                return (int)result.UserId;
            }
        }

    }

}
