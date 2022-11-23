using AsuDemo.Common.AuditableEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsuDemo.Domain.Entities
{
    public class Course : AuditableEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int? PrerequisiteCourseId { get; set; }
        [ForeignKey("PrerequisiteCourseId")]
        public Course PrerequisiteCourse { get; set; }
    }
}
