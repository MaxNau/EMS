using PowerCo.Model;
using PowerCoWebSite.Data.Repositories;
using PowerCoWebSite.Models;
using System.Collections.Generic;

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

            Departments = departmentRepository.GetDepartments();
            Positions = departmentRepository.GetEmployeePositions();
            LeadEmployees = employeeRepository.GetLeads();
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
            SelectedDepartmentId = departmentRepository.GetDepartmentIdByName(Employee.Department.DepartmentName);
            SelectedPositionId = departmentRepository.GetEmployeePositionIdByName(Employee.Position.Name);
            SelectedHeadId = employeeRepository.GetHeadIdByName(Employee.Head);        
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