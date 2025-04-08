import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

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
  private baseUrl = 'https://localhost:7101';

  constructor(private http: HttpClient) { }

  submitJob(job: Job): Observable<Job> {
    return this.http.post<Job>(`${this.baseUrl}/jobs`, job);
  }

  getJobs() {
    return this.http.get(`${this.baseUrl}/jobs`).pipe(
      catchError(error => {
        console.error('Error fetching jobs:', error);
        return throwError('An error occurred while retrieving jobs. Please try again later.');
      })
    );
  }
}
