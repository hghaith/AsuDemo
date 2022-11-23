using AsuDemo.Common.Response;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Application.CourseService
{
    public class CourseService : ICourseService
    {
        // I am not using Repository Pattern just for simplicity
        private readonly AsuDemoContext _asuDemoContext;

        public CourseService(AsuDemoContext asuDemoContext)
        {
            _asuDemoContext = asuDemoContext;
        }

        public async Task<AppResponse> Add(CourseDto courseDto)
        {
            // I am not use mapping just for simplicity

            Course course = new()
            {
                IsDeleted = false,
                Id = courseDto.Id,
                Name = courseDto.Name,
                DepartmentId = courseDto.DepartmentId,
                PrerequisiteCourseId = courseDto.PrerequisiteCourseId,
            };

            if (courseDto.Id == 0)
            {
                await _asuDemoContext.Courses.AddAsync(course);
            }
            else
            {
                _asuDemoContext.Attach(course);
                _asuDemoContext.Entry(course).State = EntityState.Modified;
                _asuDemoContext.Update(course);
            }

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> Delete(int id)
        {
            Course course = await _asuDemoContext.Courses.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (course is null)
            {
                return AppResponse.Error("course doesn't exist");
            }

            course.IsDeleted = true;
            _asuDemoContext.Entry(course).State = EntityState.Modified;

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse<Course>> GetById(int id)
        {
            Course course = await _asuDemoContext.Courses.Include(x => x.PrerequisiteCourse)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            return AppResponse<Course>.Success(course);
        }

        public async Task<AppResponse<List<Course>>> List()
        {
            List<Course> courses = await _asuDemoContext.Courses.Where(x => !x.IsDeleted).ToListAsync();

            return AppResponse<List<Course>>.Success(courses);
        }
    }
}
