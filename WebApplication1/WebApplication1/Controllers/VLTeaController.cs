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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}