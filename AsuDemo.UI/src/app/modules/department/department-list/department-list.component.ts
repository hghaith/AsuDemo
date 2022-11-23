import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../department.service';
import { Department } from '../models/department';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  departments: Array<Department> = new Array<Department>();

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.departmentService.getList().subscribe((result) => {
      if (result.isSuccess) {
        this.departments = result.data;
        console.log(this.departments);
      }
    })
  }

}
