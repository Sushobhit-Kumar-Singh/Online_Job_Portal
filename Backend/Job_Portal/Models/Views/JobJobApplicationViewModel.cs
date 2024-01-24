/*namespace Job_Portal.Models.Views
{
    public class JobJobApplicationViewModel
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public DateTime AppliedDate { get; set; }
        public string ApplicationStatus { get; set; }
        public JobViewModel Job { get; set; }
        public JobSeekerViewModels JobSeeker { get; set; }
    }

    public class JobViewModel
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
        public CategoryViewModel Category { get; set; }
        public string[] JobJobApplications { get; set; }
    }
    public class JobSeekerViewModels
    {
        public int JobSeekerId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string ExperienceStatus { get; set; }
        public string ResumeUrl { get; set; }
        public string[] JobJobApplications { get; set; }
        public SkillViewModel[] JobSkills { get; set; }
        public WorkExperienceViewModel[] JobWorkExperiences { get; set; }
    }
    public class CategoryViewModel
    {
        public int JobCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string[] JobJobListings { get; set; }
    }



    public class SkillViewModel
    {
        public int SkillId { get; set; }
        public int JobSeekerId { get; set; }
        public string SkillName { get; set; }
        public string DurationOfSkill { get; set; }
        public string JobSeekar { get; set; }
    }

    public class WorkExperienceViewModel
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
}
*/