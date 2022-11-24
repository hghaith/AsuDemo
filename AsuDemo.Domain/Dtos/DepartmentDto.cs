namespace AsuDemo.Domain.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> DepartmentCourses { get; set; }
    }
}
