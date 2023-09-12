using System.ComponentModel.DataAnnotations;

namespace DemoGraphQL2.QueryModel
{
    public class EmployeeQueryModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}
