using AsuDemo.Application.DepartmentCourseService;
using AsuDemo.Common.Response;
using AsuDemo.Domain.Context;
using AsuDemo.Domain.Dtos;
using AsuDemo.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace AsuDemo.Application.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        // I am not using Repository Pattern just for simplicity
        private readonly AsuDemoContext _asuDemoContext;
        private readonly IMapper _mapper;
        private readonly IDepartmentCourseService _departmentCourseService;

        public DepartmentService(AsuDemoContext asuDemoContext,
            IMapper mapper,
            IDepartmentCourseService departmentCourseService)
        {
            _asuDemoContext = asuDemoContext;
            _mapper = mapper;
            _departmentCourseService = departmentCourseService;
        }

        public async Task<AppResponse> Add(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);

            if (department.Id == 0)
            {
                await _asuDemoContext.Departments.AddAsync(department);
            }
            else
            {
                Department? oldDepartment = await _asuDemoContext.Departments.AsNoTracking().Include(x => x.DepartmentCourses).FirstOrDefaultAsync(x => x.Id == department.Id);
                await _departmentCourseService.UpdateDepartment(department.Id, department.DepartmentCourses);

                oldDepartment.Name = department.Name;

                _asuDemoContext.Attach(oldDepartment);
                _asuDemoContext.Entry(oldDepartment).State = EntityState.Modified;
                _asuDemoContext.Update(oldDepartment);
            }

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse> Delete(int id)
        {
            Department? department = await _asuDemoContext.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (department is null)
            {
                return AppResponse.Error("department doesn't exist");
            }

            _asuDemoContext.Departments.Remove(department);

            await _asuDemoContext.SaveChangesAsync();

            return AppResponse.Success();
        }

        public async Task<AppResponse<Department>> GetById(int id)
        {
            Department? department = await _asuDemoContext.Departments.Include(x => x.DepartmentCourses)
                .FirstOrDefaultAsync(x => x.Id == id);

            return AppResponse<Department>.Success(department);
        }

        public async Task<AppResponse<List<Department>>> List()
        {
            List<Department> departments = await _asuDemoContext.Departments.Include(x => x.DepartmentCourses).ToListAsync();

            return AppResponse<List<Department>>.Success(departments);
        }
    }
}
