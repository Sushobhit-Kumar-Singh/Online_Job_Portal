﻿// <auto-generated />
using System;
using Job_Portal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Job_Portal.Migrations
{
    [DbContext(typeof(JobPortalDbContext))]
    partial class JobPortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Job_Portal.Models.JobCatogory", b =>
                {
                    b.Property<int>("JobCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobCategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("JobCategoryId");

                    b.ToTable("JOB_catogory", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobEmployer", b =>
                {
                    b.Property<int>("EmployerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployerId"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CompanyAddress")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GstNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("LogoURL");

                    b.Property<string>("MobileNo")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PinCode")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("EmployerId");

                    b.ToTable("Job_Employer", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobApplication", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"));

                    b.Property<string>("ApplcationStatus")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("AppliedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.HasIndex("JobId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JOB_JobApplication", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobListing", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<string>("Experience")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("JobName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Package")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("JobId");

                    b.HasIndex("CategoryId");

                    b.ToTable("JOB_JobListing", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobSeeker", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobSeekerId"));

                    b.Property<string>("EmailId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ExperienceStatus")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MobileNo")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ResumeUrl")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("JobSeekerId");

                    b.ToTable("JOB_JobSeeker", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobSkill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("DurationOfSkill")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("JobSeekarId")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("SkillId");

                    b.HasIndex("JobSeekarId");

                    b.ToTable("JOB_Skills", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int?>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserRole")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("JOB_Users", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobWorkExperience", b =>
                {
                    b.Property<int>("WorkExpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkExpId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsCurrentCompany")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Profile")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("WorkExpId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JOB_WorkExperience", (string)null);
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobApplication", b =>
                {
                    b.HasOne("Job_Portal.Models.JobJobListing", "Job")
                        .WithMany("JobJobApplications")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK_JOB_JobApplication_JOB_JobListing");

                    b.HasOne("Job_Portal.Models.JobJobSeeker", "JobSeeker")
                        .WithMany("JobJobApplications")
                        .HasForeignKey("JobSeekerId")
                        .IsRequired()
                        .HasConstraintName("FK_JOB_JobApplication_JOB_JobSeeker");

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobListing", b =>
                {
                    b.HasOne("Job_Portal.Models.JobCatogory", "Category")
                        .WithMany("JobJobListings")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_JOB_JobListing_JOB_catogory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Job_Portal.Models.JobSkill", b =>
                {
                    b.HasOne("Job_Portal.Models.JobJobSeeker", "JobSeekar")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobSeekarId")
                        .HasConstraintName("FK_JOB_Skills_JOB_JobSeeker");

                    b.Navigation("JobSeekar");
                });

            modelBuilder.Entity("Job_Portal.Models.JobWorkExperience", b =>
                {
                    b.HasOne("Job_Portal.Models.JobJobSeeker", "JobSeeker")
                        .WithMany("JobWorkExperiences")
                        .HasForeignKey("JobSeekerId")
                        .IsRequired()
                        .HasConstraintName("FK_JOB_WorkExperience_JOB_JobSeeker");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("Job_Portal.Models.JobCatogory", b =>
                {
                    b.Navigation("JobJobListings");
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobListing", b =>
                {
                    b.Navigation("JobJobApplications");
                });

            modelBuilder.Entity("Job_Portal.Models.JobJobSeeker", b =>
                {
                    b.Navigation("JobJobApplications");

                    b.Navigation("JobSkills");

                    b.Navigation("JobWorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}