using PowerCo.Model;
using PowerCoWebSite.Data.Repositories;
using System.Collections.Generic;

namespace PowerCoWebSite.ViewModels
{
    public class EmployeesViewModel
    {
        private IEmployeesRepository employeeRepository;

        public EmployeesViewModel()
        {
            employeeRepository = new EmployeesRepository();
            GetEmployees();
        }

        public IEnumerable<Employee> Employees { get; set; }

        private void GetEmployees()
        {
            Employees = employeeRepository.GetEmployees();
        }
    }
}