namespace AsuDemo.Domain.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PrerequisiteCourseId { get; set; }
        public List<int> DepartmentCourses { get; set; }
    }
}
