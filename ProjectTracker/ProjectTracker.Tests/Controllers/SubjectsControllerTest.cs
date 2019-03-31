using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// new references
using System.Web.Mvc;
using ProjectTracker.Controllers;
using Moq;
using ProjectTracker.Models;
using System.Linq;
using System.Collections.Generic;

namespace ProjectTracker.Tests.Controllers
{
    [TestClass]
    public class SubjectsControllerTest
    {
        //moq data
        SubjectsController controller;
        List<Subject> subjects;
        Mock<IMockSubjects> mock;

        [TestInitialize]

        public void TestInitialize()
        {
            subjects = new List<Subject>
            {
            new Subject {SubjectId = 100, SubjectName = "Fake Subject one", Rubric = "Fake Rubric one"},
            new Subject { SubjectId = 101, SubjectName = "Fake Subject two", Rubric = "Fake Rubric two"},
            new Subject { SubjectId = 102, SubjectName = "Fake Subject three", Rubric = "Fake Rubric three"}

             };

            //set up & populate our mock object to inject into our controller
            mock = new Mock<IMockSubjects>();
            mock.Setup(c => c.Subjects).Returns(subjects.AsQueryable());

            //initialize the controller and inject the mock object
            controller = new SubjectsController(mock.Object);

         }


        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
            //now handled in TestInitialize
          
            
            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]

        public void IndexLoadsSubjects()
        {
            //act
            //call the index method
            //access the data model returned to the view
            //cast the data as a list of type Subject
            var results = (List<Subject>)((ViewResult)controller.Index()).Model;

            //assert
            CollectionAssert.AreEqual(subjects, results);
        }
    }
}
