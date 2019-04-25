using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BobaController : Controller
    {
        private CS4PEEntities db = new CS4PEEntities();

        // GET: /Boba/
        public ActionResult Index()
        {
            return View(db.BubleTeas.ToList());
        }

        // GET: /Boba/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleTea bubletea = db.BubleTeas.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // GET: /Boba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Boba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BubleTea model)
        {
            if (ModelState.IsValid)
            {
                db.BubleTeas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Boba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleTea bubletea = db.BubleTeas.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // POST: /Boba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Price,Topping")] BubleTea bubletea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bubletea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bubletea);
        }

        // GET: /Boba/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleTea bubletea = db.BubleTeas.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // POST: /Boba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BubleTea bubletea = db.BubleTeas.Find(id);
            db.BubleTeas.Remove(bubletea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
