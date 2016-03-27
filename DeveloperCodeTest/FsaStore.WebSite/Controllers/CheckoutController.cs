using System.Web.Mvc;
using FsaStore.WebAPI.Controllers;
using FsaStore.WebSite.Filters;

namespace FsaStore.WebSite.Controllers
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