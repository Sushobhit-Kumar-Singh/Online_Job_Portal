using Job_Portal.Data;
using Job_Portal.Models;
using Job_Portal.Models.Views;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Job_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobPortalDbContext _context;

        public JobController(JobPortalDbContext context)
        {
            _context = context;
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] JobUser obj)
        {
            IActionResult _res;

            if (!ModelState.IsValid)
            {
                _res = BadRequest(new { Result = false, Message = "Validation Error" });
                return _res;
            }

            try
            {
                var user = _context.JobUsers.SingleOrDefault(m => m.UserName.ToLower() == obj.UserName.ToLower() && m.Password == obj.Password);

                if (user != null)
                {
                    _res = Ok(new { Result = true, Data = user, Message = "User Found Successfully" });
                }
                else
                {
                    _res = BadRequest(new { Result = false, Message = "Wrong Credentials" });
                }

                return _res;
            }
            catch (Exception ex)
            {
                _res = BadRequest(new { Result = false, Message = ex.Message });
                return _res;
            }
        }

        //#endregion



        #region Category
        [HttpGet("GetAllJobCategory")]
        public ActionResult<IEnumerable<JobCatogory>> GetAllJobCategory()
        {
            try
            {
                var jobCategories = _context.JobCatogories.ToList();
                return Ok(jobCategories);
            }
            catch (Exception ex)
            {
                var errorMessage = new List<string> { ex.Message };
                return StatusCode(500, errorMessage);
            }
        }



        [HttpPost("AddBulkJobCategory")]
        public IActionResult AddBulkJobCategory([FromBody] List<JobCatogory> obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Validation Error");
                }

                foreach (var item in obj)
                {
                    if (item.JobCategoryId == 0)
                    {
                        var isExist = _context.JobCatogories.SingleOrDefault(m => m.CategoryName.ToLower() == item.CategoryName.ToLower());
                        if (isExist == null)
                        {
                            _context.JobCatogories.Add(item);
                        }
                    }
                    else
                    {
                        _context.Entry(item).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();
                return Ok("Data Added / Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete("DeleteJobCategoryByCategoryId")]
        public IActionResult DeleteJobCategoryByCategoryId(int categoryId)
        {
            try
            {
                var record = _context.JobCatogories.SingleOrDefault(m => m.JobCategoryId == categoryId);
                if (record != null)
                {
                    _context.JobCatogories.Remove(record);
                    _context.SaveChanges();
                    return Ok(true); // Successfully deleted
                }
                else
                {
                    return NotFound(false); // Record not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, false); // Error occurred while deleting
            }
        }

        #endregion



        #region Employer
        [HttpGet("GetAllEmployer")]
        public IActionResult GetAllEmployer()
        {
            try
            {
                var all = _context.JobEmployers.ToList();
                return Ok(all); // Return a 200 OK status code with the list of employers
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return a 500 Internal Server Error status code with the exception message
            }
        }




        [HttpGet("GetEmployerById")]
        public IActionResult GetEmployerById(int employerId)
        {
            try
            {
                var employer = _context.JobEmployers.SingleOrDefault(m => m.EmployerId == employerId);

                if (employer != null)
                {
                    return Ok(employer); // Return a 200 OK status code with the employer details
                }
                else
                {
                    return NotFound("No Item Found"); // Return a 404 Not Found status code with a message
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return a 500 Internal Server Error status code with the exception message
            }
        }


        [HttpPost("AddNewEmployer")]
        public IActionResult AddNewEmployer([FromBody] JobEmployer obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Validation Error");
                }

                var isExist = _context.JobEmployers.SingleOrDefault(m => m.GstNo.ToLower() == obj.GstNo.ToLower());
                if (isExist == null)
                {
                    _context.JobEmployers.Add(obj);
                    _context.SaveChanges();

                    JobUser _user = new JobUser()
                    {
                        CreatedDate = DateTime.Now,
                        UserName = obj.GstNo,
                        EmployerId = obj.EmployerId,
                        Password = obj.GstNo + obj.PinCode,
                        UserRole = "Employer"
                    };

                    _context.JobUsers.Add(_user);
                    _context.SaveChanges();

                    return Ok(new
                    {
                        Result = true,
                        Data = obj,
                        Message = "Registration Success. Username will be Your GstNo & password will be GstNo+PinCode"
                    });
                }
                else
                {
                    return BadRequest("GstNo Already Present");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("UpdateEmployer")]
        public IActionResult UpdateEmployer([FromBody] JobEmployer obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Validation Error");
                }

                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(new
                {
                    Result = true,
                    Data = obj,
                    Message = "Record Updated Successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployerById")]
        public IActionResult DeleteEmployerById(int employerId)
        {
            try
            {
                var record = _context.JobEmployers.SingleOrDefault(m => m.EmployerId == employerId);
                if (record != null)
                {
                    _context.JobEmployers.Remove(record);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        Result = true,
                        Message = "Deleted Successfully"
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        Result = false,
                        Message = "No Record Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    Message = ex.Message
                });
            }
        }
        #endregion



        #region Job Seeker
        [HttpGet("GetAllJobSeeker")]
        public IActionResult GetAllJobSeeker()
        {
            try
            {
                var all = _context.JobJobSeekers.ToList();
                return Ok(new
                {
                    Result = true,
                    Data = all
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    Message = ex.Message
                });
            }
        }




        [HttpGet("GetJobSeekerById")]
        public IActionResult GetJobSeekerById(int id)
        {
            try
            {
                var data = new JobSeekerViewModel();
                var jobSeeker = _context.JobJobSeekers.SingleOrDefault(m => m.JobSeekerId == id);

                if (jobSeeker != null)
                {
                    data.EmailId = jobSeeker.EmailId;
                    data.ExperienceStatus = jobSeeker.ExperienceStatus;
                    data.FullName = jobSeeker.FullName;
                    data.MobileNo = jobSeeker.MobileNo;
                    data.ResumeUrl = jobSeeker.ResumeUrl;

                    var skills = _context.JobSkills.Where(m => m.JobSeekarId == id).ToList();
                    if (skills != null && skills.Any())
                    {
                        //data.JobSeekerSkills = skills;

                        // Convert List<JobSkill> to List<JobSeekerSkill>
                        data.JobSeekerSkills = skills.Select(skill => new JobSeekerSkill
                        {
                            // Assign properties accordingly, assuming JobSeekerSkill has similar properties as JobSkill
                            // For example:
                            SkillName = skill.SkillName,
                            //SkillLevel = skill.SkillLevel
                        }).ToList();
                    }

                    var works = _context.JobWorkExperiences.Where(m => m.JobSeekerId == id).ToList();
                    if (works != null && works.Any())
                    {
                        // Convert List<JobWorkExperience> to List<JobSeekerWorkExperience>
                        data.JobSeekerWorkExperiences = works.Select(work => new JobSeekerWorkExperience
                        {
                            // Assign properties accordingly, assuming JobSeekerWorkExperience has similar properties as JobWorkExperience
                            // For example:
                            CompanyName = work.CompanyName,
                            //Position = work.Position,
                            // Add other properties as needed
                        }).ToList();

                        //data.JobSeekerWorkExperiences = works;
                    }

                    return Ok(data);
                }
                else
                {
                    return NotFound(new ApiResponse { Result = false, Message = "No Item Found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }



        [HttpPost("AddNewJobSeeker")]
        public IActionResult AddNewJobSeeker([FromBody] JobSeekerViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Validation Error");
                }

                var isExist = _context.JobJobSeekers.SingleOrDefault(m => m.EmailId.ToLower() == obj.EmailId.ToLower());
                if (isExist != null)
                {
                    return BadRequest("EmailId Already Present");
                }

                var seeker = new JobJobSeeker
                {
                    MobileNo = obj.MobileNo,
                    EmailId = obj.EmailId,
                    ExperienceStatus = obj.ExperienceStatus,
                    FullName = obj.FullName,
                    ResumeUrl = obj.ResumeUrl
                };
                _context.JobJobSeekers.Add(seeker);
                _context.SaveChanges();

                var user = new JobUser
                {
                    CreatedDate = DateTime.Now,
                    UserName = obj.EmailId,
                    JobSeekerId = seeker.JobSeekerId,
                    Password = obj.MobileNo,
                    UserRole = "JobSeeker"
                };
                _context.JobUsers.Add(user);
                _context.SaveChanges();

                foreach (var skill in obj.JobSeekerSkills)
                {
                    var seekerSkill = new JobSkill
                    {
                        DurationOfSkill = skill.DurationOfSkill,
                        JobSeekarId = seeker.JobSeekerId,
                        SkillName = skill.SkillName
                    };
                    _context.JobSkills.Add(seekerSkill);
                }
                _context.SaveChanges();

                foreach (var experience in obj.JobSeekerWorkExperiences)
                {
                    var workExperience = new JobWorkExperience
                    {
                        CompanyName = experience.CompanyName,
                        EndDate = experience.EndDate,
                        IsCurrentCompany = experience.IsCurrentCompany,
                        JobDescription = experience.JobDescription,
                        Profile = experience.Profile,
                        StartDate = experience.StartDate,
                        JobSeekerId = seeker.JobSeekerId
                    };
                  //  _context.JobJobSeekers.Add(workExperience);
                    // Add to the correct collection
                    _context.JobWorkExperiences.Add(workExperience);
                }
                _context.SaveChanges();

                return Ok(new

                {
                    Result = true,
                    Data = obj,
                    Message = "Registration Success. Username will be Your Email Id & password will be mobile No"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("DeleteJobSeekerById")]
        public IActionResult DeleteJobSeekerById(int id)
        {
            try
            {
                var record = _context.JobJobSeekers.SingleOrDefault(m => m.JobSeekerId == id);
                if (record != null)
                {
                    _context.JobJobSeekers.Remove(record);
                    _context.SaveChanges();

                    var skills = _context.JobSkills.SingleOrDefault(m => m.JobSeekarId == id);
                    if (skills != null)
                    {
                        _context.JobSkills.Remove(skills);
                        _context.SaveChanges();
                    }

                    var work = _context.JobWorkExperiences.SingleOrDefault(m => m.JobSeekerId == id);
                    if (work != null)
                    {
                        _context.JobWorkExperiences.Remove(work);
                        _context.SaveChanges();
                    }

                    return Ok(new ApiResponse { Result = true, Message = "Deleted Successfully" });
                }
                else
                {
                    return NotFound(new ApiResponse { Result = false, Message = "Job Seeker Not Found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        #endregion

        #region JobListing

        [HttpGet("GetActiveJobListing")]
        public IActionResult GetActiveJobListing()
        {
            try
            {
                var all = (from item in _context.JobJobListings
                           join seeker in _context.JobEmployers on item.EmployerId equals seeker.EmployerId
                           join category in _context.JobCatogories on item.CategoryId equals category.JobCategoryId
                           where item.IsActive == true
                           select new
                           {
                               JobName = item.JobName,
                               Package = item.Package,
                               Experience = item.Experience,
                               Location = item.Location,
                               CategoryName = category.CategoryName,
                               LogoUrl = seeker.LogoUrl,
                               CompanyName = seeker.CompanyName,
                               JobId = item.JobId
                           })
                           .OrderByDescending(m => m.JobId)
                           .ToList();

                return Ok(all);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }



        [HttpGet("GetAllJobListing")]
        public IActionResult GetAllJobListing()
        {
            try
            {
                var all = (from item in _context.JobJobListings
                           join seeker in _context.JobEmployers on item.EmployerId equals seeker.EmployerId
                           join category in _context.JobCatogories on item.CategoryId equals category.JobCategoryId
                           select new
                           {
                               JobName = item.JobName,
                               Package = item.Package,
                               Experience = item.Experience,
                               Location = item.Location,
                               CategoryName = category.CategoryName,
                               LogoUrl = seeker.LogoUrl,
                               CompanyName = seeker.CompanyName,
                               JobId = item.JobId
                           })
                           .OrderByDescending(m => m.JobId)
                           .ToList();

                return Ok(all);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        [HttpGet("GetJobsByEmployerId")]
        public IActionResult GetJobsByEmployerId(int employerId)
        {
            try
            {
                var jobs = (from item in _context.JobJobListings
                            join category in _context.JobCatogories on item.CategoryId equals category.JobCategoryId
                            where item.IsActive == true && item.EmployerId == employerId
                            select new
                            {
                                JobName = item.JobName,
                                Package = item.Package,
                                Experience = item.Experience,
                                Location = item.Location,
                                CategoryName = category.CategoryName,
                                JobId = item.JobId
                            })
                            .OrderByDescending(m => m.JobId)
                            .ToList();

                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        [HttpGet("GetApplcationsByJobId")]
        public IActionResult GetApplicationsByJobId(int jobId)
        {
            try
            {
                var all = (from item in _context.JobJobApplications
                           where item.JobId == jobId
                           join seeker in _context.JobJobSeekers on item.JobSeekerId equals seeker.JobSeekerId
                           select new
                           {
                               ApplcationStatus = item.ApplcationStatus,
                               ApplicationId = item.ApplicationId,
                               AppliedDate = item.AppliedDate,
                               JobSeekerId = item.JobSeekerId,
                               FullName = seeker.FullName,
                               EmailId = seeker.EmailId,
                               MobileNo = seeker.MobileNo,
                               JobId = item.JobId,
                           })
                           .OrderByDescending(m => m.ApplicationId)
                           .ToList();

                return Ok(all);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Result = false, Message = ex.Message });
            }
        }


        [HttpGet("GetAllJobApplcations")]
        public IActionResult GetAllJobApplications()
        {
            try
            {
                var all = (from item in _context.JobJobApplications
                           join seeker in _context.JobJobSeekers on item.JobSeekerId equals seeker.JobSeekerId
                           join job in _context.JobJobListings on item.JobId equals job.JobId
                           join category in _context.JobCatogories on job.CategoryId equals category.JobCategoryId
                           select new
                           {
                               ApplcationStatus = item.ApplcationStatus,
                               ApplicationId = item.ApplicationId,
                               AppliedDate = item.AppliedDate,
                               JobSeekerId = item.JobSeekerId,
                               FullName = seeker.FullName,
                               EmailId = seeker.EmailId,
                               MobileNo = seeker.MobileNo,
                               JobId = item.JobId,
                               CategoryName = category.CategoryName,
                               JobName = job.JobName
                           })
                           .OrderByDescending(m => m.ApplicationId)
                           .ToList();

                return Ok(all);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Result = false, Message = ex.Message });
            }
        }


        [HttpGet("GetApplcationsByJobSeekerId")]
        public IActionResult GetApplicationsByJobSeekerId(int jobSeekerId)
        {
            try
            {
                var applications = (from item in _context.JobJobApplications
                                    where item.JobSeekerId == jobSeekerId
                                    join job in _context.JobJobListings on item.JobId equals job.JobId
                                    select new
                                    {
                                        ApplcationStatus = item.ApplcationStatus,
                                        ApplicationId = item.ApplicationId,
                                        AppliedDate = item.AppliedDate,
                                        JobSeekerId = item.JobSeekerId,
                                        JobId = item.JobId,
                                        JobName = job.JobName
                                    })
                                    .OrderByDescending(m => m.ApplicationId)
                                    .ToList();

                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Result = false, Message = ex.Message });
            }
        }


        [HttpPost("SendJobApplication")]
        public IActionResult SendJobApplication([FromBody] JobJobApplication obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse { Result = false, Message = "Validation Error" });
                }

                var job = _context.JobJobListings.FirstOrDefault(m => m.JobId == obj.JobId);
                if (job != null)
                {
                    if (job.IsActive.HasValue && job.IsActive.Value)
                    {
                        var isAlreadyApplied = _context.JobJobApplications.FirstOrDefault(m => m.JobId == obj.JobId && m.JobSeekerId == obj.JobSeekerId);
                       

                        if (isAlreadyApplied == null)
                        {
                            _context.JobJobApplications.Add(obj);
                            _context.SaveChanges();
                            return Ok(new ApiResponse { Result = true, Message = "You Have Successfully Applied" });
                        }
                        else
                        {
                            return Conflict(new ApiResponse { Result = false, Message = "You Have Already Applied For This Job" });
                        }
                    }
                    else
                    {
                        return BadRequest(new ApiResponse { Result = false, Message = "Job Is Not Active Now" });
                    }
                }
                else
                {
                    return NotFound(new ApiResponse { Result = false, Message = "Job Details Not Found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }



        [HttpGet("GetJobListingById")]
        public IActionResult GetJobListingById(int jobId)
        {
            try
            {
                var result = (from item in _context.JobJobListings
                              join seeker in _context.JobEmployers on item.EmployerId equals seeker.EmployerId
                              join category in _context.JobCatogories on item.CategoryId equals category.JobCategoryId
                              where item.JobId == jobId
                              select new
                              {
                                  JobName = item.JobName,
                                  Package = item.Package,
                                  Experience = item.Experience,
                                  Location = item.Location,
                                  CategoryName = category.CategoryName,
                                  LogoUrl = seeker.LogoUrl,
                                  CompanyName = seeker.CompanyName,
                                  JobId = item.JobId,
                                  JobDescription = item.JobDescription,
                                  EmployerId = item.EmployerId,
                                  CategoryId = item.CategoryId,
                                  CompanyAddress = seeker.CompanyAddress,
                                  EmailId = seeker.EmailId
                              })
                              .OrderByDescending(m => m.JobId)
                              .SingleOrDefault();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ApiResponse { Result = false, Message = "No Item Found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        [HttpPost("CreateNewJobListing")]
        public IActionResult CreateNewJobListing([FromBody] JobJobListing obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse { Result = false, Message = "Validation Error" });
                }

                var isExist = _context.JobJobListings
                    .SingleOrDefault(m => m.JobName.ToLower() == obj.JobName.ToLower() && m.EmployerId == obj.EmployerId);
                if (isExist == null)
                {

                    _context.JobJobListings.Add(obj);
                    _context.SaveChanges();

                    return Ok(new ApiResponse { Result = true, Message = "Record Added Successfully" });
                }
                else
                {
                    return Conflict(new ApiResponse { Result = false, Message = "Job Name already Exists for this Employer" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        [HttpPut("UpdateJobListing")]
        public IActionResult UpdateJobListing([FromBody] JobJobListing obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse { Result = false, Message = "Validation Error" });
                }

                var existingJob = _context.JobJobListings.FirstOrDefault(j => j.JobId == obj.JobId);

                if (existingJob == null)
                {
                    return NotFound(new ApiResponse { Result = false, Message = "Job not found" });
                }

                // Update the existing job with the new data
                _context.Entry(existingJob).CurrentValues.SetValues(obj);
                _context.SaveChanges();

                return Ok(new ApiResponse { Result = true, Message = "Record Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Result = false, Message = ex.Message });
            }
        }


        [HttpDelete("DeleteJobById")]
        public IActionResult DeleteJobById(int jobid)
        {
            IActionResult _res;
            try
            {
                var record = _context.JobJobListings.SingleOrDefault(m => m.JobId == jobid);

                if (record == null)
                {
                    _res = NotFound("Job not found."); // Return 404 Not Found status
                }
                else
                {
                    _context.JobJobListings.Remove(record);
                    _context.SaveChanges();
                    _res = Ok(new { Result = true, Message = "Deleted Successfully" }); // Return 200 OK status
                }

                return _res;
            }
            catch (Exception ex)
            {
                _res = BadRequest(new { Result = false, Message = ex.Message }); // Return 400 Bad Request status
                return _res;
            }
        }
        #endregion
    }
}
