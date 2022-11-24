using AsuDemo.Application.DepartmentCourseService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Application.CourseService
{
    public class CourseService : ICourseService
    {
        // I am not using Repository Pattern just for simplicity
        private readonly AsuDemoContext _asuDemoContext;
        private readonly IMapper _mapper;
        private readonly IDepartmentCourseService _departmentCourseService;

        public CourseService(AsuDemoContext asuDemoContext,
            IMapper mapper,
            IDepartmentCourseService departmentCourseService)
        {
            _asuDemoContext = asuDemoContext;
            _mapper = mapper;
            _departmentCourseService = departmentCourseService;
        }

        public async Task<AppResponse> Add(CourseDto courseDto)
        {
            Course course = _mapper.Map<Course>(courseDto);

            if (course.Id == 0)
            {
                await _asuDemoContext.Courses.AddAsync(course);
            }
            else
            {
                Course? oldCourse = await _asuDemoContext.Courses.AsNoTracking().Include(x => x.DepartmentCourses).FirstOrDefaultAsync(x => x.Id == course.Id);
                await _departmentCourseService.UpdateDepartment(course.DepartmentCourses, course.Id);

                oldCourse.Name = course.Name;
                oldCourse.PrerequisiteCourseId = course.PrerequisiteCourseId;

                _asuDemoContext.Attach(oldCourse);
                _asuDemoContext.Entry(oldCourse).State = EntityState.Modified;
                _asuDemoContext.Update(oldCourse);
            }

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> Delete(int id)
        {
            Course course = await _asuDemoContext.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (course is null)
            {
                return AppResponse.Error("Course doesn't exist");
            }

            await _departmentCourseService.ClearCoursesRelatedToDepartment(id);

            _asuDemoContext.Courses.Remove(course);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse<Course>> GetById(int id)
        {
            Course course = await _asuDemoContext.Courses.Include(x => x.DepartmentCourses)
                .FirstOrDefaultAsync(x => x.Id == id);

            return AppResponse<Course>.Success(course);
        }

        public async Task<AppResponse<List<Course>>> List()
        {
            List<Course> courses = await _asuDemoContext.Courses.Include(x => x.DepartmentCourses).ToListAsync();

            return AppResponse<List<Course>>.Success(courses);
        }
    }
}
