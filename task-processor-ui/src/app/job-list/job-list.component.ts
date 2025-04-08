import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { JobService, Job } from '../services/job.service';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  standalone: true,
  imports: [CommonModule, DatePipe]
})
export class JobListComponent implements OnInit {
  jobs: Job[] = [];

  constructor(private jobService: JobService) { }

  ngOnInit(): void {
    this.jobService.getJobs().subscribe({
      next: (data: any) => {
        this.jobs = data as Job[];
      },
      error: (error) => {
        console.error('Error fetching jobs:', error);
      }
    });
  }
}