using PowerCo.Model;
using PowerCoWebSite.Data;
using PowerCoWebSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace PowerCoWebSite.ViewModels
{
    public class EditEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Head { get; set; }
        public double Salary { get; set; }
        public List<Department> Departments { get; set; }
        public List<EmployeePosition> Positions { get; set; }
        public List<Employee> LeadEmployees { get; set; }

        public EditEmployeeViewModel(string departmentName, string position)
        {
            DepartmentName = departmentName;
            Position = position;

            using (var context = new PowerCoEntity())
            {
                Departments = context.Deprtments.ToList();
                Positions = context.EmployeePositions.ToList();
                LeadEmployees = context.Employees.Where(e => e.Position == "Lead").ToList();
                SelectedDepartmentId = context.Deprtments.FirstOrDefault(d => d.DepartmentName == DepartmentName).DepartmentId;
                SelectedPositionId = context.EmployeePositions.FirstOrDefault(d => d.Name == Position).Id;
            }
        }

        public EditEmployeeViewModel() { }

        public int SelectedDepartmentId { get; set; }

        public int SelectedPositionId { get; set; }

        public int SelectedHeadId { get; set; }
    }
}