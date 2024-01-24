using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobJobSeeker
{
    public int JobSeekerId { get; set; }

    public string? FullName { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNo { get; set; }

    public string? ExperienceStatus { get; set; }

    public string? ResumeUrl { get; set; }

    public virtual ICollection<JobJobApplication> JobJobApplications { get; set; } = new List<JobJobApplication>();

    public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();

    public virtual ICollection<JobWorkExperience> JobWorkExperiences { get; set; } = new List<JobWorkExperience>();
}
