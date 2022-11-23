using AsuDemo.Common.Response;
using AsuDemo.Domain.Entities;

namespace AsuDemo.Application.DepartmentCourseService
{
    public interface IDepartmentCourseService
    {
        Task<AppResponse> UpdateDepartment(int departmentId, List<DepartmentCourse> departmentCourses);
    }
}
