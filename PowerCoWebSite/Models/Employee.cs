
using PowerCoWebSite.Models;

namespace PowerCo.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public Department Department { get; set; }
        public EmployeePosition Position { get; set; }
        public string Head { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            Department = new Department();
            Position = new EmployeePosition();
        }
    }
}
