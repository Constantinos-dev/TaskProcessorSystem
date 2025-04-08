import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobListComponent } from './job-list/job-list.component';
import { JobSubmitComponent } from './job-submit/job-submit.component';

export const routes: Routes = [
  { path: '', component: JobListComponent },
  { path: 'submit', component: JobSubmitComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
