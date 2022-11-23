using AsuDemo.Application.DepartmentService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AsuDemo.Api.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
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
            return Ok(response);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AppResponse<Department> response = await _departmentService.GetById(id);
            return Ok(response);
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
