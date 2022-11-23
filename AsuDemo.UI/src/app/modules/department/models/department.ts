import { DepartmentCourse } from "./department-course";

export class Department {
  id: number = 0;
  name: string = '';
  departmentCourses: Array<DepartmentCourse> = new Array<DepartmentCourse>();
}
