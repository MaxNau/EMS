using PowerCo.Model;
using PowerCoWebSite.Data;
using PowerCoWebSite.ViewModels;
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
                employee.Position= context.EmployeePositions.FirstOrDefault(d => d.Id== form.SelectedPositionId);
                employee.Department = context.Deprtments.FirstOrDefault(d => d.DepartmentId == form.SelectedDepartmentId);
            }

            using (var context = new PowerCoEntity())
            {
                context.EmployeePositions.Attach(employee.Position);
                context.Deprtments.Attach(employee.Department);
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            return RedirectToAction("EmployeesManagementIndex");
        }

        public ActionResult EditEmployee(int id)
        {
            if (User.IsInRole("Admin"))
            {
                EditEmployeeViewModel evm = new EditEmployeeViewModel();
                evm.GetEmployee(id);
                evm.SetDropDownListCurrentItems();

                return View(evm);
            }

            return RedirectToAction("Index", "MainPage");
        }

        [HttpPost]
        public ActionResult EditEmployee(int id, EditEmployeeViewModel form)
        {
            if (!ModelState.IsValid)
                return View(form);

            form.ModifyEmployee(id);

            return RedirectToAction("EmployeesManagementIndex");
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            EditEmployeeViewModel evm = new EditEmployeeViewModel();
            evm.RemoveEmployee(id);
            return RedirectToAction("EmployeesManagementIndex");
        }
    }
}