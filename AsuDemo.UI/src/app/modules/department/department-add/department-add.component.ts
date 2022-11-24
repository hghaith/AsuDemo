import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmptyResult, Result } from '../../../../shared/models/result';
import { CourseService } from '../../course/course.service';
import { Course } from '../../course/models/course';
import { DepartmentService } from '../department.service';
import { Department } from '../models/department';

@Component({
  selector: 'app-department-add',
  templateUrl: './department-add.component.html',
  styleUrls: ['./department-add.component.css']
})
export class DepartmentAddComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  department: Department = new Department();
  courses: Array<Course> = new Array<Course>();

  constructor(private departmentService: DepartmentService,
    private router: Router,
    private courseService: CourseService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id'];

    if (id != undefined) {
      this.getById(Number(id));
    }

    this.initializeForm();
    this.getCourses();
  }

  initializeForm = () => {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', Validators.required),
      departmentCourses: new FormControl([])
    })
  }

  getById = (id: number) => {
    this.departmentService.getById(id).subscribe((result: Result<Department>) => {
      this.department = result.data;
      this.form.patchValue(this.department);
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
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.department = this.form.value;

    this.departmentService.add(this.department).subscribe((result: EmptyResult) => {
      if (result.isSuccess) {
        this.router.navigate(['department/list']);
      }
    })
  }

  back = () => {
    this.router.navigate(['department/list']);
  }

}
