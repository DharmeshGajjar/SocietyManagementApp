using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SocietyManagementApi.Models
{
    public partial class Society_ManagementContext : DbContext
    {
        public Society_ManagementContext()
        {
        }

        public Society_ManagementContext(DbContextOptions<Society_ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApartmentType> ApartmentTypes { get; set; }
        public virtual DbSet<BlockMaster> BlockMasters { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<CityMaster> CityMasters { get; set; }
        public virtual DbSet<CliMst> CliMsts { get; set; }
        public virtual DbSet<ClientMaster> ClientMasters { get; set; }
        public virtual DbSet<CompanyMst> CompanyMsts { get; set; }
        public virtual DbSet<CompanyUserMapping> CompanyUserMappings { get; set; }
        public virtual DbSet<CompanyYearMapping> CompanyYearMappings { get; set; }
        public virtual DbSet<GenSetting> GenSettings { get; set; }
        public virtual DbSet<GridMst> GridMsts { get; set; }
        public virtual DbSet<GridShortTrn> GridShortTrns { get; set; }
        public virtual DbSet<GridTrn> GridTrns { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<MemberMaster> MemberMasters { get; set; }
        public virtual DbSet<MenuMst> MenuMsts { get; set; }
        public virtual DbSet<MnuMst> MnuMsts { get; set; }
        public virtual DbSet<ModuleMaster> ModuleMasters { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<SocietyMaster> SocietyMasters { get; set; }
        public virtual DbSet<StateMaster> StateMasters { get; set; }
        public virtual DbSet<UnitMaster> UnitMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<UserModuleMapping> UserModuleMappings { get; set; }
        public virtual DbSet<UserMst> UserMsts { get; set; }
        public virtual DbSet<YearMst> YearMsts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=144.91.71.201;Database=Society_Management;UID=PioSun;PWD=pio*123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentType>(entity =>
            {
                entity.HasKey(e => e.ApartmentId)
                    .HasName("PK_tblApartmentType");

                entity.ToTable("ApartmentType");

                entity.Property(e => e.ApartmentName).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlockMaster>(entity =>
            {
                entity.HasKey(e => e.BlockId);

                entity.ToTable("BlockMaster");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SocietyId).HasColumnName("SocietyID");

                entity.HasOne(d => d.Society)
                    .WithMany(p => p.BlockMasters)
                    .HasForeignKey(d => d.SocietyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockMaster_SocietyMaster");
            });

            modelBuilder.Entity<BuildingType>(entity =>
            {
                entity.ToTable("BuildingType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<CityMaster>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("CityMaster");

                entity.Property(e => e.CityName).HasMaxLength(25);

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CityMasters)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_StateMaster_CityMaster");
            });

            modelBuilder.Entity<CliMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CliMst");

                entity.Property(e => e.CliAdd).HasMaxLength(255);

                entity.Property(e => e.CliCd)
                    .HasMaxLength(5)
                    .HasColumnName("CliCD")
                    .IsFixedLength(true);

                entity.Property(e => e.CliCity)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.CliCper)
                    .HasMaxLength(30)
                    .HasColumnName("CliCPer");

                entity.Property(e => e.CliEmail).HasMaxLength(50);

                entity.Property(e => e.CliLogo).HasMaxLength(50);

                entity.Property(e => e.CliMob)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CliNm)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CliShNm)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.CliSplash).HasMaxLength(50);

                entity.Property(e => e.CliState)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.CliVou).HasColumnType("numeric(8, 0)");
            });

            modelBuilder.Entity<ClientMaster>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("ClientMaster");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.ContactPerson).HasMaxLength(30);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Splash).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(25);
            });

            modelBuilder.Entity<CompanyMst>(entity =>
            {
                entity.HasKey(e => e.CmpVou);

                entity.ToTable("CompanyMst");

                entity.Property(e => e.CmpCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CmpEndDt).HasColumnType("date");

                entity.Property(e => e.CmpName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CmpStDt).HasColumnType("date");
            });

            modelBuilder.Entity<CompanyUserMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CompanyUserMapping");

                entity.Property(e => e.Doc)
                    .HasColumnType("datetime")
                    .HasColumnName("DOC");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CompanyYearMapping>(entity =>
            {
                entity.ToTable("CompanyYearMapping");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Year).HasMaxLength(250);
            });

            modelBuilder.Entity<GenSetting>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GenEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenHost)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenInstId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GenInstID");

                entity.Property(e => e.GenPass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenSkruApi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GenSmtp).HasColumnName("GenSMTP");

                entity.Property(e => e.GenSurl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GenSURL");

                entity.Property(e => e.GenTokenId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GenTokenID");

                entity.Property(e => e.GenWhtMob)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GridMst>(entity =>
            {
                entity.HasKey(e => e.GrdVou);

                entity.ToTable("GridMst");

                entity.Property(e => e.GrdDate).HasColumnType("date");

                entity.Property(e => e.GrdDftYno).HasColumnName("GrdDftYNo");

                entity.Property(e => e.GrdMultiSelYn).HasColumnName("GrdMultiSelYN");

                entity.Property(e => e.GrdName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GrdQryFields).IsUnicode(false);

                entity.Property(e => e.GrdQryJoin).IsUnicode(false);

                entity.Property(e => e.GrdQryOrderBy).IsUnicode(false);

                entity.Property(e => e.GrdTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GrdType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrdUsrDt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PageSize).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<GridShortTrn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GridShortTrn");

                entity.Property(e => e.GrdBcolNm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdBColNm");

                entity.Property(e => e.GrdBdbFld)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdBDbFld");

                entity.Property(e => e.GrdBdefYn).HasColumnName("GrdBDefYN");

                entity.Property(e => e.GrdBgrdVou).HasColumnName("GrdBGrdVou");

                entity.Property(e => e.GrdBsrNo).HasColumnName("GrdBSrNo");

                entity.Property(e => e.GrdbVou).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GridTrn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GridTrn");

                entity.Property(e => e.CanGrow).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrdAalign).HasColumnName("GrdAAlign");

                entity.Property(e => e.GrdAcolNm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdAColNm");

                entity.Property(e => e.GrdAdataType).HasColumnName("GrdADataType");

                entity.Property(e => e.GrdAdbFld)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdADbFld");

                entity.Property(e => e.GrdAdbFld2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdADbFld2");

                entity.Property(e => e.GrdAdecUpTo).HasColumnName("GrdADecUpTo");

                entity.Property(e => e.GrdAgrdVou).HasColumnName("GrdAGrdVou");

                entity.Property(e => e.GrdAhideYn).HasColumnName("GrdAHideYN");

                entity.Property(e => e.GrdAlinkYn).HasColumnName("GrdALinkYN");

                entity.Property(e => e.GrdAnewColNm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdANewColNm");

                entity.Property(e => e.GrdAposition).HasColumnName("GrdAPosition");

                entity.Property(e => e.GrdAsrNo).HasColumnName("GrdASrNo");

                entity.Property(e => e.GrdAsuppressIfval)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrdASuppressIFVal");

                entity.Property(e => e.GrdAtotYn).HasColumnName("GrdATotYN");

                entity.Property(e => e.GrdAvou)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GrdAVou");

                entity.Property(e => e.GrdAwidth).HasColumnName("GrdAWidth");
            });

            modelBuilder.Entity<Layout>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Layout");

                entity.Property(e => e.RptDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RptReportNm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RptVou).ValueGeneratedOnAdd();

                entity.Property(e => e.RptVouType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MemberMaster>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("MemberMaster");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AltEmail).HasMaxLength(100);

                entity.Property(e => e.BillingAddress).HasMaxLength(50);

                entity.Property(e => e.BillingEmail).HasMaxLength(100);

                entity.Property(e => e.BillingName).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasMaxLength(20)
                    .HasColumnName("GSTNo");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OccupationType).HasMaxLength(50);

                entity.Property(e => e.PanNo).HasMaxLength(15);

                entity.Property(e => e.SocietyId).HasColumnName("SocietyID");

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.HasOne(d => d.Society)
                    .WithMany(p => p.MemberMasters)
                    .HasForeignKey(d => d.SocietyId)
                    .HasConstraintName("FK_MemberMaster_SocietyMaster");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MemberMasters)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMaster_MemberMaster");
            });

            modelBuilder.Entity<MenuMst>(entity =>
            {
                entity.HasKey(e => e.MnuVou);

                entity.ToTable("MenuMst");

                entity.Property(e => e.MnuName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MnuSubName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MnuMst>(entity =>
            {
                entity.HasKey(e => e.MnuVou);

                entity.ToTable("MnuMst");

                entity.Property(e => e.MnuVou).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MnuCd)
                    .HasMaxLength(6)
                    .HasColumnName("MnuCD")
                    .IsFixedLength(true);

                entity.Property(e => e.MnuDesc).HasMaxLength(50);

                entity.Property(e => e.MnuDpos).HasColumnName("MnuDPos");

                entity.Property(e => e.MnuIcon).HasMaxLength(50);

                entity.Property(e => e.MnuLink).HasMaxLength(50);

                entity.Property(e => e.MnuNm).HasMaxLength(50);

                entity.Property(e => e.MnuPmnuVou)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("MnuPMnuVou");
            });

            modelBuilder.Entity<ModuleMaster>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("ModuleMaster");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentFk).HasColumnName("ParentFK");
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.ToTable("PackageType");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PackageName).HasMaxLength(100);
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleType");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<SocietyMaster>(entity =>
            {
                entity.HasKey(e => e.SocietyId);

                entity.ToTable("SocietyMaster");

                entity.Property(e => e.SocietyId).HasColumnName("SocietyID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Gstno)
                    .HasMaxLength(15)
                    .HasColumnName("GSTNo");

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Language).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.PanNo).HasMaxLength(15);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.RegisterNo).HasMaxLength(20);

                entity.Property(e => e.RegisteredName).HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasMaxLength(25)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("StateMaster");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.StateName).HasMaxLength(25);
            });

            modelBuilder.Entity<UnitMaster>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("UnitMaster");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.BlockId).HasColumnName("BlockID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.SocietyId).HasColumnName("SocietyID");

                entity.Property(e => e.TenentId).HasColumnName("TenentID");

                entity.Property(e => e.UnitNo).HasMaxLength(5);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.UnitMasters)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitMaster_SocietyMaster");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserMaster");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Imieno)
                    .HasMaxLength(50)
                    .HasColumnName("IMIENO");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastSeen).HasColumnType("datetime");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Otp).HasColumnName("OTP");

                entity.Property(e => e.OtpCrtDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SignUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SignUPDate");

                entity.Property(e => e.TokenId)
                    .HasMaxLength(50)
                    .HasColumnName("TokenID");
            });

            modelBuilder.Entity<UserModuleMapping>(entity =>
            {
                entity.HasKey(e => e.UserModuleId);

                entity.ToTable("UserModuleMapping");
            });

            modelBuilder.Entity<UserMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserMst");

                entity.Property(e => e.UserActYn)
                    .HasMaxLength(5)
                    .HasColumnName("UserActYN")
                    .IsFixedLength(true);

                entity.Property(e => e.UserCd)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.Property(e => e.UserEmpNm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmpVou).HasColumnType("numeric(8, 0)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserMobNo).HasMaxLength(50);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserPhoto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserRolVou).HasColumnType("numeric(8, 0)");

                entity.Property(e => e.UserUseDt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserVou).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<YearMst>(entity =>
            {
                entity.HasKey(e => e.YearVou);

                entity.ToTable("YearMst");

                entity.Property(e => e.EndDt).HasColumnType("date");

                entity.Property(e => e.StartDt).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
