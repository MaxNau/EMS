using PowerCo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerCoWebSite.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}