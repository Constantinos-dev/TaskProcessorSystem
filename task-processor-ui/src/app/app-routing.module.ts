import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobSubmitComponent } from './job-submit/job-submit.component';
import { JobListComponent } from './job-list/job-list.component';

const routes: Routes = [
  { path: 'submit', component: JobSubmitComponent },
  { path: 'jobs', component: JobListComponent },
  { path: '', redirectTo: 'submit', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
