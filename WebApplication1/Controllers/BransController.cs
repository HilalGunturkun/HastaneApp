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
    public class BransController : Controller
    {
        private RandevuContext db = new RandevuContext();

        public ActionResult Index()
        {
            return View(db.Branslar.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brans brans = db.Branslar.Find(id);
            if (brans == null)
            {
                return HttpNotFound();
            }
            return View(brans);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BransID,BransAdi")] Brans brans)
        {
            if (ModelState.IsValid)
            {
                db.Branslar.Add(brans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brans);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brans brans = db.Branslar.Find(id);
            if (brans == null)
            {
                return HttpNotFound();
            }
            return View(brans);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BransID,BransAdi")] Brans brans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brans);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brans brans = db.Branslar.Find(id);
            if (brans == null)
            {
                return HttpNotFound();
            }
            return View(brans);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brans brans = db.Branslar.Find(id);
            db.Branslar.Remove(brans);
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
