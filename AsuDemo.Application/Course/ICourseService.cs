using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;

namespace AsuDemo.Application.CourseService
{
    public interface ICourseService
    {
        Task<AppResponse<List<Course>>> List();
        Task<AppResponse> Add(CourseDto courseDto);
        Task<AppResponse> Delete(int id);
        Task<AppResponse<Course>> GetById(int id);
    }
}
