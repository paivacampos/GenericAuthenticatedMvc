using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericAuthenticatedMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Administrator")]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult UserPage()
        {
            return View("User");
        }

        [Authorize(Roles="SuperUser")]
        public ActionResult SuperUser()
        {
            return View();
        }

    }
}
