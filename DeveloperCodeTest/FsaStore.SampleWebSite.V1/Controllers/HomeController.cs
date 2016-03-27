using System.Web.Mvc;

using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.SampleWebSite.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Account> AccountRepository;

        public HomeController(IRepository<Account> accountRepository)
        {
            AccountRepository = accountRepository;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
    }
}