using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Mapster;

namespace AsuDemo.Application.DepartmentService.Mapping
{
    public class DepartmentMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Department, DepartmentDto>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null && s.DepartmentCourses.Count != 0 ?
                s.DepartmentCourses.Select(x => x.CourseId) : null);

            config.NewConfig<DepartmentDto, Department>()
                .Map(d => d.DepartmentCourses, s => s.DepartmentCourses != null ? s.DepartmentCourses.Select(courseId => new DepartmentCourse { CourseId = courseId }) : null);
        }
    }
}
