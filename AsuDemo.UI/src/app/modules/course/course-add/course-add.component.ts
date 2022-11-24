import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmptyResult, Result } from '../../../../shared/models/result';
import { DepartmentService } from '../../department/department.service';
import { Department } from '../../department/models/department';
import { CourseService } from '../course.service';
import { Course } from '../models/course';

@Component({
  selector: 'app-course-add',
  templateUrl: './course-add.component.html',
  styleUrls: ['./course-add.component.css']
})
export class CourseAddComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  course: Course = new Course();
  departments: Array<Department> = new Array<Department>();
  courses: Array<Course> = new Array<Course>();

  constructor(private courseService: CourseService,
    private departmentService: DepartmentService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id'];

    if (id != undefined) {
      this.getById(Number(id));
    }

    this.initializeForm();

    this.getCourses();
    this.getDepartments();
  }

  initializeForm = () => {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', Validators.required),
      prerequisiteCourseId: new FormControl(null),
      departmentCourses: new FormControl([])
    })
  }

  getById = (id: number) => {
    this.courseService.getById(id).subscribe((result: Result<Course>) => {
      this.course = result.data;
      this.form.patchValue(this.course);
    })
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

  add = () => {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.course = this.form.value;

    this.courseService.add(this.course).subscribe((result: EmptyResult) => {
      if (result.isSuccess) {
        this.router.navigate(['course/list']);
      }
    })
  }

}
