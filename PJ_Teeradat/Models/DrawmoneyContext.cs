using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PJ_Teeradat.Models
{
    public partial class DrawmoneyContext : DbContext
    {
        public virtual DbSet<TbApprovalresults> TbApprovalresults { get; set; }
        public virtual DbSet<TbApprove> TbApprove { get; set; }
        public virtual DbSet<TbDepartment> TbDepartment { get; set; }
        public virtual DbSet<TbGender> TbGender { get; set; }
        public virtual DbSet<TbPosition> TbPosition { get; set; }
        public virtual DbSet<TbPrename> TbPrename { get; set; }
        public virtual DbSet<TbProvince> TbProvince { get; set; }
        public virtual DbSet<TbStatus> TbStatus { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<TbUsertype> TbUsertype { get; set; }
        public virtual DbSet<TbWithdraw> TbWithdraw { get; set; }

        public DrawmoneyContext(DbContextOptions<DrawmoneyContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=10.0.0.228,1433;Initial Catalog=Drawmoney;User ID = Cs19; Password = 123456");
                //optionsBuilder.UseSqlServer(@"Server=10.0.0.192,1433; Initial Catalog = Drawmoney; User ID = Cs19; Password = 123456");
                optionsBuilder.UseSqlServer(@"Data Source=(local)\TEERAPON;Initial Catalog=Drawmoney;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbApprovalresults>(entity =>
            {
                entity.HasKey(e => e.ApprovalResultsId);

                entity.ToTable("tb_approvalresults");

                entity.Property(e => e.ApprovalResultsId).HasColumnName("ApprovalResults_id");

                entity.Property(e => e.ApprovalResultsName)
                    .HasColumnName("ApprovalResults_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbApprove>(entity =>
            {
                entity.HasKey(e => e.ApproveId);

                entity.ToTable("tb_approve");

                entity.Property(e => e.ApproveId).HasColumnName("Approve_id");

                entity.Property(e => e.ApprovalResultsId).HasColumnName("ApprovalResults_id");

                entity.Property(e => e.DateApprove)
                    .HasColumnName("date_approve")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("Project_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.ApprovalResults)
                    .WithMany(p => p.TbApprove)
                    .HasForeignKey(d => d.ApprovalResultsId)
                    .HasConstraintName("FK_tb_approve_tb_approvalresults1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TbApprove)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tb_approve_tb_withdraw1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbApprove)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tb_approve_tb_user1");
            });

            modelBuilder.Entity<TbDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tb_department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("Department_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbGender>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("tb_gender");

                entity.Property(e => e.GenderId).HasColumnName("Gender_id");

                entity.Property(e => e.GenderName)
                    .HasColumnName("Gender_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("tb_position");

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.PositionName)
                    .HasColumnName("Position_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPrename>(entity =>
            {
                entity.HasKey(e => e.PrenameId);

                entity.ToTable("tb_prename");

                entity.Property(e => e.PrenameId).HasColumnName("Prename_id");

                entity.Property(e => e.PreName)
                    .HasColumnName("Pre_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProvince>(entity =>
            {
                entity.HasKey(e => e.ProvinceId);

                entity.ToTable("tb_province");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.ProvinceName)
                    .HasColumnName("province_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("tb_status");

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tb_user");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("Gender_id");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.PreNameId).HasColumnName("Pre_name_id");

                entity.Property(e => e.UserTypeId).HasColumnName("UserType_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tb_user_tb_department");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_tb_user_tb_gender");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_tb_user_tb_position");

                entity.HasOne(d => d.PreName)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.PreNameId)
                    .HasConstraintName("FK_tb_user_tb_prename");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TbUser)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_tb_user_tb_usertype");
            });

            modelBuilder.Entity<TbUsertype>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("tb_usertype");

                entity.Property(e => e.UserTypeId).HasColumnName("UserType_id");

                entity.Property(e => e.UserTypeName)
                    .HasColumnName("UserType_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbWithdraw>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("tb_withdraw");

                entity.Property(e => e.ProjectId).HasColumnName("Project_id");

                entity.Property(e => e.DateApplicant)
                    .HasColumnName("Date_applicant")
                    .HasColumnType("date");

                entity.Property(e => e.DateGo)
                    .HasColumnName("Date_go")
                    .HasColumnType("date");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .HasColumnName("Project_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId).HasColumnName("Province_id");

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TbWithdraw)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_tb_withdraw_tb_province");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TbWithdraw)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_tb_withdraw_tb_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbWithdraw)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tb_withdraw_tb_user");
            });
        }
    }
}
