using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SubjectsController : Controller
    {
        //private DbModel db = new DbModel();

        IMockSubjects db;
        // Constructors
        public SubjectsController()
        {
            this.db = new IDataSubjects();
        }

        public SubjectsController(IMockSubjects mockDb)
        {
            this.db = mockDb;
        }
        // default constructor: no input params => use SQL Server & Entity Framework


        // GET: Subjects
        public ActionResult Index()
        {
            return View("Index", db.Subjects.ToList());
    
        }

      
        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Subject subject = db.Subjects.Find(id);
            Subject subject = db.Subjects.SingleOrDefault(c => c.SubjectId == id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View("Details", subject);
        }

       
        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "SubjectId,SubjectName,DueDates,Rubric")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                // db.Subjects.Add(subject);
                // db.SaveChanges();
                db.Save(subject);
                return RedirectToAction("Create");
            }

            return View(subject);
        }

        
        // GET: Subjects/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Subject subject = db.Subjects.Find(id);
            Subject subject = db.Subjects.SingleOrDefault(c => c.SubjectId == id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", subject.SubjectId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,SubjectName,DueDates,Rubric")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(subject).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(subject);
                return RedirectToAction("Index");
            }
            return View("Edit",subject);
        }

        // GET: Subjects/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Subject subject = db.Subjects.Find(id);
            Subject subject = db.Subjects.SingleOrDefault(c => c.SubjectId == id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Subject subject = db.Subjects.Find(id);
            Subject subject = db.Subjects.SingleOrDefault(c => c.SubjectId == id);
            //db.Subjects.Remove(subject);
            //db.SaveChanges();
            db.Delete(subject);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
