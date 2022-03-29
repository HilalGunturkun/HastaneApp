using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KullaniciController : Controller
    {
        RandevuContext db = new RandevuContext();
        public ActionResult Index(int? defaultSehirId = 0, int? defaultTarihId = 0)
        {
            AnasayfaModel model = new AnasayfaModel();


            var allsehirList = db.Sehirler.ToList();

            var allIlceList = db.Ilceler.Where(m => m.SehirID == defaultSehirId).ToList();

            var defaultIlceId = allIlceList.Select(m => m.IlceID).FirstOrDefault();

            var allhastaneList = db.Hastaneler.Where(m => m.IlceID == defaultIlceId).ToList();

            var defaultHastaneId = allhastaneList.Select(m => m.HastaneID).FirstOrDefault();

            var allBransList = db.Branslar.Where(m => m.HastaneID == defaultHastaneId).ToList();

            var defaultBransId = allBransList.Select(m => m.BransID).FirstOrDefault();

            var allDoktorList = db.Doktorlar.Where(m => m.BransID == defaultBransId).ToList();

            var defaultDoktorId = allDoktorList.Select(m => m.DoktorID).FirstOrDefault();

            //
            var allTarihList = db.Tarihler.ToList();

            var allSaatList = db.Saatler.Where(m => m.TarihID == defaultTarihId).ToList();

            var defaultSaatId = allSaatList.Select(m => m.SaatID).FirstOrDefault();


            //
            model.Sehirler = new SelectList(allsehirList, "SehirID", "SehirAdi", defaultSehirId);
            model.Ilceler = new SelectList(allIlceList, "IlceID", "IlceAdi", defaultIlceId);
            model.Hastaneler = new SelectList(allhastaneList, "HastaneID", "HastaneAdi", defaultHastaneId);
            model.Branslar = new SelectList(allBransList, "BransID", "BransAdi", defaultBransId);
            model.Doktorlar = new SelectList(allDoktorList, "DoktorID", "DoktorAdi", defaultDoktorId);
            //
            model.Tarihler = new SelectList(allTarihList, "TarihID", "TarihAdi", defaultTarihId);
            model.Saatler = new SelectList(allSaatList, "SaatID", "SaatAdi", defaultSaatId);

            //Session Okuma
            var id = Session["UyeID"];

            int ID = Convert.ToInt32(id);

            var result = db.Hastalar.Where(h => h.KullaniciID == ID).SingleOrDefault();
            var randevu = db.Randevular.Where(r => r.HastaID == result.HastaID);

            model.Hastalar = result;
            model.Randevular = randevu.ToList();

            return View(model);

        }

        [HttpPost]
        public JsonResult setDropDownList(string type, int value) 
        {
            AnasayfaModel model = new AnasayfaModel();

            switch (type)
            {
                case "SehirID":
                    //
                    var ilceList = db.Ilceler.Where(m => m.SehirID == value).ToList();
                    model.Ilceler = new SelectList(ilceList, "IlceID", "IlceAdi");

                    var defaultIlceId = ilceList.Select(m => m.IlceID).FirstOrDefault();
                    model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID == defaultIlceId).ToList(), "HastaneID", "HastaneAdi");

                    //
                    var hastaneList = db.Hastaneler.Where(m => m.IlceID == value).ToList();
                    model.Hastaneler = new SelectList(hastaneList, "HastaneID", "HastaneAdi");

                    var defaultHastaneId = hastaneList.Select(m => m.HastaneID).FirstOrDefault();
                    model.Branslar = new SelectList(db.Branslar.Where(m => m.HastaneID == defaultHastaneId).ToList(), "BransID", "BransAdi");

                    //
                    var bransList = db.Branslar.Where(m => m.HastaneID == value).ToList();
                    model.Branslar = new SelectList(bransList, "BransID", "BransAdi");

                    var defaultBransId = bransList.Select(m => m.BransID).FirstOrDefault();
                    model.Doktorlar = new SelectList(db.Doktorlar.Where(m => m.BransID == defaultBransId).ToList(), "DoktorID", "DoktorAdi");

                    break;

                case "IlceID":

                    model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID == value).ToList(), "HastaneID", "HastaneAdi");

                    break;


                case "HastaneID":

                    model.Branslar = new SelectList(db.Branslar.Where(m => m.HastaneID == value).ToList(), "BransID", "BransAdi");

                    break;

                case "BransID":

                    model.Doktorlar = new SelectList(db.Doktorlar.Where(m => m.BransID == value).ToList(), "DoktorID", "DoktorAdi");

                    break;

                ////
                case "TarihID":

                    model.Saatler = new SelectList(db.Saatler.Where(m => m.TarihID == value).ToList(), "SaatID", "SaatAdi");

                    break;
            }

            return Json(model);
        }

        [HttpPost]
        public ActionResult Index(AnasayfaModel model)
        {
            model.Sehirler = new SelectList(db.Sehirler.ToList(), "SehirID", "SehirAdi", model.SehirID);
            model.Ilceler = new SelectList(db.Ilceler.Where(m => m.SehirID.ToString() == model.SehirID).ToList(), "IlceID", "IlceAdi", model.IlceID);
            model.Hastaneler = new SelectList(db.Hastaneler.Where(m => m.IlceID.ToString() == model.IlceID).ToList(), "HastaneID", "HastaneAdi", model.HastaneID);
            model.Branslar = new SelectList(db.Branslar.Where(m => m.HastaneID.ToString() == model.HastaneID).ToList(), "BransID", "BransAdi", model.BransID);
            model.Doktorlar = new SelectList(db.Doktorlar.Where(m => m.BransID.ToString() == model.BransID).ToList(), "DoktorID", "DoktorAdi", model.DoktorID);

            model.Tarihler = new SelectList(db.Tarihler.ToList(), "TarihID", "TarihAdi", model.TarihID);
            model.Saatler = new SelectList(db.Saatler.Where(m => m.TarihID.ToString() == model.TarihID).ToList(), "SaatID", "SaatAdi", model.SaatID);

            return View(model);
        }

        public ActionResult Randevular()
        {
            AnasayfaModel model = new AnasayfaModel();
            AnasayfaModel gecmisModel = new AnasayfaModel();

            //Session Okuma
            var id = Session["UyeID"];

            int ID = Convert.ToInt32(id);

            var result = db.Hastalar.Where(h => h.KullaniciID == ID).SingleOrDefault();
            var randevu = db.Randevular.Where(r => r.HastaID == result.HastaID);

            model.Hastalar = result;
            model.Randevular = randevu.ToList();

            return View(model);
        }

        public ActionResult Hastalar()
        {
            AnasayfaModel model = new AnasayfaModel();
            var id = Session["UyeID"];

            int ID = Convert.ToInt32(id);

            var hasta = db.Hastalar.Where(h => h.KullaniciID == ID).SingleOrDefault();
            model.Hastalar = hasta;

            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var rnd = db.Randevular.Where(h => h.RandevuID == id).FirstOrDefault();
            db.Randevular.Remove(rnd);
            db.SaveChanges();
            return RedirectToAction("Randevular", "Kullanici");
        }

        public ActionResult Guncelle(int id)  
        {
            var hasta = db.Hastalar.Where(h => h.HastaID == id).FirstOrDefault();
            return View(hasta);
        }

        [HttpPost]
        public ActionResult Guncelle(Hasta hasta)
        {
            var id = db.Hastalar.Find(hasta.HastaID);
            id.CepTel = hasta.CepTel;
            db.SaveChanges();

            return RedirectToAction("hastalar");
        }

        public ActionResult RandevuAl(AnasayfaModel anasayfa)
        {
            int id = Convert.ToInt32(Session["UyeID"]);
            Randevu randevu = new Randevu();

            randevu.HastaID = id;
            randevu.BransID = Convert.ToInt32(anasayfa.BransID);
            randevu.DoktorID = Convert.ToInt32(anasayfa.DoktorID);
            randevu.HastaneID = Convert.ToInt32(anasayfa.HastaneID);
            randevu.TarihID = Convert.ToInt32(anasayfa.TarihID);
            randevu.SaatID = Convert.ToInt32(anasayfa.SaatID);         
            randevu.SehirID = Convert.ToInt32(anasayfa.SehirID);
            randevu.IlceID = Convert.ToInt32(anasayfa.IlceID);

            db.Randevular.Add(randevu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
