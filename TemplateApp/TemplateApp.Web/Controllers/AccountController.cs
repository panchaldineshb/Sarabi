using System.Web.Mvc;
using System.Web.Security;

using TemplateApp.WebSite.Models;

namespace TemplateApp.WebSite.Controllers
{
    public class AccountController : Controller
    {
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/SignIn
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        //
        // POST: /Account/SignIn
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginModel model, string returnUrl)
        {
            if (this.ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Incorrect user name or password.");
            return View(model);
        }
    }
}