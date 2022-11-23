import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

export const routes: Routes = [
  {
    path: 'department',
    loadChildren: () => import('./modules/department/department.module').then((d) => d.DepartmentModule)
  },
  {
    path: 'course',
    loadChildren: () => import('./modules/course/course.module').then((d) => d.CourseModule)
  },
  {
    path: '', component: AppComponent
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
