using AsuDemo.Application.CourseService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AsuDemo.Api.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(CourseDto courseDto)
        {
            AppResponse response = await _courseService.Add(courseDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            AppResponse<List<Course>> response = await _courseService.List();
            return Ok(response);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AppResponse<Course> response = await _courseService.GetById(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AppResponse response = await _courseService.Delete(id);
            return Ok(response);
        }

    }
}
