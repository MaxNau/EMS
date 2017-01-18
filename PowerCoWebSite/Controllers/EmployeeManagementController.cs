using PowerCoWebSite.ViewModels;
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

            form.AddEmployee();

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