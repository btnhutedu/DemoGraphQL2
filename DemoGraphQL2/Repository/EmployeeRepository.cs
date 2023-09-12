using DemoGraphQL2.Data;
using DemoGraphQL2.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL2.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Employee> GetEmployees()
        {
            var employees = _appDbContext?.Employees?.ToList() ?? new List<Employee>();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _appDbContext?.Employees.Include(e => e.Department)?.FirstOrDefault(e => e.EmployeeId == id);
            return employee;
        }

        public List<Employee> GetEmployeesWithDepartment()
        {
            var employees = _appDbContext?.Employees.Include(e => e.Department)?.ToList() ?? new List<Employee>();
            return employees;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                var result = await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return new Employee();
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                var result = _appDbContext.Employees.Update(employee);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                return new Employee();
            }
        }
    }
}
