using PowerCo.Model;
using PowerCoWebSite.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PowerCoWebSite.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Department GetDepartment(int id)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Deprtments.FirstOrDefault(d => d.DepartmentId == id);
            }
        }

        public int GetDepartmentIdByName(string departmentName)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Deprtments.FirstOrDefault(d => d.DepartmentName == departmentName).DepartmentId;
            }
        }

        public List<Department> GetDepartments()
        {
            using (var context = new PowerCoEntity())
            {
                return context.Deprtments.ToList();
            }
        }

        public int GetEmployeePositionIdByName(string positionName)
        {
            using (var context = new PowerCoEntity())
            { 
                return context.EmployeePositions.FirstOrDefault(d => d.Name == positionName).Id;
            }
        }

        public List<EmployeePosition> GetEmployeePositions()
        {
            using (var context = new PowerCoEntity())
            {
                return context.EmployeePositions.ToList();
            }
        }

        public EmployeePosition GetPosition(int id)
        {
            using (var context = new PowerCoEntity())
            {
                return context.EmployeePositions.FirstOrDefault(d => d.Id == id);
            }
        }
    }
}