import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmptyResult, Result } from '../../../../shared/models/result';
import { DepartmentService } from '../../department/department.service';
import { Department } from '../../department/models/department';
import { CourseService } from '../course.service';
import { Course } from '../models/course';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  departments: Array<Department> = new Array<Department>();
  courses: Array<Course> = new Array<Course>();

  constructor(private courseService: CourseService,
    private departmentService: DepartmentService,
    private router: Router) { }

  ngOnInit(): void {
    this.getCourses();
    this.getDepartments();
  }

  getCourses = () => {
    this.courseService.getList().subscribe((result: Result<Array<Course>>) => {
      if (result.isSuccess) {
        this.courses = result.data;
      }
    })
  }

  getDepartments = () => {
    this.departmentService.getList().subscribe((result: Result<Array<Department>>) => {
      if (result.isSuccess) {
        this.departments = result.data;
      }
    })
  }

  getPrerequisiteCourseNmae = (prerequisiteCourseId: number): string => {
    let text = this.courses?.find(x => x.id == prerequisiteCourseId)?.name as string;

    return text ?? '-';
  }

  getDepartmentName = (departmentId: number): string => {
    debugger;
    if (!this.departments.length) return '';
    let department = this.departments?.find(x => x.id == departmentId) as Department;

    return department?.name;
  }

  delete = (id: number) => {
    this.courseService.delete(id).subscribe((result: EmptyResult) => {
      if (result.isSuccess) {
        this.getCourses();
      }
    })
  }

  edit = (id: number) => {
    this.router.navigate([`/course/add/${id}`]);
  }

}
