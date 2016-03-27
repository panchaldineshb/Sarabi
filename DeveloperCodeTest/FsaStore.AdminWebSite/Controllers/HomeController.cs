using System.Web.Mvc;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;
using FsaStore.AdminWebSite.Filters;

namespace FsaStore.AdminWebSite.Controllers
{
    [DefaultRole(Roles = "A/B Testing")]
    public class HomeController : Controller
    {
        private IRepository<Account> AccountRepository;

        public HomeController(IRepository<Account> accountRepository)
        {
            AccountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            if (User != null && User.Identity != null)
            {
                var IndexViewModel = new IndexViewModel
                {
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    WelcomeMessage = string.Format("Welcome {0}", User.Identity.Name),
                    UserName = User.Identity.Name
                };
                return View(IndexViewModel);
            }
            return View();
        }
    }
}