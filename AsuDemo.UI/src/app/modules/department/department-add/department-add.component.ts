import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmptyResult } from '../../../../shared/models/result';
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
    private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm = () => {
    this.form = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', Validators.required),
      departmentCourses: new FormControl([])
    })
  }

  add = () => {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    debugger;

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
