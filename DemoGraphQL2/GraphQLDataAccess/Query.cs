using DemoGraphQL2.Model;
using DemoGraphQL2.Repository;

namespace DemoGraphQL2.GraphQLDataAccess
{
    public class Query
    {
        private readonly ILogger<Query> _logger;

        public Query(ILogger<Query> logger)
        {
            _logger = logger;
        }

        #region Employee

        public List<Employee> AllEmployee([Service] EmployeeRepository employeeRepository)
        {
            try
            {
                _logger.LogInformation("All employees retrieved successfully.");
                return employeeRepository.GetEmployees();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving employees.");
                return new List<Employee>();
            }
        }    
            
        public List<Employee> AllEmployeesWithDepartment([Service] EmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployeesWithDepartment();


        public Employee EmployeeById([Service] EmployeeRepository employeeRepository, int id) => 
            employeeRepository.GetEmployeeById(id);

        #endregion

        #region Departments

        public Department GetDepartmentById([Service] DepartmentRepository departmentRepository, int id) =>
            departmentRepository.GetDetailDepartment(id);

        public List<Department> GetAllDepartment([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentOnly();

        public List<Department> GetAllDepartmentsWithEmployee([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentsWithEmployee();

        #endregion
    }
}
