using System.Web.Mvc;
using FsaStore.WebAPI.Controllers;
using FsaStore.AdminWebSite.Filters;

namespace FsaStore.AdminWebSite.Controllers
{
    public class CheckoutController : Controller
    {
        private ShoppingController ShoppingController;

        public CheckoutController(ShoppingController shoppingController)
        {
            ShoppingController = shoppingController;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}