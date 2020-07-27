using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ShopBridge.Controllers;
using ShopBridge.Test.Controller;

namespace ShopBridge.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = 10;
            string expected = "Index";
            HomeController controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);

            
        }
    }
}
