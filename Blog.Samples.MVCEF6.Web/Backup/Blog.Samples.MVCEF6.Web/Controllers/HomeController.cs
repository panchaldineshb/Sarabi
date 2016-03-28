using System.Web.Mvc;
using Blog.Samples.MVCEF6.Domain.Services;
using Blog.Samples.MVCEF6.Web.Models;

namespace Blog.Samples.MVCEF6.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsServices _productsServices;

        public HomeController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        public ActionResult Index()
        {
            return View(new HomeViewModel()
                {
                    Vendors = _productsServices.ListVendors()
                });
        }

    }
}
