using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.GeneralMasterViewModel;

namespace SocietyManagementApi.Helper
{
    public class GeneralKey
    {
        public const string Success = "Success";
        public const string Error = "Error";
        public const string MobileNotExits = "Mobile no does not exits";
        public const string EmailNotExits = "Email id does not exits";
        public const string OtpMessage = "Otp send your mobile no please check message";
        public const string OtpInvalid = "Sorry, Your OTP is Invalid. Try again, please";
        public const string BaseUrl = "http://soc.pioerp.com/";

    }
    public class Roles
    {
        public const int Admin = 1;
        public const int Member = 2;
        public const int SecurityGuard = 3;
        public const int Guest = 4;
    }
    public class BlocksSetup
    {
        public static  string[] blocks = { "A", "B", "C", "C", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                           "N", "O", "P", "Q", "R", "S", "T" ,"U", "V", "W", "X", "Y", "Z",};
    }

    public class RoomType
    {
        public static async Task<List<RoomTypeModel>> getroomtype()
        {
            List<RoomTypeModel> obj = new List<RoomTypeModel>();
            obj.Add(new RoomTypeModel { Id = 1, Type = "Owner" });
            obj.Add(new RoomTypeModel { Id = 2, Type = "Tenent" });
            obj.Add(new RoomTypeModel { Id = 3, Type = "Closed" });
            obj.Add(new RoomTypeModel { Id = 4, Type = "Dead" });
            obj.Add(new RoomTypeModel { Id = 5, Type = "Shop" });
            return obj;
        }
       
    }
}
