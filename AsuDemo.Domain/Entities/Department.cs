using AsuDemo.Common.AuditableEntity;
using System.ComponentModel.DataAnnotations;

namespace AsuDemo.Domain.Entities
{
    public class Department  : AuditableEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
