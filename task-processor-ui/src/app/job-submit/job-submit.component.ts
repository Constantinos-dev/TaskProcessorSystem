import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-job-submit',
  templateUrl: './job-submit.component.html',
})
export class JobSubmitComponent {
  jobType: string = '';
  payloadJson: string = '';

  constructor(private http: HttpClient) { }

  submitJob() {
    const job = {
      type: this.jobType,
      payloadJson: this.payloadJson,
    };

    this.http.post('/api/jobs', job).subscribe(() => {
      alert('Job submitted successfully');
      this.jobType = '';
      this.payloadJson = '';
    });
  }
}
