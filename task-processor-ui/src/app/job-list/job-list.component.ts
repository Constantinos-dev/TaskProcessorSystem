import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Job {
  id: string;
  type: string;
  payloadJson: string;
  status: string;
  retryCount: number;
  createdAt: string;
  completedAt: string | null;
  errorMessage: string | null;
}

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
})
export class JobListComponent implements OnInit {
  jobs: Job[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Job[]>('/api/jobs').subscribe((data) => {
      this.jobs = data;
    });
  }
}
