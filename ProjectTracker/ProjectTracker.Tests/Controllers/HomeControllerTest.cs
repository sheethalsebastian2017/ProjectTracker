﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTracker;
using ProjectTracker.Controllers;

namespace ProjectTracker.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]

        public void UpdateYourActivity()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.UpdateYourActivity() as ViewResult;

            // Assert
            Assert.AreEqual("Your Activity description page", result.ViewBag.Message);
        }

        [TestMethod]

        public void UpdateYourActivityLoadsView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.UpdateYourActivity() as ViewResult;

            // Assert
            Assert.AreEqual("Your Activity description page", result.ViewBag.Message);
        }

        [TestMethod]
        public void Settings()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Settings() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
