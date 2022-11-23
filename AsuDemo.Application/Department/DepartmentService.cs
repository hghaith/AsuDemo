using AsuDemo.Common.Response;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Application.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        // I am not using Repository Pattern just for simplicity
        private readonly AsuDemoContext _asuDemoContext;

        public DepartmentService(AsuDemoContext asuDemoContext)
        {
            _asuDemoContext = asuDemoContext;
        }

        public async Task<AppResponse> Add(DepartmentDto departmentDto)
        {
            // I am not use mapping just for simplicity

            Department department = new()
            {
                IsDeleted = false,
                Id = departmentDto.Id,
                Name = departmentDto.Name
            };

            if (departmentDto.Id == 0)
            {
                await _asuDemoContext.Departments.AddAsync(department);
            }
            else
            {
                _asuDemoContext.Attach(department);
                _asuDemoContext.Entry(department).State = EntityState.Modified;
                _asuDemoContext.Update(department);
            }

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> Delete(int id)
        {
            Department department = await _asuDemoContext.Departments.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (department is null)
            {
                return AppResponse.Error("department doesn't exist");
            }

            department.IsDeleted = true;
            _asuDemoContext.Entry(department).State = EntityState.Modified;

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse<Department>> GetById(int id)
        {
            Department department = await _asuDemoContext.Departments.Include(x => x.Courses)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            return AppResponse<Department>.Success(department);
        }

        public async Task<AppResponse<List<Department>>> List()
        {
            List<Department> departments = await _asuDemoContext.Departments.Where(x => !x.IsDeleted).ToListAsync();

            return AppResponse<List<Department>>.Success(departments);
        }
    }
}
