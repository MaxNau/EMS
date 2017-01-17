using System.Web.Mvc;
using System.Web.Security;
using PowerCoWebSite.ViewModels;

namespace PowerCoWebSite.Controllers
{
    public class MainPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel form, string returnUrl)
        {
            if (form.RegisterUser())
            {
                FormsAuthentication.SetAuthCookie(form.Name, true);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("RegistrationError", "This user name already exist");
                return View(form);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}