using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobCatogory
{
    public int JobCategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<JobJobListing> JobJobListings { get; set; } = new List<JobJobListing>();
}
