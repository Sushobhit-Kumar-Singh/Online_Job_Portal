using System;
using System.Collections.Generic;
using Job_Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal.Data;

public partial class JobPortalDbContext : DbContext
{
    public JobPortalDbContext()
    {
    }

    public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobCatogory> JobCatogories { get; set; }

    public virtual DbSet<JobEmployer> JobEmployers { get; set; }

    public virtual DbSet<JobJobApplication> JobJobApplications { get; set; }

    public virtual DbSet<JobJobListing> JobJobListings { get; set; }

    public virtual DbSet<JobJobSeeker> JobJobSeekers { get; set; }

    public virtual DbSet<JobSkill> JobSkills { get; set; }

    public virtual DbSet<JobUser> JobUsers { get; set; }

    public virtual DbSet<JobWorkExperience> JobWorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-A8AG81M8\\SQLEXPRESS;Initial Catalog=JobPortalDb; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobCatogory>(entity =>
        {
            entity.HasKey(e => e.JobCategoryId);

            entity.ToTable("JOB_catogory");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobEmployer>(entity =>
        {
            entity.HasKey(e => e.EmployerId);

            entity.ToTable("Job_Employer");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GstNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LogoURL");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PinCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobJobApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId);

            entity.ToTable("JOB_JobApplication");

            entity.Property(e => e.ApplcationStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AppliedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Job).WithMany(p => p.JobJobApplications)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JOB_JobApplication_JOB_JobListing");

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.JobJobApplications)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JOB_JobApplication_JOB_JobSeeker");
        });

        modelBuilder.Entity<JobJobListing>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("JOB_JobListing");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Experience)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobDescription)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.JobName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Package)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.JobJobListings)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_JOB_JobListing_JOB_catogory");
        });

        modelBuilder.Entity<JobJobSeeker>(entity =>
        {
            entity.HasKey(e => e.JobSeekerId);

            entity.ToTable("JOB_JobSeeker");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExperienceStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ResumeUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId);

            entity.ToTable("JOB_Skills");

            entity.Property(e => e.DurationOfSkill)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.JobSeekar).WithMany(p => p.JobSkills)
                .HasForeignKey(d => d.JobSeekarId)
                .HasConstraintName("FK_JOB_Skills_JOB_JobSeeker");
        });

        modelBuilder.Entity<JobUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("JOB_Users");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobWorkExperience>(entity =>
        {
            entity.HasKey(e => e.WorkExpId);

            entity.ToTable("JOB_WorkExperience");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.JobDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Profile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.JobWorkExperiences)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JOB_WorkExperience_JOB_JobSeeker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
