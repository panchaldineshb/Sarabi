using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Extensions;
using FsaStore.Core.Models;
using FsaStore.Core.ViewModels;

namespace FsaStore.AdminWebSite.Controllers
{
    public class AccountController : Controller
    {
        private IRepository<Account> AccountRepository;

        private IRepository<Company> CompanyRepository;

        public AccountController(IRepository<Account> accountRepository, IRepository<Company> companyRepository)
        {
            AccountRepository = accountRepository;
            CompanyRepository = companyRepository;
        }

        /// <summary>
        /// Access Denied View
        /// </summary>
        /// <returns></returns>
        public ActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Register User/Account View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Dashboard()
        {
            var RegistrationViewModel = new RegistrationViewModel
            {
                Companies = CompanyRepository.All().ToList()
            };
            return View(RegistrationViewModel);
        }

        /// <summary>
        /// The log of action handler.
        /// </summary>
        /// <returns>Redirect to the home view.</returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The log on action
        /// </summary>
        /// <returns>The log on view.</returns>
        public ActionResult LogOn()
        {
            return View();
        }

        /// <summary>
        /// Handles the log on request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>The home view in case of success. The log on view otherwise.</returns>
        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (AccountRepository.VerifyUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect name or password.");
                }
            }

            return View(model);
        }

        public ActionResult RedirectToDefault()
        {
            string[] roles = Roles.GetRolesForUser();
            if (roles.Contains("Administrator"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (roles.Contains("Dealer"))
            {
                return RedirectToAction("Index", "Dealer");
            }
            else if (roles.Contains("PublicUser"))
            {
                return RedirectToAction("Index", "PublicUser");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// Register User/Account View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            var DashboardViewModel = new DashboardViewModel
            {
                Companies = CompanyRepository.All().ToList()
            };
            return View(DashboardViewModel);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            return View();
        }
    }
}