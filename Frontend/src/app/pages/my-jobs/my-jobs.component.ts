import { Component,OnInit } from '@angular/core';
import { JobService } from 'src/app/service/job.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-my-jobs',
  templateUrl: './my-jobs.component.html',
  styleUrls: ['./my-jobs.component.css']
})
export class MyJobsComponent implements OnInit {
  jobForm: FormGroup;

  jobObj :any = {
    "JobId": 0,
    "JobName": "",
    "CreatedDate": new Date(),
    "EmployerId": 0,
    "CategoryId": 0,
    "Experience": "",
    "Package": "",
    "Location": "",
    "JobDescription": "",
    "IsActive": true,
    

  };
  // jobObj!:any;
  categoryList: any [] = [];

  JobId! :number;
  constructor(private jobSrv: JobService,private fb: FormBuilder,private route: ActivatedRoute){

    this.jobForm = this.fb.group({
      JobName: ['', [Validators.required]],
      Package: ['', [Validators.required]],
      Location: ['', [Validators.required]],


    });


    const userData = localStorage.getItem('jobLoginUser');
    if(userData != null){
      const data = JSON.parse(userData);
      this.jobObj.EmployerId = data.employerId;
    
    }
  }
  ngOnInit(): void{
    this.jobObj = this.route.snapshot.paramMap.get('jobId');
    this.jobSrv.updateNewJob(this.JobId).subscribe((res:any)=>{
      this.jobObj = res.jobObj;
    })
    this.getJobCategories();
  }
  
  getJobCategories(){
    this.jobSrv.getAllCategory().subscribe((res: any)=>{
      
      this.categoryList = res;
       
    })
  }
  UpdateJob(){
    this.jobSrv.updateNewJob(this.jobObj).subscribe((res:any)=>{
    if(res.result){
      alert('Post Update Success')
    }  else{
      alert(res.message)
    }
    })
  }
}
