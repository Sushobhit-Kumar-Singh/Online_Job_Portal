import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JobService } from 'src/app/service/job.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  jobSeekerForm: FormGroup;
  
  employerObj:any = {
  "EmployerId": 0,
  "CompanyName": "",
  "EmailId": "",
  "MobileNo": "",
  "PhoneNo": "",
  "CompanyAddress": "",
  "City": "",
  "State": "",
  "PinCode": "",
  "LogoURL": "",
  "GstNo": ""
  };
  JobSeekerObj: any = {
  "JobSeekerId": 0,
  "FullName": "",
  "EmailId": "",
  "MobileNo": "",
  "ExperienceStatus": "",
  "ResumeUrl": "",
  "JobSeekerSkills": [],
  "JobSeekerWorkExperiences": []
  }
  isJobSeeker: boolean = true;

  constructor(private job: JobService,private fb: FormBuilder,private router: Router){


    this.jobSeekerForm = this.fb.group({
      FullName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern('[a-zA-Z ]*')]],
      
      EmailId: ['', [Validators.required, Validators.email]],
      MobileNo: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      ResumeUrl: ['', [Validators.required]],

      CompanyName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern('[a-zA-Z ]*')]],
      PhoneNo: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      LogoURL: ['', [Validators.required]],
      GstNo: ['', [Validators.required]],
      City: ['', [Validators.required]],
      State: ['', [Validators.required]],
      PinCode: ['', [Validators.required, Validators.pattern('^[0-9]{6}$')]],






    });
  }

  register() {
    this.job.registerEmployer(this.employerObj).subscribe((res:any)=>{
      if(res.result){
        alert(res.message)
        this.router.navigateByUrl('/login')

      }else{
        alert(res.message)
      }
    })
  }
  registerAsJobSeeker(){
    this.job.registerAsJobSeeker(this.JobSeekerObj).subscribe((res:any)=>{
      if(res.result){
        alert(res.message)
        this.router.navigateByUrl('/login')

      }else{
        alert(res.message)
      }
    })
  }
}
