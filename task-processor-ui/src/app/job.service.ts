import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Job {
  id?: string;
  type: string;
  payloadJson: string;
  status?: string;
  retryCount?: number;
  createdAt?: string;
  completedAt?: string;
  errorMessage?: string;
}

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = 'http://localhost:4200/api/jobs';

  constructor(private http: HttpClient) { }

  submitJob(job: Job): Observable<Job> {
    return this.http.post<Job>(this.apiUrl, job);
  }

  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.apiUrl);
  }
}
