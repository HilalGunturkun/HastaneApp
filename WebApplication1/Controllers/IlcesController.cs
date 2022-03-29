using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class IlcesController : Controller
    {
        private RandevuContext db = new RandevuContext();

        public ActionResult Index()
        {
            var ilceler = db.Ilceler.Include(i => i.Sehir);
            return View(ilceler.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        public ActionResult Create()
        {
            ViewBag.SehirID = new SelectList(db.Sehirler, "SehirID", "SehirAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlceID,IlceAdi,SehirID")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Ilceler.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SehirID = new SelectList(db.Sehirler, "SehirID", "SehirAdi", ilce.SehirID);
            return View(ilce);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.SehirID = new SelectList(db.Sehirler, "SehirID", "SehirAdi", ilce.SehirID);
            return View(ilce);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlceID,IlceAdi,SehirID")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SehirID = new SelectList(db.Sehirler, "SehirID", "SehirAdi", ilce.SehirID);
            return View(ilce);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilce ilce = db.Ilceler.Find(id);
            db.Ilceler.Remove(ilce);
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
