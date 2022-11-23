using AsuDemo.Application.DepartmentService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace AsuDemo.Api.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService,
            IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(DepartmentDto departmentDto)
        {
            AppResponse response = await _departmentService.Add(departmentDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            AppResponse<List<Department>> response = await _departmentService.List();
            AppResponse<List<DepartmentDto>> mappedResponse = _mapper.Map<AppResponse<List<DepartmentDto>>>(response);
            return Ok(mappedResponse);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AppResponse<Department> response = await _departmentService.GetById(id);
            AppResponse<DepartmentDto> mappedResponse = _mapper.Map<AppResponse<DepartmentDto>>(response);
            return Ok(mappedResponse);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AppResponse response = await _departmentService.Delete(id);
            return Ok(response);
        }

    }
}
