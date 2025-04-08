import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { JobService, Job } from '../services/job.service';

@Component({
  selector: 'app-job-submit',
  templateUrl: './job-submit.component.html',
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class JobSubmitComponent {
  jobType: string = '';
  payload: string = ''; // Changed from payloadJson to match your HTML

  constructor(private http: HttpClient, private jobService: JobService) { }

  submitJob() {
    const job: Job = {
      type: this.jobType,
      payloadJson: this.payload, // Using payload from the form
  retryCount: 0,      };

        this.jobService.submitJob(job).subscribe({
          next: (data: any) => {
            alert('Job submitted successfully');
            this.jobType = '';
            this.payload = '';          },
          error: (error) => {
            console.error('Error fetching jobs:', error);
          }
        });
  }
}