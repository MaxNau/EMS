using PowerCo.Model;
using System.Collections.Generic;

namespace PowerCoWebSite.Data.Repositories
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
        void ModifyEmployee(int id, int selectedPositionId, int selectedDepartmentId, int? selectedHeadId, Employee employee);
        string GetHeadName(int headId);
    }
}