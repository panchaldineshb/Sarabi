using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateApp.WebSite.Controllers
{
    //-----------------------------------------------------------------------------------------------------
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //-----------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /About/

        //-----------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        //
        // GET: /Contact/

        //-----------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

    }
}


