using PowerCoWebSite.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace PowerCoWebSite.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View(new LoginViewModel{});
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // find user in database
                var user = form.GetUser(form.Name, form.Password);

                // if user is not in database then notify user that he entered wrong password or user name
                if (user == null)
                {
                    ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
                }
                else
                {
                    // authenticate user and add him to the coockies collection. kepp user loged in
                    FormsAuthentication.SetAuthCookie(form.Name, true);

                    //Redirect user to main page
                    return RedirectToAction("Index", "MainPage");
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