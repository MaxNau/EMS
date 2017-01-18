using System;
using System.Collections.Generic;
using PowerCo.Model;
using System.Linq;
using System.Data.Entity;

namespace PowerCoWebSite.Data.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void AddEmployee()
        {
            throw new NotImplementedException();
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

        public void ModifyEmployee(Employee employee)
        {
            using (var context = new PowerCoEntity())
            {
                context.Entry(employee).State = EntityState.Modified;
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