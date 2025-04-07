import { Component } from '@angular/core';
import { JobService, Job } from '../job.service';

@Component({
  selector: 'app-job-submit',
  templateUrl: './job-submit.component.html'
})
export class JobSubmitComponent {
  job: Job = {
    type: '',
    payloadJson: ''
  };

  constructor(private jobService: JobService) { }

  submitJob() {
    this.jobService.submitJob(this.job).subscribe({
      next: res => alert('Job submitted successfully!'),
      error: err => alert('Error submitting job.')
    });
  }
}
