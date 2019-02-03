using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YourActivity()
        {
            ViewBag.Message = "Your Activity description page.";

            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Message = "Your Settings page.";

            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Message = "Your Projects page.";

            return View();
        }

    }
}