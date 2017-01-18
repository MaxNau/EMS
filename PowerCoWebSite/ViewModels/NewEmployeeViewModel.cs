using PowerCo.Model;
using PowerCoWebSite.Data.Repositories;
using PowerCoWebSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerCoWebSite.ViewModels
{
    public class NewEmployeeViewModel
    {
        private IDepartmentRepository departmentRepository;
        private IEmployeesRepository employeesRepository;

        public NewEmployeeViewModel()
        {
            departmentRepository = new DepartmentRepository();
            employeesRepository = new EmployeesRepository();
            
            Departments = departmentRepository.GetDepartments();
            Positions = departmentRepository.GetEmployeePositions();      
        }

        public int EmployeeId { get; set; }

        [Required, MaxLength(64)]
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string Head { get; set; }

        [Required]
        public double Salary { get; set; }
        public List<Department> Departments { get; set; }
        public List<EmployeePosition> Positions { get; set; }

        public int SelectedDepartmentId { get; set; }

        public int SelectedPositionId { get; set; }

        public int? SelectedHeadId { get; set; }

        public void AddEmployee()
        {
            Employee employee = new Employee
            {
                FullName = FullName,
                Salary = Salary,
                Position = departmentRepository.GetPosition(SelectedPositionId),
                Department = departmentRepository.GetDepartment(SelectedDepartmentId)
            };

            if (SelectedHeadId != null)
                employee.Head = employeesRepository.GetHeadName(SelectedHeadId.Value);
            else employee.Head = "";

            employeesRepository.AddEmployee(employee);
        }
    }
}