import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseAddComponent } from './course-add/course-add.component';
import { CourseListComponent } from './course-list/course-list.component';

const routes: Routes = [
  { path: 'list', component: CourseListComponent },
  { path: 'add', component: CourseAddComponent },
  { path: 'add/:id', component: CourseAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
