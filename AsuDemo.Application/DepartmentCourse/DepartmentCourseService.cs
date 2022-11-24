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
            await ClearDepartmentCourses(departmentId);

            departmentCourses.ForEach((itm) =>
            {
                itm.DepartmentId = departmentId;
            });

            _asuDemoContext.DepartmentCourses.AddRange(departmentCourses);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> ClearDepartmentCourses(int departmentId)
        {
            List<DepartmentCourse> oldDepartmentCourses = await _asuDemoContext.DepartmentCourses.Where(x => x.DepartmentId == departmentId).ToListAsync();

            _asuDemoContext.RemoveRange(oldDepartmentCourses);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> UpdateDepartment(List<DepartmentCourse> departmentCourses, int courseId)
        {
            await ClearCoursesRelatedToDepartment(courseId);

            departmentCourses.ForEach((itm) =>
            {
                itm.CourseId = courseId;
            });

            _asuDemoContext.DepartmentCourses.AddRange(departmentCourses);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> ClearCoursesRelatedToDepartment(int courseId)
        {
            List<DepartmentCourse> oldDepartmentCourses = await _asuDemoContext.DepartmentCourses.Where(x => x.CourseId == courseId).ToListAsync();

            _asuDemoContext.RemoveRange(oldDepartmentCourses);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }
    }
}
