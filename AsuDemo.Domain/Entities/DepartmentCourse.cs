using System.ComponentModel.DataAnnotations.Schema;

namespace AsuDemo.Domain.Entities
{
    public class DepartmentCourse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
