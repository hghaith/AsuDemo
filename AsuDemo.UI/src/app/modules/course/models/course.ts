export class Course {
  id: number = 0;
  name: string = '';
  prerequisiteCourseId: number = 0;
  departmentCourses: Array<number> = new Array<number>();
}
