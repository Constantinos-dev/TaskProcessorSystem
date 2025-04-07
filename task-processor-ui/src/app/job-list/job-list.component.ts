import { Component, OnInit } from '@angular/core';
import { JobService, Job } from '../job.service';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html'
})
export class JobListComponent implements OnInit {
  jobs: Job[] = [];

  constructor(private jobService: JobService) { }

  ngOnInit() {
    this.jobService.getJobs().subscribe({
      next: data => console.log(data),
      error: error => console.error(error),
      complete: () => console.log('Completed')
    });
  }
}
