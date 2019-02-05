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
            return View();
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

        public ViewResult UpdateYourActivity()
        {
            throw new NotImplementedException();
        }

        public ViewResult Settings()
        {
            throw new NotImplementedException();
        }
    }

 }
