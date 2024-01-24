using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobWorkExperience
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
