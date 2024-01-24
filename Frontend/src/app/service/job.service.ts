import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class JobService {
  apiEndPoint: string = 'https://localhost:7111/api/Job/';

  constructor(private http: HttpClient) {}

  registerEmployer(obj: any) {
    return this.http.post(this.apiEndPoint + 'AddNewEmployer', obj);
  }
  registerAsJobSeeker(obj: any) {
    return this.http.post(this.apiEndPoint + 'AddNewJobSeeker', obj);
  }
  login(obj: any) {
    return this.http.post(this.apiEndPoint + 'login', obj);
  }
  getAllCategory() {
    return this.http.get(this.apiEndPoint + 'GetAllJobCategory');
  }
  createNewJob(obj: any) {
    return this.http.post(this.apiEndPoint + 'CreateNewJobListing', obj);
  }
  GetActiveJobs() {
    return this.http.get(this.apiEndPoint + 'GetActiveJobListing');
  }
  GetJobListingById(jobid: number) {
    return this.http.get(this.apiEndPoint + 'GetJobListingById?jobId=' + jobid);
  }
  SendJobApplication(obj: any) {
    console.log(obj);
    return this.http.post(this.apiEndPoint + 'SendJobApplication', obj);
  }
  GetJobsByEmployerId(employerid: number) {
    return this.http.get(
      this.apiEndPoint + 'GetJobsByEmployerId?employerId=' + employerid
    );
  }
  // updateNewJob(obj: any) {
  //   return this.http.put(this.apiEndPoint + 'UpdateJobListing', obj);
  // }
  updateNewJob(jobId: number) {
    return this.http.put(`${this.apiEndPoint}UpdateJobListing?jobId=${jobId}`, {});
  }
  
  DeleteJobById(jobId: Number){
    return this.http.delete(this.apiEndPoint + 'DeleteJobById?jobId=' + jobId);
  }
}
