namespace Job_Portal.Models.Views
{
    public class JobSeekerViewModel
    {
        public string EmailId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string ResumeUrl { get; set; }
        public string ExperienceStatus { get; set; }
        public List<JobSeekerSkill> JobSeekerSkills { get; set; }
        public List<JobSeekerWorkExperience> JobSeekerWorkExperiences { get; set; }
    }

    public class JobSeekerSkill
    {
        public int SkillId { get; set; }

        public int? JobSeekarId { get; set; }

        public string? SkillName { get; set; }

        public string? DurationOfSkill { get; set; }

        public virtual JobJobSeeker? JobSeekar { get; set; }
    }

    public class JobSeekerWorkExperience
    {
        public int WorkExpId { get; set; }

        public int JobSeekerId { get; set; }

        public string CompanyName { get; set; } = null!;

        public bool IsCurrentCompany { get; set; }

        public string? Profile { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? JobDescription { get; set; }

        public virtual JobJobSeeker JobSeeker { get; set; } = null!;
    }
}
