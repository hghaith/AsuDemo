using AsuDemo.Application.CourseService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace AsuDemo.Api.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService,
            IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
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
            AppResponse<List<CourseDto>> mappedResponse = _mapper.Map<AppResponse<List<CourseDto>>>(response);
            return Ok(mappedResponse);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AppResponse<Course> response = await _courseService.GetById(id);
            AppResponse<CourseDto> mappedResponse = _mapper.Map<AppResponse<CourseDto>>(response);
            return Ok(mappedResponse);
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
