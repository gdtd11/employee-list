import { Injectable } from '@angular/core';
import { HttpSpinnerService } from './http-spinner.service';
import { Job } from '../models/Job';

@Injectable({
  providedIn: 'root'
})
export class JobService {

constructor(private httpSpinner: HttpSpinnerService) { }

  getAllJobs() {
    return this.httpSpinner.get<Job[]>('/jobs');
  }

}
