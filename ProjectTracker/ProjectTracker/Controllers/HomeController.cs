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
        private const string Sql = "UpdateYourActivity SET Credits = Credits * {0}";
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateYourActivity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateYourActivity(int? multiplier)
        {
            if (multiplier != null)
            {
                ViewBag.RowsAffected = db.Database.ExecuteSqlCommand(Sql, multiplier);
            }
            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Message = "Your Settings page.";

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

    }

 }
