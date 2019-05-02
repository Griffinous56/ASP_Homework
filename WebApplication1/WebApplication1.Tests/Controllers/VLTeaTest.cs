using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Tests.Controllers;
using WebApplication1.Tests;
using System.Web.Mvc;
using WebApplication1.Controllers;
using System.Collections.Generic;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class VLTeaTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new VLTeaController();
            var result = controller.Index();

            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as List<BubleTea>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);
        }
    }
}
