using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class AnasayfaController : Controller
    {
        RandevuContext db = new RandevuContext();

        // GET: Anasayfa
        public ActionResult Index(int? defaultSehirId = 1)
        {
            AnasayfaModel model = new AnasayfaModel();
            //Bütün şehirleri gitirir
            var allsehirList = db.Sehirler.ToList();    
            
            var allIlceList = db.Ilceler.Where(m => m.SehirID == defaultSehirId).ToList();
            
            var defaultIlceId = allIlceList.Select(m => m.IlceID).FirstOrDefault();
            
            var allhastaneList = db.Hastaneler.Where(m => m.IlceID == defaultIlceId).ToList();
            
            var defaultHastaneId = allhastaneList.Select(m => m.HastaneID).FirstOrDefault();

            model.Sehirler = new SelectList(allsehirList, "SehirID", "SehirAdi", defaultSehirId);
            model.Ilceler = new SelectList(allIlceList, "IlceID", "IlceAdi", defaultIlceId);
            model.Hastaneler = new SelectList(allhastaneList, "HastaneID", "HastaneAdi", defaultHastaneId);

            return View(model);
        }

        //[HttpPost]
        //public JsonResult setDropDrownList(string type, int value)
        //{
        //    AnasayfaModel model = new AnasayfaModel();

        //    switch (type)
        //    {
        //        case "SehirID":
        //            var ilceList = db.Ilceler.Where(m => m.SehirID == value).ToList();
        //            model.Ilceler = new SelectList(ilceList, "IlceID", "IlceAdi");

        //            var defaultIlceId = ilceList.Select(m =>m.IlceID).FirstOrDefault();
        //            model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID == defaultIlceId).ToList(), "HastaneID", "HastaneAdi");
        //            break;

        //        case "IlceID":
        //            model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID == value).ToList(), "HastaneID", "HastaneAdi");
        //            break;
        //    }

        //    return Json(model);
        //}

        [HttpPost]
        public ActionResult Index(AnasayfaModel model)
        {
            model.Sehirler = new SelectList(db.Sehirler.ToList(),"SehirID", "SehirAdi", model.SehirID);
            model.Ilceler = new SelectList(db.Ilceler.Where(m => m.SehirID.ToString() == model.SehirID).ToList(),"IlceID", "IlceAdi", model.IlceID);
            model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID.ToString() == model.IlceID).ToList(),"HastaneID", "HastaneAdi", model.HastaneID);
            return View(model);
        }
        
    }
}