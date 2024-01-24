using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? UserRole { get; set; }

    public int? EmployerId { get; set; }

    public int? JobSeekerId { get; set; }

    public DateTime? CreatedDate { get; set; }
}
