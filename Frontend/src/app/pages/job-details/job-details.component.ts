import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobService } from 'src/app/service/job.service';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.css']
})
export class JobDetailsComponent {
  avtiveJobId: number = 0;
  jobObj: any;
  userInfo: any;
  isLoggedIn: boolean = false;
  jobApplicationObj = {
  "ApplicationId": 0,
  "JobId": 0,
  "JobSeekerId": 0,
  "AppliedDate":new Date(),
  "ApplcationStatus": "New"
  }


  constructor(private activateRoute: ActivatedRoute, private jobSrc: JobService){
    const userData = localStorage.getItem('jobLoginUser');
    if(userData == null){
      this.isLoggedIn = false;
    }else{
      this.isLoggedIn = true;
      this.userInfo = JSON.parse(userData);
      this.jobApplicationObj.JobSeekerId = this.userInfo.jobSeekerId;
    }

    this.activateRoute.params.subscribe((res:any)=>{
      this.avtiveJobId = res.jobid;
      this.getJobDetails();
      this.jobApplicationObj.JobId = this.avtiveJobId;
    })
  }

  getJobDetails(){
    this.jobSrc.GetJobListingById(this.avtiveJobId).subscribe((Res:any)=>{
      this.jobObj = Res;

    })
  }
  apply(){
    this.jobSrc.SendJobApplication(this.jobApplicationObj).subscribe((Res:any)=>{
      console.log(Res);
      if(Res.result){
     // console.log(Res.result);

        alert("You Have Succefully Applied to job")
      }else{
        alert(Res.message)
      }
    })
  }

}
