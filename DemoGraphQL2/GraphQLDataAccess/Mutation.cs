using DemoGraphQL2.Model;
using DemoGraphQL2.QueryModel;
using DemoGraphQL2.Repository;
using HotChocolate.Subscriptions;

namespace DemoGraphQL2.GraphQLDataAccess
{
    public class Mutation
    {
        public async Task<Department> CreateDepartment(
            [Service] DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender,
            DepartmentQueryModel department)
        {
            var createDepartment = new Department
            {
                Name = department.Name
            };

            var createdDepartment = await departmentRepository.CreateDepartment(createDepartment);
            await eventSender.SendAsync("DepartmentCreated", createdDepartment);
            return createdDepartment;
        }

        public async Task<Department> UpdateDepartment(
            [Service] DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender,
            DepartmentQueryModel department)
        {
            var updateDepartment = new Department
            {
                Name = department.Name,
                DepartmentId = department.DepartmentId
            };

            var updatedDepartment = await departmentRepository.UpdateDepartment(updateDepartment);
            await eventSender.SendAsync("DepartmentUpdated", updatedDepartment);
            return updatedDepartment;
        }

        public async Task<Employee> CreateEmploye(
            [Service] EmployeeRepository employeeRepository,
            [Service] ITopicEventSender eventSender,
            EmployeeQueryModel employee)
        {
            Employee createEmployee = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email
            };

            Employee createdEmployee = await employeeRepository.CreateEmployee(createEmployee);
            await eventSender.SendAsync("EmployeeCreated", createdEmployee);
            return createdEmployee;
        }

        public async Task<Employee> UpdateEmployee(
            [Service] EmployeeRepository employeeRepository,
            [Service] ITopicEventSender eventSender,
            EmployeeQueryModel employee)
        {
            Employee updateEmployeee = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email
            };

            Employee updatedEmployee = await employeeRepository.UpdateEmployee(updateEmployeee);
            await eventSender.SendAsync("EmployeeUpdated", updatedEmployee);
            return updatedEmployee;
        }
    }
}
