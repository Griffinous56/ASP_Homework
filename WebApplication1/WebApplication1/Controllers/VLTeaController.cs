using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VLTeaController : Controller
    {
        //
        // GET: /VLTea/
        CS4PEEntities db = new CS4PEEntities();
        public ActionResult Index()
        {
            var model = db.BubleTeas;
            return View(model.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BubleTea model)
        {
            ValidateBubbleTea(model);
            if (ModelState.IsValid)
            {
                db.BubleTeas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        private void ValidateBubbleTea(BubleTea model)
        {
            if (model.Price <= 0)
            {
                ModelState.AddModelError("Price", Resource1.PRICE_LESS_0);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = db.BubleTeas.Find(id);
            if (model == null)
                return HttpNotFound();
            db.BubleTeas.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = db.BubleTeas.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(BubleTea model)
        {
            ValidateBubbleTea(model);
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}