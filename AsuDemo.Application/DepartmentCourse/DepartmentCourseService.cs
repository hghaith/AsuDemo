using AsuDemo.Common.Response;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Application.DepartmentCourseService
{
    public class DepartmentCourseService : IDepartmentCourseService
    {
        private readonly AsuDemoContext _asuDemoContext;
        public DepartmentCourseService(AsuDemoContext asuDemoContext)
        {
            _asuDemoContext = asuDemoContext;
        }

        public async Task<AppResponse> UpdateDepartment(int departmentId, List<DepartmentCourse> departmentCourses)
        {
            List<DepartmentCourse> oldDepartmentCourses = await _asuDemoContext.DepartmentCourses.Where(x => x.DepartmentId == departmentId).ToListAsync();

            _asuDemoContext.RemoveRange(oldDepartmentCourses);
            _asuDemoContext.DepartmentCourses.AddRange(departmentCourses);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }
    }
}
