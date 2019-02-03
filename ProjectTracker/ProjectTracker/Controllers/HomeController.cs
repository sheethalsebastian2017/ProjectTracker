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
            var projects = new List<Project>();

            for (int i = 1; i <=10; i++)

            {
                Project project = new Project();
                project.Name = "Project" + i.ToString();
                projects.Add(project);
            }

            return View(projects);
        }

        public ActionResult ViewProject(String ProjectName)
        {
            ViewBag.ProjectName = ProjectName;
            return View();
        }

    }

 }
