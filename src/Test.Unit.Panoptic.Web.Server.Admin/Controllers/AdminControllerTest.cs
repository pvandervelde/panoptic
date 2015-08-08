using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panoptic.Web.Server.Admin;
using Panoptic.Web.Server.Admin.Controllers;

namespace Test.Unit.Panoptic.Web.Server.Admin.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }
    }
}
