using PowerCo.Model;
using PowerCoWebSite.Data;
using PowerCoWebSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace PowerCoWebSite.ViewModels
{
    public class NewEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Head { get; set; }
        public double Salary { get; set; }
        public List<Department> Departments { get; set; }
        public List<EmployeePosition> Positions { get; set; }

        public NewEmployeeViewModel()
        {
            using (var context = new PowerCoEntity())
            {
                Departments = context.Deprtments.ToList();
                Positions = context.EmployeePositions.ToList();
            }
        }

        public int SelectedDepartmentId { get; set; }

        public int SelectedPositionId { get; set; }
    }
}