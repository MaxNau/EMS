using PowerCo.Model;
using PowerCoWebSite.Data;
using PowerCoWebSite.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PowerCoWebSite.Controllers
{
    public class EmployeeManagementController : Controller
    {
        // GET: EmployeeManagment
        public ActionResult EmployeesManagementIndex()
        {
            if (User.IsInRole("Admin"))
            {
                EmployeesViewModel evm = new EmployeesViewModel();
                using (var context = new PowerCoEntity())
                {
                    evm.Employees = context.Employees.ToList();
                }

                return View(evm);
            }

            return RedirectToAction("Index", "MainPage");
        }

        public ActionResult NewEmployee()
        {
            if (User.IsInRole("Admin"))
            {
                return View(new NewEmployeeViewModel());
            }

            return RedirectToAction("Index", "MainPage");
        }

        [HttpPost]
        public ActionResult NewEmployee(NewEmployeeViewModel form)
        {
            if (!ModelState.IsValid)
                return View(form);

            var employee = new Employee
            {
                FullName = form.FullName,
                Head = form.Head,
                Salary = form.Salary,
            };

            using (var context = new PowerCoEntity())
            {
                employee.Position= context.EmployeePositions.FirstOrDefault(d => d.Id== form.SelectedPositionId).Name;
                employee.DepartmentName = context.Deprtments.FirstOrDefault(d => d.DepartmentId == form.SelectedDepartmentId).DepartmentName;
            }

            using (var context = new PowerCoEntity())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            return RedirectToAction("EmployeesManagementIndex");
        }

        public ActionResult EditEmployee(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Employee employee;

                using (var context = new PowerCoEntity())
                {
                    employee = context.Employees.FirstOrDefault(e => id == e.EmployeeId);
                }

                return View(new EditEmployeeViewModel(employee.DepartmentName, employee.Position)
                {
                    FullName = employee.FullName,
                    Salary = employee.Salary
                });
            }

            return RedirectToAction("Index", "MainPage");
        }

        [HttpPost]
        public ActionResult EditEmployee(int id, EditEmployeeViewModel form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Employee employee;

            using (var context = new PowerCoEntity())
            {
                employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            }

            using (var context = new PowerCoEntity())
            {
                employee.Position = context.EmployeePositions.FirstOrDefault(d => d.Id == form.SelectedPositionId).Name;
                employee.DepartmentName = context.Deprtments.FirstOrDefault(d => d.DepartmentId == form.SelectedDepartmentId).DepartmentName;
                employee.Head = context.Employees.FirstOrDefault(e => e.EmployeeId == form.SelectedHeadId).FullName;
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("EmployeesManagementIndex");
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            Employee employee;

            using (var context = new PowerCoEntity())
            {
                employee = context.Employees.FirstOrDefault(e => id == e.EmployeeId);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }

            return RedirectToAction("EmployeesManagementIndex");
        }
    }
}