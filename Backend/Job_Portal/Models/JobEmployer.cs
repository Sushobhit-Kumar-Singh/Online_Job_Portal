using System;
using System.Collections.Generic;

namespace Job_Portal.Models;

public partial class JobEmployer
{
    public int EmployerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? MobileNo { get; set; }

    public string? PhoneNo { get; set; }

    public string? CompanyAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PinCode { get; set; }

    public string? LogoUrl { get; set; }

    public string? GstNo { get; set; }
}
