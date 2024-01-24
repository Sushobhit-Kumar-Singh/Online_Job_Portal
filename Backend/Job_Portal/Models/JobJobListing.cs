using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobJobListing
{
    public int JobId { get; set; }

    public string? JobName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? EmployerId { get; set; }

    public int? CategoryId { get; set; }

    public string? Experience { get; set; }

    public string? Package { get; set; }

    public string? Location { get; set; }

    public string? JobDescription { get; set; }

    public bool? IsActive { get; set; }

    public virtual JobCatogory? Category { get; set; }

    public virtual ICollection<JobJobApplication> JobJobApplications { get; set; } = new List<JobJobApplication>();
}
