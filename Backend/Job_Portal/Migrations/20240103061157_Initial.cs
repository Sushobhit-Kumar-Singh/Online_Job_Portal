using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Portal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JOB_catogory",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_catogory", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Job_Employer",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmailId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MobileNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PhoneNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyAddress = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PinCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    LogoURL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    GstNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Employer", x => x.EmployerId);
                });

            migrationBuilder.CreateTable(
                name: "JOB_JobSeeker",
                columns: table => new
                {
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ExperienceStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ResumeUrl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_JobSeeker", x => x.JobSeekerId);
                });

            migrationBuilder.CreateTable(
                name: "JOB_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserRole = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmployerId = table.Column<int>(type: "int", nullable: true),
                    JobSeekerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "JOB_JobListing",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmployerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Experience = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Package = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    JobDescription = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_JobListing", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JOB_JobListing_JOB_catogory",
                        column: x => x.CategoryId,
                        principalTable: "JOB_catogory",
                        principalColumn: "JobCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "JOB_Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekarId = table.Column<int>(type: "int", nullable: true),
                    SkillName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DurationOfSkill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_JOB_Skills_JOB_JobSeeker",
                        column: x => x.JobSeekarId,
                        principalTable: "JOB_JobSeeker",
                        principalColumn: "JobSeekerId");
                });

            migrationBuilder.CreateTable(
                name: "JOB_WorkExperience",
                columns: table => new
                {
                    WorkExpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsCurrentCompany = table.Column<bool>(type: "bit", nullable: false),
                    Profile = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    JobDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_WorkExperience", x => x.WorkExpId);
                    table.ForeignKey(
                        name: "FK_JOB_WorkExperience_JOB_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JOB_JobSeeker",
                        principalColumn: "JobSeekerId");
                });

            migrationBuilder.CreateTable(
                name: "JOB_JobApplication",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ApplcationStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOB_JobApplication", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_JOB_JobApplication_JOB_JobListing",
                        column: x => x.JobId,
                        principalTable: "JOB_JobListing",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_JOB_JobApplication_JOB_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JOB_JobSeeker",
                        principalColumn: "JobSeekerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JOB_JobApplication_JobId",
                table: "JOB_JobApplication",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_JobApplication_JobSeekerId",
                table: "JOB_JobApplication",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_JobListing_CategoryId",
                table: "JOB_JobListing",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_Skills_JobSeekarId",
                table: "JOB_Skills",
                column: "JobSeekarId");

            migrationBuilder.CreateIndex(
                name: "IX_JOB_WorkExperience_JobSeekerId",
                table: "JOB_WorkExperience",
                column: "JobSeekerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job_Employer");

            migrationBuilder.DropTable(
                name: "JOB_JobApplication");

            migrationBuilder.DropTable(
                name: "JOB_Skills");

            migrationBuilder.DropTable(
                name: "JOB_Users");

            migrationBuilder.DropTable(
                name: "JOB_WorkExperience");

            migrationBuilder.DropTable(
                name: "JOB_JobListing");

            migrationBuilder.DropTable(
                name: "JOB_JobSeeker");

            migrationBuilder.DropTable(
                name: "JOB_catogory");
        }
    }
}
