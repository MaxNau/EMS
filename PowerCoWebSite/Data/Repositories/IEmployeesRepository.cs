﻿using PowerCo.Model;
using System.Collections.Generic;

namespace PowerCoWebSite.Data.Repositories
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployee();
        void RemoveEmployee(int id);
        void ModifyEmployee(Employee employee);
    }
}