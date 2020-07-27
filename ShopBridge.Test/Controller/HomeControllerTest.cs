using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using System.Web.Mvc;

namespace ShopBridge.Test.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            var result = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


    }
}
