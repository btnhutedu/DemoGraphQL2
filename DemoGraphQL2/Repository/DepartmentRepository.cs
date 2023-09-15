using DemoGraphQL2.Data;
using DemoGraphQL2.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL2.Repository
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext sampleAppDbContext)
        {
            _appDbContext = sampleAppDbContext;
        }

        public Department GetDetailDepartment(int id)
        {
            var department = _appDbContext?.Departments?.Where(x => x.DepartmentId == id).FirstOrDefault();
            return department;
        }

        public List<Department> GetAllDepartmentOnly()
        {
            var departments = _appDbContext?.Departments?.ToList();
            return departments ?? new List<Department>();
        }

        public List<Department> GetAllDepartmentsWithEmployee()
        {
            var result = _appDbContext?.Departments?.Include(d => d.Employees)?.ToList() ?? new List<Department>();
            return result;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            try
            {
                var result = await _appDbContext.Departments.AddAsync(department);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return new Department();
            }
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            try
            {
                var result = _appDbContext.Departments.Update(department);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return new Department();
            }
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            try
            {
                var isExist = _appDbContext.Departments.Find(id);
                if (isExist != null)
                {
                    var result = _appDbContext.Departments.Remove(isExist);
                    await _appDbContext.SaveChangesAsync();
                    return result.Entity;
                }
                return new Department();
            }
            catch (Exception)
            {
                return new Department();
            }
        }
    }
}
