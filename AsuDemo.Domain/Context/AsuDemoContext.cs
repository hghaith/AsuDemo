using AsuDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Domain.Context
{
    public class AsuDemoContext : DbContext
    {
        public AsuDemoContext(DbContextOptions<AsuDemoContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }

    }
}
