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
    public class DoktorsController : Controller
    {
        private RandevuContext db = new RandevuContext();

        public ActionResult Index()
        {
            var doktorlar = db.Doktorlar.Include(d => d.Brans);
            return View(doktorlar.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doktor doktor = db.Doktorlar.Find(id);
            if (doktor == null)
            {
                return HttpNotFound();
            }
            return View(doktor);
        }

        public ActionResult Create()
        {
            ViewBag.BransID = new SelectList(db.Branslar, "BransID", "BransAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoktorID,DoktorAdi,DoktorSoyadi,Cinsiyet,BransID")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                db.Doktorlar.Add(doktor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BransID = new SelectList(db.Branslar, "BransID", "BransAdi", doktor.BransID);
            return View(doktor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doktor doktor = db.Doktorlar.Find(id);
            if (doktor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BransID = new SelectList(db.Branslar, "BransID", "BransAdi", doktor.BransID);
            return View(doktor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoktorID,DoktorAdi,DoktorSoyadi,Cinsiyet,BransID")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doktor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BransID = new SelectList(db.Branslar, "BransID", "BransAdi", doktor.BransID);
            return View(doktor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doktor doktor = db.Doktorlar.Find(id);
            if (doktor == null)
            {
                return HttpNotFound();
            }
            return View(doktor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doktor doktor = db.Doktorlar.Find(id);
            db.Doktorlar.Remove(doktor);
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
