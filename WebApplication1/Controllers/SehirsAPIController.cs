using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SehirsAPIController : ApiController
    {
        private RandevuContext db = new RandevuContext();

        public IQueryable<Sehir> GetSehirler()
        {
            return db.Sehirler;
        }

        [ResponseType(typeof(Sehir))]
        public IHttpActionResult GetSehir(int id)
        {
            Sehir sehir = db.Sehirler.Find(id);
            if (sehir == null)
            {
                return NotFound();
            }

            return Ok(sehir);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutSehir(int id, Sehir sehir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sehir.SehirID)
            {
                return BadRequest();
            }

            db.Entry(sehir).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SehirExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Sehir))]
        public IHttpActionResult PostSehir(Sehir sehir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sehirler.Add(sehir);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sehir.SehirID }, sehir);
        }

        [ResponseType(typeof(Sehir))]
        public IHttpActionResult DeleteSehir(int id)
        {
            Sehir sehir = db.Sehirler.Find(id);
            if (sehir == null)
            {
                return NotFound();
            }

            db.Sehirler.Remove(sehir);
            db.SaveChanges();

            return Ok(sehir);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SehirExists(int id)
        {
            return db.Sehirler.Count(e => e.SehirID == id) > 0;
        }
    }
}