import { Component } from '@angular/core';
import { JobService } from 'src/app/service/job.service';

@Component({
  selector: 'app-job-listing',
  templateUrl: './job-listing.component.html',
  styleUrls: ['./job-listing.component.css']
})
export class JobListingComponent {
  userInfo: any;
  jobList: any [] = [];
  constructor(private jobSrv: JobService){
    const userData = localStorage.getItem('jobLoginUser');
    if(userData != null){
      this.userInfo = JSON.parse(userData);
      this.getJobsByEmploye();
    }
  }
  getJobsByEmploye(){
    this.jobSrv.GetJobsByEmployerId(this.userInfo.employerId).subscribe((res:any)=>{
      //this.jobList = res.data;
      this.jobList = res;

    });
  }
  deleteJob(event:any,jobId:Number){
    if(confirm('Are Your Sure to detete ?'))
    {
      event.target.innerText = "Deleting...";
      this.jobSrv.DeleteJobById(jobId).subscribe((res:any)=>{
        this.jobList =res;
        alert(res.message)
      });
    }
  }

}
