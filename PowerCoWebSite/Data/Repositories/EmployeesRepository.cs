using System.Collections.Generic;
using PowerCo.Model;
using System.Linq;
using System.Data.Entity;
using System;

namespace PowerCoWebSite.Data.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void AddEmployee(Employee employee)
        {
            using (var context = new PowerCoEntity())
            {
                context.EmployeePositions.Attach(employee.Position);
                context.Deprtments.Attach(employee.Department);
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Employees
                              .Include(e => e.Department)
                              .Include(e => e.Position)
                              .FirstOrDefault(e => id == e.EmployeeId);
            }
        }

        public List<Employee> GetEmployees()
        {
            using (var context = new PowerCoEntity())
            {
                return context.Employees
                              .Include(e => e.Department)
                              .Include(e => e.Position)
                              .ToList();
            }
        }

        public int GetHeadIdByName(string name)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Employees.FirstOrDefault(e => e.FullName == name).EmployeeId;
            }
        }

        public string GetHeadName(int headId)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Employees.FirstOrDefault(e => e.EmployeeId == headId).FullName;
            }
        }

        public List<Employee> GetLeads()
        {
            using (var context = new PowerCoEntity())
            {
                return context.Employees.Where(e => e.Position.Name == "Lead").ToList();
            }
        }

        public void ModifyEmployee(int id, int selectedPositionId, int selectedDepartmentId, int? selectedHeadId, Employee employee)
        {
            using (var context = new PowerCoEntity())
            {
                Employee emp = context.Employees.FirstOrDefault(e=> e.EmployeeId == id);
                emp.Salary = employee.Salary;
                emp.FullName = employee.FullName;
                emp.Department = employee.Department;
                emp.Position = context.EmployeePositions.FirstOrDefault(d => d.Id == selectedPositionId);
                emp.Department = context.Deprtments.FirstOrDefault(d => d.DepartmentId == selectedDepartmentId);
                if (selectedHeadId != null)
                    emp.Head = GetHeadName(selectedHeadId.Value);
                else emp.Head = "";

                emp.Salary = employee.Salary;
                emp.FullName = employee.FullName;
                context.Entry(emp).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RemoveEmployee(int id)
        {
            using (var context = new PowerCoEntity())
            {
                var employee = context.Employees.FirstOrDefault(e => id == e.EmployeeId);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}