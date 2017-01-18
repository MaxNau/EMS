using PowerCo.Model;
using PowerCoWebSite.Data;
using PowerCoWebSite.Data.Repositories;
using PowerCoWebSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace PowerCoWebSite.ViewModels
{
    public class EditEmployeeViewModel
    {
        private IEmployeesRepository employeeRepository;
        private IDepartmentRepository departmentRepository;

        public EditEmployeeViewModel()
        {
            employeeRepository = new EmployeesRepository();
            departmentRepository = new DepartmentRepository();

            using (var context = new PowerCoEntity())
            {
                Departments = context.Deprtments.ToList();
                Positions = context.EmployeePositions.ToList();
                LeadEmployees = context.Employees.Where(e => e.Position.Name == "Lead").ToList();
            }
        }

        public Employee Employee { get; set; }
        public List<Department> Departments { get; set; }
        public List<EmployeePosition> Positions { get; set; }
        public List<Employee> LeadEmployees { get; set; }

        public int SelectedDepartmentId { get; set; }

        public int SelectedPositionId { get; set; }

        public int? SelectedHeadId { get; set; }

        public void GetEmployee(int id)
        {
            Employee = employeeRepository.GetEmployee(id);
        }

        public void SetDropDownListCurrentItems()
        {
            using (var context = new PowerCoEntity())
            {
                SelectedDepartmentId = context.Deprtments.FirstOrDefault(d => d.DepartmentName == Employee.Department.DepartmentName).DepartmentId;
                SelectedPositionId = context.EmployeePositions.FirstOrDefault(d => d.Name == Employee.Position.Name).Id;
            }
        }

        public void ModifyEmployee(int id)
        {
            Employee employee = new Employee();

            employee.Salary = Employee.Salary;
            employee.FullName = Employee.FullName;

            employeeRepository.ModifyEmployee(id, SelectedPositionId, SelectedDepartmentId, SelectedHeadId, employee);
        }

        public void RemoveEmployee(int id)
        {
            employeeRepository.RemoveEmployee(id);
        }
    }
}