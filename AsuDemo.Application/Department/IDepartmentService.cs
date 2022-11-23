using AsuDemo.Common.Response;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;

namespace AsuDemo.Application.DepartmentService
{
    public interface IDepartmentService
    {
        Task<AppResponse<List<Department>>> List();
        Task<AppResponse> Add(DepartmentDto departmentDto);
        Task<AppResponse> Delete(int id);
        Task<AppResponse<Department>> GetById(int id);
    }
}
