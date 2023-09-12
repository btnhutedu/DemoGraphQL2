using DemoGraphQL2.Model;
using DemoGraphQL2.Repository;

namespace DemoGraphQL2.GraphQLDataAccess
{
    public class Query
    {
        #region Employee

        public List<Employee> AllEmployee([Service] EmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployees();

        public List<Employee> AllEmployeesWithDepartment([Service] EmployeeRepository employeeRepository) =>
            employeeRepository.GetEmployeesWithDepartment();


        public Employee EmployeeById([Service] EmployeeRepository employeeRepository, int id) => 
            employeeRepository.GetEmployeeById(id);

        #endregion

        #region Departments

        public List<Department> GetAllDepartment([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentOnly();

        public List<Department> GetAllDepartmentsWithEmployee([Service] DepartmentRepository departmentRepository) =>
            departmentRepository.GetAllDepartmentsWithEmployee();

        #endregion
    }
}
