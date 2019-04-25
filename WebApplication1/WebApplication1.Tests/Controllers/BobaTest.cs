using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System.Linq;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class BobaTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var db = new CS4PEEntities();
            var controller = new BobaController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<BubleTea> ;
            Assert.IsInstanceOfType(result.Model, typeof(List<BubleTea>));
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var controller = new BobaController();
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();

            var result = controller.Delete(item.id) as ViewResult;
            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

            var result0 = controller.Delete(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void DetailTest()
        {
            var controller = new BobaController();
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();

            var result = controller.Details(item.id) as ViewResult;
            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

            var result0 = controller.Details(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void CreateTestP()
        {
            var db = new CS4PEEntities();
            var model = new BubleTea
            {
                Name = "Tra sua VL",
                Price = 25000,
                Topping = "Tran chau trang"
            };

            var controller = new BobaController();

            var result = controller.Create(model);
            var redirect = result as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
            var item = db.BubleTeas.Find(model.id);
            Assert.IsNotNull(item);
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
        }
    }
}
