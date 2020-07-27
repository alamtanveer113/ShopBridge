using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using System.Web.Mvc;

namespace ShopBridge.Test.Controller
{
    [TestClass]
    public class ReviewsControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            ReviewsController reviewsController = new ReviewsController();
            //Act
            var result = reviewsController.Index(2);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTest()
        {
            //Arrange
            ReviewsController reviewsController = new ReviewsController();
            //Act
            var result = reviewsController.Details(2);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTest()
        {
            //Arrange
            ReviewsController reviewsController = new ReviewsController();

            //Act
            var result = reviewsController.Edit(2);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            ReviewsController reviewsController = new ReviewsController();

            //Act
            HttpStatusCodeResult result = reviewsController.Delete(1) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 404);
        }
    }
}
