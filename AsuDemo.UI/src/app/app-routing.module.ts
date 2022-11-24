import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [
  //{
  //  path: '', component: AppComponent, pathMatch: 'full'
  //},
  {
    path: 'department',
    loadChildren: () => import('./modules/department/department.module').then((d) => d.DepartmentModule)
  },
  {
    path: 'course',
    loadChildren: () => import('./modules/course/course.module').then((d) => d.CourseModule)
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
