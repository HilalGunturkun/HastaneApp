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
    public class HastanesController : Controller
    {
        private RandevuContext db = new RandevuContext();

        public ActionResult Index()
        {
            var hastaneler = db.Hastaneler.Include(h => h.Ilce);
            return View(hastaneler.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastane hastane = db.Hastaneler.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            return View(hastane);
        }

        public ActionResult Create()
        {
            ViewBag.IlceID = new SelectList(db.Ilceler, "IlceID", "IlceAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HastaneID,HastaneAdi,Telefon,IlceID")] Hastane hastane)
        {
            if (ModelState.IsValid)
            {
                db.Hastaneler.Add(hastane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlceID = new SelectList(db.Ilceler, "IlceID", "IlceAdi", hastane.IlceID);
            return View(hastane);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastane hastane = db.Hastaneler.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlceID = new SelectList(db.Ilceler, "IlceID", "IlceAdi", hastane.IlceID);
            return View(hastane);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HastaneID,HastaneAdi,Telefon,IlceID")] Hastane hastane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlceID = new SelectList(db.Ilceler, "IlceID", "IlceAdi", hastane.IlceID);
            return View(hastane);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastane hastane = db.Hastaneler.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            return View(hastane);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hastane hastane = db.Hastaneler.Find(id);
            db.Hastaneler.Remove(hastane);
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
