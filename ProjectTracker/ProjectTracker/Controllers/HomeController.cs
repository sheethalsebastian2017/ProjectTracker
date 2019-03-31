using ProjectTracker.Models;
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
        
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            return View("Index");
        }

      

        
       public ActionResult Projects()
        {

            var projects = db.Projects.ToList();

            return View(projects);
        }

        public ActionResult ViewProject(String ProjectName)
        {
            ViewBag.ProjectName = ProjectName;

            return View();
        }

        public ActionResult UpdateYourActivity()
        {
           ViewBag.Message = "Your Activity description page";

            return View("UpdateYourActivity");
        }

        public ViewResult Settings()
        {
            ViewBag.Message = "Your application description page";

            return View();
        }
    }

 }
