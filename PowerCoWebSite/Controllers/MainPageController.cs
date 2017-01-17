using PowerCoWebSite.Data;
using PowerCoWebSite.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;

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
        public ActionResult Register(User form, string returnUrl)
        {
            bool userExist;
            using (var context = new PowerCoEntity())
            {
                userExist = context.Users.Any(u => u.Name == form.Name);
            }

            if (!userExist)
            {
                User user = new User();
                user.Name = form.Name;
                user.Email = form.Email;
                user.Password = form.Password;
                user.Roles.Add(new Role { Id = 2, Name = "User"});

                using (var context = new PowerCoEntity())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                FormsAuthentication.SetAuthCookie(form.Name, true);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);
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