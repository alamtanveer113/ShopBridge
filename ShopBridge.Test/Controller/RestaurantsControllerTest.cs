using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using System.Web.Mvc;
using Moq;
using System.Web;

namespace ShopBridge.Test.Controller
{
    [TestClass]
    public class RestaurantsControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("2");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            RestaurantsController restaurantsController = new RestaurantsController();
            restaurantsController.ControllerContext = mockControllerContext.Object;


            //Act
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)restaurantsController.Index();
            string result = redirectResult.RouteValues["action"].ToString();

            //Assert
            Assert.AreEqual(result, "Login");
        }

        [TestMethod]
        public void ListTest()
        {
            //Arrange
            RestaurantsController restaurantsController = new RestaurantsController();

            //Act
            var result = restaurantsController.List();


            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SingleTest()
        {
            //Arrange
            RestaurantsController restaurantsController = new RestaurantsController();

            //Act
            var result = restaurantsController.Single(1);

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void DetailsTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("1");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            RestaurantsController restaurantsController = new RestaurantsController();
            restaurantsController.ControllerContext = mockControllerContext.Object;

            //Act
            var result = restaurantsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("2");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            RestaurantsController restaurantsController = new RestaurantsController();
            restaurantsController.ControllerContext = mockControllerContext.Object;

            //Act
            RedirectToRouteResult redirectResult =(RedirectToRouteResult)restaurantsController.Create();
            string result = redirectResult.RouteValues["action"].ToString();

            //Assert
            Assert.AreEqual(result, "Login");
        }

        [TestMethod]
        public void EditTest()
        {
            //Arrange
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("1");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            RestaurantsController restaurantsController = new RestaurantsController();
            restaurantsController.ControllerContext = mockControllerContext.Object;

            //Act
            var result = restaurantsController.Edit(1);
            //RedirectToRouteResult redirectResult = (RedirectToRouteResult)restaurantsController.Create();
            //string result = redirectResult.RouteValues["action"].ToString();

            //Assert
            Assert.IsNotNull(result);



            //Act

            //Assert
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            RestaurantsController restaurantsController = new RestaurantsController();

            //Act
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)restaurantsController.Delete(1);
            string result = redirectResult.RouteValues["action"].ToString();

            //Assert
            Assert.AreEqual(result, "Login");


        }
    }

   
}
