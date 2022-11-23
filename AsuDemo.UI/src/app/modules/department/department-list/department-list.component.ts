import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Result } from '../../../../shared/models/result';
import { CourseService } from '../../course/course.service';
import { Course } from '../../course/models/course';
import { DepartmentService } from '../department.service';
import { Department } from '../models/department';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  departments: Array<Department> = new Array<Department>();
  courses: Array<Course> = new Array<Course>();

  constructor(private departmentService: DepartmentService,
    private router: Router,
    private courseService: CourseService) { }

  ngOnInit(): void {
    this.getDepartments();

  }

  getDepartments = () => {
    this.departmentService.getList().subscribe((result: Result<Array<Department>>) => {
      if (result.isSuccess) {
        this.departments = result.data;
      }
    })
  }

  getCourses = () => {
    this.courseService.getList().subscribe((result: Result<Array<Course>>) => {
      if (result.isSuccess) {
        this.courses = result.data;
      }
    })
  }

  add = () => {
    this.router.navigate(['/department/add']);
  }

}
