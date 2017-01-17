using PowerCoWebSite.Data;
using PowerCoWebSite.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace PowerCoWebSite.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View(new LoginViewModel { });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (var context = new PowerCoEntity())
                {
                    var user = context.Users.FirstOrDefault(u => u.Name == form.Name && u.Password == form.Password);
                    if (user == null)
                    {
                        ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(form.Name, true);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            //Redirect to default page
                            return RedirectToAction("Index", "MainPage");
                        }
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(form);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "MainPage");
        }
    }
}