using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Utility;
using WebApplication1.DAL;
using WebApplication1.Models;
using static WebApplication1.Utility.Yetkilendirme;

namespace WebApplication1.Controllers
{
    public class GirisController : Controller
    {
        RandevuContext db = new RandevuContext();

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Giris(string kullanici, string sifre)   
        {
            RandevuContext db = new RandevuContext();
            Kullanici uye = db.Kullanicilar.Where(u => u.KullaniciAdi == kullanici && u.Sifre == sifre).SingleOrDefault();

            if (uye != null)
            {

                Session["UyeID"] = uye.KullaniciID;
                Session.Timeout = 5;
                
                return RedirectToAction( "Index", uye.Rol.RolAdi ); 
            }

            return RedirectToAction("Index", "Giris");
        }

        [HttpPost]
        public ActionResult UyeOl(string kimlik, string no, string ad, string soyad, string cinsiyet, string telefon)
        {     
                Kullanici kullanici = new Kullanici();
                kullanici.KullaniciAdi = kimlik;
                kullanici.Sifre = no;
                kullanici.RolID = 2;
                db.Kullanicilar.Add(kullanici);
                db.SaveChanges();

                Hasta hasta = new Hasta();
                hasta.HastaAdi = ad;
                hasta.HastaSoyadi = soyad;
                hasta.Cinsiyet = cinsiyet;
                hasta.CepTel = telefon;
                hasta.KullaniciID = kullanici.KullaniciID;
                db.Hastalar.Add(hasta);
                db.SaveChanges();

                return RedirectToAction("Index");
        }
    }
}
