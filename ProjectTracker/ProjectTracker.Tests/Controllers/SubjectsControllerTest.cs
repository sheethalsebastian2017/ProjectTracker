using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectTracker.Controllers;
using ProjectTracker.Models;
using System.Web.Mvc;

namespace ProjectTracker.Tests.Controllers
{
    [TestClass]
    public class SubjectsControllerTest
    {
        SubjectsController controller;
        List<Subject> subjects;
         Mock<IMockSubjects> mock;

        [TestInitialize]
        public void TestInitialize()

        {
            // create some mock data
            subjects = new List<Subject> {

                new Subject {SubjectId = 1, SubjectName = "subject1", Rubric = "rubric one", DueDates = DateTime.Parse(DateTime.Today.ToString()) },
                new Subject {SubjectId = 2, SubjectName = "subject2", Rubric = "rubric two", DueDates = DateTime.Parse(DateTime.Today.ToString())},
                new Subject {SubjectId = 3, SubjectName = "subject3", Rubric = "rubric three", DueDates = DateTime.Parse(DateTime.Today.ToString())}
            };


            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockSubjects>();
            mock.Setup(c => c.Subjects).Returns(subjects.AsQueryable());
           

            // initialize the controller and inject the mock object
            controller = new SubjectsController(mock.Object);
        }

        [TestMethod]

        public void IndexLoadsSubjects()
        {
            var value = (List<Subject>)((ViewResult)controller.Index()).Model;

            //assert

            CollectionAssert.AreEqual(subjects, value);
        }


        [TestMethod]

        public void CreateIndexViewLoads()
        {
            // Arrange

            controller = new SubjectsController();

            // Act

            ViewResult value = controller.Create() as ViewResult;

            // Assert

            Assert.AreEqual("Create", value.ViewName);
        }


        [TestMethod]

        public void TestMethod()
        {
            Subject value = new Subject();

            Assert.AreEqual(value.SubjectName, null);
        }


        [TestMethod]

        public void DetailsIndexViewLoads()

        {
            //Act

            ViewResult value = controller.Details(1) as ViewResult;

            //Assert

            Assert.AreEqual("Details", value.ViewName);

        }

        [TestMethod]

        public void DetailsIndexViewId()

        {

            //Act

            HttpStatusCodeResult value = controller.Details(null) as HttpStatusCodeResult;

            //Assert

            Assert.AreEqual(400, value.StatusCode);

        }

        [TestMethod]

        public void DetailsIndexNullSubject()

        {
            //Act

            HttpNotFoundResult value = controller.Details(004) as HttpNotFoundResult;

            //Assert

            Assert.AreEqual(404, value.StatusCode);

        }

        [TestMethod]

        public void DetailsIndexSubject()

        {
            //Act

            var value = ((ViewResult)controller.Details(2)).Model;

            //Assert

            Assert.AreEqual(subjects.SingleOrDefault(p => p.SubjectId == 2), value);

        }

        [TestMethod]

        public void EditPostViewName()
        {
            // act

            RedirectToRouteResult value = controller.Edit(subjects[0]) as RedirectToRouteResult;

            // assert

            Assert.AreEqual("Index", value.RouteValues["action"]);
        }

        [TestMethod]

        public void EditPostViewLoads()
        {
            // act

            RedirectToRouteResult value = controller.Edit(subjects[0]) as RedirectToRouteResult;

            // assert

            Assert.IsNotNull(value);
        }

        [TestMethod]

        public void EditPostModelViewLoads()
        {
            controller.ModelState.AddModelError("Explanation", "error details");

            // act

            ViewResult value = controller.Edit(subjects[0]) as ViewResult;

            // assert

            Assert.IsNotNull(value);
        }

        [TestMethod]

        public void EditPostModelViewName()
        {
            // act

            RedirectToRouteResult value = controller.Edit(subjects[0]) as RedirectToRouteResult;

            // assert

            Assert.AreEqual("Index", value.RouteValues["action"]);
        }

        [TestMethod]

        public void PostEditViewBag()
        {
            controller.ModelState.AddModelError("Explanation", "error details");

            // act

            SelectList value = (controller.Edit(1) as ViewResult).ViewBag.SubjectId;

            // assert

            Assert.AreEqual(1, value.SelectedValue);
        }


        [TestMethod]

        public void ViewLoads()

        {
            //act

            ViewResult value = controller.Index() as ViewResult;
        
            //Assert

            Assert.AreEqual("Index", value.ViewName);

        }

        [TestMethod]

        public void RedirectCreateIndexLoads()
        {
            Subject subject1 = new Subject { SubjectId = 1, SubjectName = "Subject 1", Rubric = "rubric one", DueDates = DateTime.Parse(DateTime.Today.ToString()) };

            //act

            RedirectToRouteResult value = controller.Create(subject1) as RedirectToRouteResult;
            
            //assert

            Assert.AreEqual("Create", value.RouteValues["action"]);
        }


        [TestMethod]

        public void RedirectEditIndexLoads()
        {
            Subject subject1 = new Subject { SubjectId = 1, SubjectName = "Subject 1", Rubric = "rubric one", DueDates = DateTime.Parse(DateTime.Today.ToString()) };

            //act

            RedirectToRouteResult value = controller.Edit(subject1) as RedirectToRouteResult;

            //assert

            Assert.AreEqual("Index", value.RouteValues["action"]);
        }


        [TestMethod]

        public void ConfirmValidId()

        {
            // act

            RedirectToRouteResult value = controller.DeleteConfirmed(700) as RedirectToRouteResult;

            var valuelist = value.RouteValues.ToArray();

            // assert

            Assert.AreEqual("Index", valuelist[0].Value);

        }

        [TestMethod]

        public void ConfimInvalidId()

        {
            // arrange

            RedirectToRouteResult value = controller.DeleteConfirmed(300) as RedirectToRouteResult;

            // act

            var valuelist = value.RouteValues.ToArray();
            
            // assert

            Assert.AreEqual("Index", valuelist[0].Value);

        }


    }

}



