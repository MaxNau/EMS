using PowerCo.Model;
using PowerCoWebSite.Models;
using System.Collections.Generic;

namespace PowerCoWebSite.Data.Repositories
{
    public interface IDepartmentRepository
    {
        EmployeePosition GetPosition(int id);
        Department GetDepartment(int id);
        List<Department> GetDepartments();
        List<EmployeePosition> GetEmployeePositions();
        int GetDepartmentIdByName(string departmentName);
        int GetEmployeePositionIdByName(string positionName);
    }
}