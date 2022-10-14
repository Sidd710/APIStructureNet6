using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElectionCampaignBackEnd2.Model
{
    public partial class ElectionCampaignContext : DbContext
    {
        public ElectionCampaignContext()
        {
        }

        public ElectionCampaignContext(DbContextOptions<ElectionCampaignContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllocatedEmployee> AllocatedEmployees { get; set; } = null!;
        public virtual DbSet<AssignEmployee> AssignEmployees { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Constituency> Constituencies { get; set; } = null!;
        public virtual DbSet<EmployeeVillageMapping> EmployeeVillageMappings { get; set; } = null!;
        public virtual DbSet<GetAllAttendanceDetail> GetAllAttendanceDetails { get; set; } = null!;
        public virtual DbSet<GetAllAttendanceDetailsWithWorkingHour> GetAllAttendanceDetailsWithWorkingHours { get; set; } = null!;
        public virtual DbSet<GetAllEmployeeDetail> GetAllEmployeeDetails { get; set; } = null!;
        public virtual DbSet<GetAssignedEmployeeDetail> GetAssignedEmployeeDetails { get; set; } = null!;
        public virtual DbSet<GetAssignedEmployeeList> GetAssignedEmployeeLists { get; set; } = null!;
        public virtual DbSet<GetVoterDetail> GetVoterDetails { get; set; } = null!;
        public virtual DbSet<LeadDetail> LeadDetails { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<UnAllocatedEmployee> UnAllocatedEmployees { get; set; } = null!;
        public virtual DbSet<UnAllocatedManager> UnAllocatedManagers { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<Village> Villages { get; set; } = null!;
        public virtual DbSet<VoterDetail> VoterDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=144.91.125.241;Database=ElectionCampaign;user=samarthApi;password=samarthApi@2020;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllocatedEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AllocatedEmployee");

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AssignEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeAssignId);

                entity.ToTable("AssignEmployee");

                entity.HasOne(d => d.AllocatedEmployee)
                    .WithMany(p => p.AssignEmployeeAllocatedEmployees)
                    .HasForeignKey(d => d.AllocatedEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignEmployee_UserDetails");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.AssignEmployeeManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssignEmployee_UserDetails1");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOut)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Attendance_UserDetails");
            });

            modelBuilder.Entity<Constituency>(entity =>
            {
                entity.ToTable("Constituency");

                entity.Property(e => e.ConstituencyName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Constituencies)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Constituency_State1");
            });

            modelBuilder.Entity<EmployeeVillageMapping>(entity =>
            {
                entity.ToTable("EmployeeVillageMapping");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeVillageMappings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVillageMapping_UserDetails");

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.EmployeeVillageMappings)
                    .HasForeignKey(d => d.VillageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeVillageMapping_Village");
            });

            modelBuilder.Entity<GetAllAttendanceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAllAttendanceDetails");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOut)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GetAllAttendanceDetailsWithWorkingHour>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAllAttendanceDetailsWithWorkingHour");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOut)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkingHours)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Working Hours");
            });

            modelBuilder.Entity<GetAllEmployeeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAllEmployeeDetails");

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConstituencyName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VillageId)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.VillageName)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GetAssignedEmployeeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAssignedEmployeeDetails");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GetAssignedEmployeeList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAssignedEmployeeList");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GetVoterDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetVoterDetails");

                entity.Property(e => e.ConstituencyName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gpslocation)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GPSLocation");

                entity.Property(e => e.Influencer)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastVoted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NameofHeadofFamily)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NegNeuPositive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoofVotersInHh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProxyQuestions).IsUnicode(false);

                entity.Property(e => e.SubscribetoWhatsappGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VillageName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VoterIdGenerator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoterName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WhoisanInfluencer)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeadDetail>(entity =>
            {
                entity.HasKey(e => e.LeadId);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeadDetailEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeadDetails_UserDetails");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.LeadDetailManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeadDetails_UserDetails1");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnAllocatedEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UnAllocatedEmployee");

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnAllocatedManager>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UnAllocatedManager");

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLoginCurrentDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Constitution)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.ConstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDetails_Constituency");
            });

            modelBuilder.Entity<Village>(entity =>
            {
                entity.ToTable("Village");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VillageName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Constituency)
                    .WithMany(p => p.Villages)
                    .HasForeignKey(d => d.ConstituencyId)
                    .HasConstraintName("FK_Village_Constituency");
            });

            modelBuilder.Entity<VoterDetail>(entity =>
            {
                entity.HasKey(e => e.VoterId);

                entity.Property(e => e.VoterId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gpslocation)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GPSLocation");

                entity.Property(e => e.Influencer)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastVoted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameofHeadofFamily)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NegNeuPositive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoofVotersInHh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NoofVotersInHH");

                entity.Property(e => e.ProxyQuestions).IsUnicode(false);

                entity.Property(e => e.SubscribetoWhatsappGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoterIdGenerator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoterName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsappNoofHof).HasColumnName("WhatsappNoofHOF");

                entity.Property(e => e.WhoisanInfluencer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Constituency)
                    .WithMany(p => p.VoterDetails)
                    .HasForeignKey(d => d.ConstituencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoterDetails_Constituency");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.VoterDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoterDetails_UserDetails");

                entity.HasOne(d => d.Voter)
                    .WithOne(p => p.VoterDetail)
                    .HasForeignKey<VoterDetail>(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoterDetails_Village");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
