using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocietyManagementApi.Helper;
using SocietyManagementApi.IServices.Society_Master;
using SocietyManagementApi.Models;
using SocietyManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static SocietyManagementApi.ViewModels.SocietyViewModel;

namespace SocietyManagementApi.Services.Society_Master
{
    public class SocietyMasterService : ISocietyMaster
    {
        #region Private Objects

        private Society_ManagementContext entity;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region CTOR
        public SocietyMasterService(Society_ManagementContext _entity, IWebHostEnvironment webHostEnvironment)
        {
            entity = _entity;
            _webHostEnvironment = webHostEnvironment;

        }
        //public BuildingTypeService(IWebHostEnvironment webHostEnvironment)
        //{
        //    _webHostEnvironment = webHostEnvironment;
        //}

        #endregion
        public Task<List<BuildingViewModel>> GetBuildingType()
        {

            if (entity != null)
            {
                var result = entity.BuildingTypes.Select(e => new BuildingViewModel
                {
                    Id = e.Id,
                    TypeName = e.TypeName,
                }).ToList();
                return Task.FromResult(result);
            }

            return null;

        }

        public async Task<SocietyMasterResponseModel> AddUpdateSociety(SocietyMasterViewModel societymodel)
        {

            SocietyMaster societyMaster = new SocietyMaster();
            if (societymodel.SocietyId > 0)
                societyMaster = entity.SocietyMasters.Find(societymodel.SocietyId);

            societyMaster.RegisteredName = societymodel.RegisteredName;
            societyMaster.Name = societymodel.Name;
            societyMaster.Code = RendomKey.getrenadomkey();
            societyMaster.Address = societymodel.Address;
            societyMaster.State = societymodel.State;
            societyMaster.City = societymodel.City;
            societyMaster.BlockCount = societymodel.BlockCount;
            societyMaster.Units = societymodel.Units;
            societyMaster.ClientId = 1;
            if (societymodel.file != null)
            {
                var imagename = await SavePostImageAsync(societymodel);
                societyMaster.Image = imagename;
            }

            if (societymodel.SocietyId > 0)
            {

                societyMaster.MobileNumber = societymodel.MobileNumber;
                societyMaster.EmailId = societymodel.EmailId;
                societyMaster.PinCode = societymodel.PinCode;
                societyMaster.ClientId = 1;
                societyMaster.Language = societymodel.Language;
                societyMaster.PanNo = societymodel.PanNo;
                societyMaster.Gstno = societymodel.Gstno;
                societyMaster.IsActive = true;

                societyMaster.MobileNumber = societymodel.MobileNumber;
            }
            if (societymodel.SocietyId == 0)
            {
                await entity.SocietyMasters.AddAsync(societyMaster);
                await entity.SaveChangesAsync();


            }
            else
                await entity.SaveChangesAsync();
            if (societymodel.SocietyId == 0)
            {
                AddBlocks(societymodel.BlockCount, societyMaster.SocietyId);
            }
            societymodel.SocietyId = societyMaster.SocietyId;


            return Convertor(societymodel);
        }

        public void AddBlocks(int? totalblocks, long societyid)
        {
            List<BlockMaster> _objblock = new List<BlockMaster>();
            if (totalblocks > 0)
            {
                for (int i = 0; i < totalblocks; i++)
                {
                    _objblock.Add(new BlockMaster { Name = BlocksSetup.blocks[i].ToString(), DisplayPosition = i, SocietyId = societyid });
                }
                if (_objblock.Count > 0)
                {
                    entity.BlockMasters.AddRange(_objblock);
                    entity.SaveChanges();
                }
            }
        }

        public Task<List<BlockModel>> GetBlocks(long societyid)
        {

            if (entity != null)
            {
                var result = entity.BlockMasters.Where(r => r.SocietyId == societyid).Select(e => new BlockModel
                {
                    BlockId = e.BlockId,
                    SocietyId = e.SocietyId,
                    Name = e.Name,
                }).ToList();
                return Task.FromResult(result);
            }

            return null;

        }

        public async Task<string> AddUnits(BlockModel model)
        {
            string message = "Recors saved successfully";
            List<UnitMaster> objunit = new List<UnitMaster>();
            var getallflatno = model.lstUnitModel.Select(t => t.UnitNo).ToList();

            var checkrommexitsornot = entity.UnitMasters.Where(r => getallflatno.Contains(r.UnitNo) && r.BlockId == model.BlockId && r.SocietyId == model.SocietyId).Select(e => e.UnitNo).ToList();

            var filterflatno = model.lstUnitModel.Where(e => !checkrommexitsornot.Contains(e.UnitNo)).ToList();
            if (filterflatno.Count > 0)
            {
                foreach (var item in filterflatno)
                {

                    objunit.Add(new UnitMaster
                    {
                        BlockId = item.BlockId,
                        SocietyId = item.SocietyId,
                        FloorNo = item.FloorNo,
                        RoomType = item.RoomType,
                        UnitNo = item.UnitNo
                    });

                }
            }
            if (checkrommexitsornot.Count > 0)
            {
                message = "This flat no already exits :- ";
                foreach (var flat in checkrommexitsornot)
                {
                    message += flat + ", ";
                }
            }
            if (objunit.Count > 0)
            {
                await entity.UnitMasters.AddRangeAsync(objunit);
                await entity.SaveChangesAsync();
            }
            var checkBlock = entity.BlockMasters.Where(e => e.SocietyId == model.SocietyId && e.BlockId == model.BlockId).FirstOrDefault();
            if (checkBlock != null)
            {
                checkBlock.TotalFloor = model.TotalFloor;
                checkBlock.TotalFlatPerFloor = model.TotalFlatPerFloor;
                checkBlock.BlockFormate = model.BlockFormate;
                entity.SaveChanges();
            }

            return message;

        }
        public async Task<bool> RequestToAdd(FlatNoRequestForBookingModel model)
        {
            var checkUnitExitsOrNot = await entity.UnitMasters.Where(e => e.SocietyId == model.SocietyId && e.BlockId == model.BlockId && e.UnitId == model.UnitNo).FirstOrDefaultAsync();
            if (checkUnitExitsOrNot == null)
            {
                return false;
            }
            else
            {
                checkUnitExitsOrNot.OwnerId = model.OwnerId;
                checkUnitExitsOrNot.TenentId = model.TenentID;
                checkUnitExitsOrNot.Status = false;
                entity.SaveChanges();
            }

            return true;

        }

        public async Task<List<FlatNoRequestForBookingModel>> ViewRequest(FlatNoRequestForBookingModel model)
        {
            var members = await entity.UnitMasters.Where(e => e.SocietyId == model.SocietyId && e.BlockId == model.BlockId && e.Status == model.Status)
                .ToListAsync();
            var ownerid = members.Select(e => e.OwnerId).ToList();
            var TenentId = members.Select(e => e.TenentId).ToList();

            var allmember = await entity.MemberMasters.Where(r => ownerid.Contains(r.MemberId) || TenentId.Contains(r.MemberId)).Select(e => new FlatNoRequestForBookingModel
            {
                BlockId = model.BlockId,
                BlockName = model.BlockName,
                UnitNo = model.UnitNo,
                PersonName = e.Name + " " + e.SurName,
            }).ToListAsync();
            return allmember;



        }

        public async Task<bool> AcceptRequest(FlatNoRequestForBookingModel model)
        {
            var checkUnitExitsOrNot = await entity.UnitMasters.Where(e => e.SocietyId == model.SocietyId && e.BlockId == model.BlockId && e.UnitId == model.UnitNo).FirstOrDefaultAsync();
            if (checkUnitExitsOrNot == null)
            {
                return false;
            }
            else
            {
                checkUnitExitsOrNot.Status = true;
            }

            return true;

        }
        public async Task<List<UnitViewModel>> GetUnitByBlock(UnitFilterModel model)
        {

            if (entity != null)
            {
                var result = entity.UnitMasters.Where(t => t.SocietyId == model.SocietyId && t.BlockId == model.BlockId).Select(e => new UnitViewModel
                {
                    UnitId=e.UnitId,
                    BlockId = e.BlockId,
                    SocietyId = e.SocietyId,
                    FloorNo = e.FloorNo,
                    Status = e.Status,
                    UnitNo = e.UnitNo,
                    RoomType = e.RoomType
                }).ToList();
                return result;
            }

            return null;

        }
        public SocietyMasterResponseModel Convertor(SocietyMasterViewModel model)
        {
            SocietyMasterResponseModel responsemodel = new SocietyMasterResponseModel();

            responsemodel.RegisteredName = model.RegisteredName;
            responsemodel.Name = model.Name;
            responsemodel.Code = model.Code;
            responsemodel.Address = model.Address;
            responsemodel.State = model.State;
            responsemodel.City = model.City;
            responsemodel.BlockCount = model.BlockCount;
            responsemodel.Units = model.Units;
            responsemodel.ClientId = 1;
            responsemodel.Image = GeneralKey.BaseUrl + "Society/" + model.Image;
            responsemodel.SocietyId = model.SocietyId;
            return responsemodel;
        }

        public async Task<string> SavePostImageAsync(SocietyMasterViewModel societyMasterViewModel)
        {

            var uniqueFileName = FileHelper.GetUniqueFileName(societyMasterViewModel.file.FileName);
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Society", uniqueFileName);
            var filePath = Path.Combine(uploads, uniqueFileName);
            await societyMasterViewModel.file.CopyToAsync(new FileStream(uploads, FileMode.Create));
            societyMasterViewModel.Image = filePath;
            return uniqueFileName;
        }

        public List<SocietyMasterViewModel> GetAllSociety(int UserID)
        {
            if (entity != null)
            {
                var societyIds = entity.MemberMasters.Where(e => e.UserId == UserID).Select(r => r.SocietyId).ToList();

                var listofSociety = entity.SocietyMasters.Include(r=>r.BlockMasters).Where(e => societyIds.Contains(e.SocietyId)).ToList();
                var result = listofSociety.Select(e => new SocietyMasterViewModel
                {
                    SocietyId = e.SocietyId,
                    Name = e.Name,
                    Code = e.Code,
                    Address = e.Address,
                    State = e.State,
                    MobileNumber = e.MobileNumber,
                    EmailId = e.EmailId,
                    City = e.City,
                    PinCode = e.PinCode,
                    ClientId = e.ClientId,
                    BlockCount = e.BlockCount,
                    Units = e.Units,
                    Language = e.Language,
                    RegisteredName = e.RegisteredName,
                    PanNo = e.PanNo,
                    Gstno = e.Gstno,
                    Image = GeneralKey.BaseUrl + "Society/" + e.Image,
                    lstBlockList = e.BlockMasters.Count > 0 ? e.BlockMasters.Select(r => new BlockModel
                    {
                        Name = r.Name,
                        BlockId=r.BlockId,
                        SocietyId=r.SocietyId,
                        TotalFloor=r.TotalFloor,
                       TotalFlatPerFloor=r.TotalFlatPerFloor,
                       BlockFormate=r.BlockFormate
                    }).ToList():null

                }).ToList();

                return result;
            }

            return null;
        }

        public SocietyMasterViewModel GetSocietyByCode(int societycode)
        {
            if (entity != null)
            {

                var result = entity.SocietyMasters.Where(e => e.Code == societycode).Select(e => new SocietyMasterViewModel
                {
                    SocietyId = e.SocietyId,
                    Name = e.Name,
                    Code = e.Code,
                    Address = e.Address,
                    State = e.State,
                    MobileNumber = e.MobileNumber,
                    EmailId = e.EmailId,
                    City = e.City,
                    PinCode = e.PinCode,
                    ClientId = e.ClientId,
                    BlockCount = e.BlockCount,
                    Units = e.Units,
                    Language = e.Language,
                    RegisteredName = e.RegisteredName,
                    PanNo = e.PanNo,
                    Gstno = e.Gstno,
                    Image = GeneralKey.BaseUrl + "Society/" + e.Image,
                    lstBlockList = e.BlockMasters.Count > 0 ? e.BlockMasters.Select(r => new BlockModel
                    {
                        Name = r.Name,
                        BlockId = r.BlockId,
                        SocietyId = r.SocietyId,
                        TotalFloor = r.TotalFloor,
                        TotalFlatPerFloor = r.TotalFlatPerFloor,
                        BlockFormate = r.BlockFormate
                    }).ToList():null

                }).FirstOrDefault();

                return result;
            }

            return null;
        }

        public Task<int> DeleteSociety(int? societyId)
        {
            int result = 0;
            if (entity != null)
            {

                //  var employess = from soc in entity.SocietyMasters
                //                join bl in entity.BlockMasters
                //                on soc.SocietyId equals bl.SocietyId
                //                join un in entity.UnitMasters
                //                on bl.BlockId equals un.BlockId
                //                where societyId == soc.SocietyId
                //                select soc;



                //// if (company == null)
                ////  return "Company cannot be found";
                //entity.SocietyMasters.RemoveRange(employess);
                //entity.SaveChanges();

                var society = entity.SocietyMasters.Where(e => e.SocietyId == societyId)
                    .Include(r=>r.MemberMasters)
                    .Include(e => e.BlockMasters)
                    .ThenInclude(e => e.UnitMasters)
                    .FirstOrDefault();

                foreach (var item in society.BlockMasters)
                {
                    entity.UnitMasters.RemoveRange(item.UnitMasters);
                    result = entity.SaveChanges();
                }
                if (society.BlockMasters.Count > 0)
                {
                    entity.BlockMasters.RemoveRange(society.BlockMasters);
                    result = entity.SaveChanges();
                }
                if (society.MemberMasters.Count > 0)
                {
                    foreach (var item in society.MemberMasters)
                    {
                        item.SocietyId = null;
                        item.Type = Roles.Guest;
                        entity.SaveChanges();

                    }
                }
                entity.SocietyMasters.RemoveRange(society);
                result = entity.SaveChanges();
                return Task.FromResult(result);
            }
            return Task.FromResult(result);
        }


        public async Task UpdateSociety(SocietyMasterViewModel societyMasterViewModel)
        {
            SocietyMaster societyMaster = new SocietyMaster();
            if (entity != null)
            {
                societyMaster.SocietyId = societyMasterViewModel.SocietyId;
                societyMaster.RegisteredName = societyMasterViewModel.RegisteredName;
                societyMaster.ClientId = societyMasterViewModel.ClientId;
                societyMaster.Name = societyMasterViewModel.Name;
                societyMaster.Code = societyMasterViewModel.Code;
                societyMaster.Address = societyMasterViewModel.Address;
                societyMaster.State = societyMasterViewModel.State;
                societyMaster.MobileNumber = societyMasterViewModel.MobileNumber;
                societyMaster.EmailId = societyMasterViewModel.EmailId;
                societyMaster.City = societyMasterViewModel.City;
                societyMaster.PinCode = societyMasterViewModel.PinCode;

                societyMaster.BlockCount = societyMasterViewModel.BlockCount;
                societyMaster.Units = societyMasterViewModel.Units;
                societyMaster.Language = societyMasterViewModel.Language;
                societyMaster.RegisteredName = societyMasterViewModel.RegisteredName;
                societyMaster.PanNo = societyMasterViewModel.PanNo;
                societyMaster.Gstno = societyMasterViewModel.Gstno;
                societyMaster.IsActive = true;
                var imagename = await SavePostImageAsync(societyMasterViewModel);
                societyMaster.Image = imagename;
                societyMaster.MobileNumber = societyMasterViewModel.MobileNumber;
                entity.Entry(societyMaster).State = EntityState.Modified;



                await entity.SaveChangesAsync();
            }
        }
    }

}


