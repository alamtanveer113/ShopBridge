using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using System.Web.Mvc;
using System.Net;
using System.Web;
using Moq;
using System.IO;
using ShopBridge.Test.Model;

namespace ShopBridge.Test.Controller
{
    [TestClass]
    public class PostControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("1");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            PostsController postsController = new PostsController();
            postsController.ControllerContext = mockControllerContext.Object;

            //Act
            var result = postsController.Index() as ViewResult;

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
            PostsController postsController = new PostsController();
            postsController.ControllerContext = mockControllerContext.Object;

            //Act
            var result = postsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void SingleTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("2");
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            PostsController postsController = new PostsController();
            postsController.ControllerContext = mockControllerContext.Object;

            //Act
            var result = postsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostsTest()
        {
            //Arrange
            PostsController postController = new PostsController();

            //Act
            var result = postController.Posts();

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
            PostsController postsController = new PostsController();
            postsController.ControllerContext = mockControllerContext.Object;

            string expected = null;
            Post post = new Post();
            post.PostId = 001;
            post.Title = "TestTitle";
            post.Text = "TestTest";
            string image = "C:\\Users\\taalam\\Documents\\Project\\Food\\Food\\ShopBridge.Test\\Contents\\images\\posts\\1.jpg";
            post.Date =  DateTime.Now;
            post.UserId = 1;
            post.Price = 100;


            //Act
            var result = postsController.Create() as ViewResult;

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void EditTest()
        {
            //Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["RoleId"]).Returns("2"); 
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            PostsController postsController = new PostsController();
            postsController.ControllerContext = mockControllerContext.Object;

            //Act
           var post =  postsController.Edit(1);

            //Assert
            Assert.IsNotNull(post);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            PostsController postsController = new PostsController();

            //Act
            var result = postsController.Delete(1006);

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
