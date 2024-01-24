 
GO
/****** Object:  Table [dbo].[JOB_catogory]    Script Date: 23-12-2023 21:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_catogory](
	[JobCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_JOB_catogory] PRIMARY KEY CLUSTERED 
(
	[JobCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_Employer]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_Employer](
	[EmployerId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[MobileNo] [varchar](10) NULL,
	[PhoneNo] [varchar](50) NULL,
	[CompanyAddress] [varchar](1000) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PinCode] [varchar](6) NULL,
	[LogoURL] [varchar](200) NULL,
	[GstNo] [varchar](50) NULL,
 CONSTRAINT [PK_Job_Employer] PRIMARY KEY CLUSTERED 
(
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_JobApplication]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_JobApplication](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[JobSeekerId] [int] NOT NULL,
	[AppliedDate] [datetime] NULL,
	[ApplcationStatus] [varchar](50) NULL,
 CONSTRAINT [PK_JOB_JobApplication] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_JobListing]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_JobListing](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [varchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[EmployerId] [int] NULL,
	[CategoryId] [int] NULL,
	[Experience] [varchar](50) NULL,
	[Package] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[JobDescription] [varchar](2000) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_JOB_JobListing] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_JobSeeker]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_JobSeeker](
	[JobSeekerId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[MobileNo] [varchar](10) NULL,
	[ExperienceStatus] [varchar](50) NULL,
	[ResumeUrl] [varchar](50) NULL,
 CONSTRAINT [PK_JOB_JobSeeker] PRIMARY KEY CLUSTERED 
(
	[JobSeekerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_Skills]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_Skills](
	[SkillId] [int] IDENTITY(1,1) NOT NULL,
	[JobSeekarId] [int] NULL,
	[SkillName] [varchar](50) NULL,
	[DurationOfSkill] [varchar](50) NULL,
 CONSTRAINT [PK_JOB_Skills] PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_Users]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[UserRole] [varchar](50) NULL,
	[EmployerId] [int] NULL,
	[JobSeekerId] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_JOB_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_WorkExperience]    Script Date: 23-12-2023 21:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_WorkExperience](
	[WorkExpId] [int] IDENTITY(1,1) NOT NULL,
	[JobSeekerId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[IsCurrentCompany] [bit] NOT NULL,
	[Profile] [varchar](50) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [date] NULL,
	[JobDescription] [varchar](1000) NULL,
 CONSTRAINT [PK_JOB_WorkExperience] PRIMARY KEY CLUSTERED 
(
	[WorkExpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JOB_JobApplication]  WITH CHECK ADD  CONSTRAINT [FK_JOB_JobApplication_JOB_JobListing] FOREIGN KEY([JobId])
REFERENCES [dbo].[JOB_JobListing] ([JobId])
GO
ALTER TABLE [dbo].[JOB_JobApplication] CHECK CONSTRAINT [FK_JOB_JobApplication_JOB_JobListing]
GO
ALTER TABLE [dbo].[JOB_JobApplication]  WITH CHECK ADD  CONSTRAINT [FK_JOB_JobApplication_JOB_JobSeeker] FOREIGN KEY([JobSeekerId])
REFERENCES [dbo].[JOB_JobSeeker] ([JobSeekerId])
GO
ALTER TABLE [dbo].[JOB_JobApplication] CHECK CONSTRAINT [FK_JOB_JobApplication_JOB_JobSeeker]
GO
ALTER TABLE [dbo].[JOB_JobListing]  WITH CHECK ADD  CONSTRAINT [FK_JOB_JobListing_JOB_catogory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[JOB_catogory] ([JobCategoryId])
GO
GO
ALTER TABLE [dbo].[JOB_JobListing]  WITH CHECK ADD  CONSTRAINT [FK_JOB_JobListing_Job_Employer] FOREIGN KEY(EmployerId)
REFERENCES [dbo].[Job_Employer] (EmployerId)
GO




ALTER TABLE [dbo].[JOB_JobListing] CHECK CONSTRAINT [FK_JOB_JobListing_JOB_catogory]
GO
ALTER TABLE [dbo].[JOB_Skills]  WITH CHECK ADD  CONSTRAINT [FK_JOB_Skills_JOB_JobSeeker] FOREIGN KEY([JobSeekarId])
REFERENCES [dbo].[JOB_JobSeeker] ([JobSeekerId])
GO
ALTER TABLE [dbo].[JOB_Skills] CHECK CONSTRAINT [FK_JOB_Skills_JOB_JobSeeker]
GO
ALTER TABLE [dbo].[JOB_WorkExperience]  WITH CHECK ADD  CONSTRAINT [FK_JOB_WorkExperience_JOB_JobSeeker] FOREIGN KEY([JobSeekerId])
REFERENCES [dbo].[JOB_JobSeeker] ([JobSeekerId])
GO
ALTER TABLE [dbo].[JOB_WorkExperience] CHECK CONSTRAINT [FK_JOB_WorkExperience_JOB_JobSeeker]
GO
