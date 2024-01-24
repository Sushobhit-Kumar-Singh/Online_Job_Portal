/*namespace Job_Portal.Models.Views
{
    public class JobJobListingViewModel
    {
        public int JobId { get; set; }

        public string JobName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int EmployerId { get; set; }

        public int CategoryId { get; set; }

        public string Experience { get; set; }

        public string Package { get; set; }

        public string Location { get; set; }

        public string JobDescription { get; set; }

        public bool IsActive { get; set; }

        public JobCatogoryViewModel Category { get; set; }

        public List<JobJobApplicationViewModel> JobJobApplications { get; set; }

    }

    public class JobCatogoryViewModel
    {
        public int JobCategoryId { get; set; }

        public string CategoryName { get; set; }
    }

    public class JobJobApplicationViewModel
    {
        public int ApplicationId { get; set; }

        public int JobId { get; set; }

        public int JobSeekerId { get; set; }

        public DateTime AppliedDate { get; set; }

        public string ApplcationStatus { get; set; }

    }
    

}*/
/*namespace Job_Portal.Models.Views
{
    public class JobListingViewModel
    {

    }

    public class JobSeeker
    {
        public int JobSeekerId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string ExperienceStatus { get; set; }
        public string ResumeUrl { get; set; }
        public List<string> JobJobApplications { get; set; }
        public List<JobSkill> JobSkills { get; set; }
        public List<JobWorkExperience> JobWorkExperiences { get; set; }
    }
    public class JobCategory
    {
        public int JobCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> JobJobListings { get; set; }
    }

    public class JobSkill
    {
        public int SkillId { get; set; }
        public int JobSeekarId { get; set; }
        public string SkillName { get; set; }
        public string DurationOfSkill { get; set; }
        public string JobSeekar { get; set; }
    }

    public class JobWorkExperience
    {
        public int WorkExpId { get; set; }
        public int JobSeekerId { get; set; }
        public string CompanyName { get; set; }
        public bool IsCurrentCompany { get; set; }
        public string Profile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobDescription { get; set; }
        public string JobSeeker { get; set; }
    }

   

    public class JobJobApplication
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public DateTime AppliedDate { get; set; }
        public string ApplcationStatus { get; set; }
        public string Job { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }

    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EmployerId { get; set; }
        public int CategoryId { get; set; }
        public string Experience { get; set; }
        public string Package { get; set; }
        public string Location { get; set; }
        public string JobDescription { get; set; }
        public bool IsActive { get; set; }
        public JobCategory Category { get; set; }
        public List<JobJobApplication> JobJobApplications { get; set; }
    }
}
*/