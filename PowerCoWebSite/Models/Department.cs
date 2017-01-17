using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerCo.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get ; set; }
        public string DepartmentName { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}