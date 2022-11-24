import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentAddComponent } from './department-add/department-add.component';
import { MultiSelectModule } from 'primeng/multiselect';


@NgModule({
  declarations: [
    DepartmentListComponent,
    DepartmentAddComponent
  ],
  imports: [
    CommonModule,
    DepartmentRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MultiSelectModule,
  ]
})
export class DepartmentModule { }
