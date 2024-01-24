using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobSkill
{
    public int SkillId { get; set; }

    public int? JobSeekarId { get; set; }

    public string? SkillName { get; set; }

    public string? DurationOfSkill { get; set; }

    public virtual JobJobSeeker? JobSeekar { get; set; }
}
