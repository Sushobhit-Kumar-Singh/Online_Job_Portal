using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobJobApplication
{
    public int ApplicationId { get; set; }

    public int JobId { get; set; }

    public int JobSeekerId { get; set; }

    public DateTime? AppliedDate { get; set; }

    public string? ApplcationStatus { get; set; }

    public virtual JobJobListing Job { get; set; } = null!;

    public virtual JobJobSeeker JobSeeker { get; set; } = null!;
}
