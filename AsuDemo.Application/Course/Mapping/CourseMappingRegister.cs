using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Mapster;

namespace AsuDemo.Application.CourseService.Mapping
{
    public class CourseMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseDto>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null && s.DepartmentCourses.Count != 0 ?
                s.DepartmentCourses.Select(x => x.DepartmentId) : null);

            config.NewConfig<DepartmentDto, Department>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null ? s.DepartmentCourses.Select(departmentId => new DepartmentCourse { DepartmentId = departmentId }) : null);
        }
    }
}
