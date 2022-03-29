using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class InitDB : DropCreateDatabaseAlways<RandevuContext>
    {

        protected override void Seed(RandevuContext context)
        {
            context.Roller.Add(new Rol { RolAdi = "Admin" });
            context.Roller.Add(new Rol { RolAdi = "Kullanici" });
            context.SaveChanges();

            context.Kullanicilar.Add(new Kullanici { KullaniciAdi = "11111111111", Sifre = "12345", RolID = 2 });
            context.Kullanicilar.Add(new Kullanici { KullaniciAdi = "22222222222", Sifre = "45678", RolID = 2 });
            context.Kullanicilar.Add(new Kullanici { KullaniciAdi = "33333333333", Sifre = "78999", RolID = 2 });
            context.Kullanicilar.Add(new Kullanici { KullaniciAdi = "00000000000", Sifre = "00000", RolID = 1 });
            context.SaveChanges();

            context.Hastalar.Add(new Hasta { HastaAdi = "Ertan", HastaSoyadi = "Aydın", Cinsiyet = "Erkek", CepTel = "05555555555", KullaniciID = 1 });
            context.Hastalar.Add(new Hasta { HastaAdi = "Hilal", HastaSoyadi = "Güntürkün", Cinsiyet = "Kadın", CepTel = "04444444444", KullaniciID = 2 });
            context.Hastalar.Add(new Hasta { HastaAdi = "Ekmel", HastaSoyadi = "Elbeshare", Cinsiyet = "Erkek", CepTel = "03333333333", KullaniciID = 3 });
            context.SaveChanges();

            context.Sehirler.Add(new Sehir { SehirAdi = "Adana" });
            context.Sehirler.Add(new Sehir { SehirAdi = "Ankara" });
            context.Sehirler.Add(new Sehir { SehirAdi = "Bursa" });
            context.Sehirler.Add(new Sehir { SehirAdi = "İstanbul" });
            context.Sehirler.Add(new Sehir { SehirAdi = "İzmir" });
            context.Sehirler.Add(new Sehir { SehirAdi = "Kayseri" });
            context.Sehirler.Add(new Sehir { SehirAdi = "Nevşehir" });
            context.Sehirler.Add(new Sehir { SehirAdi = "Zonguldak" });
            context.SaveChanges();

            context.Ilceler.Add(new Ilce { IlceAdi = "Ceyhan", SehirID = 1 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Çankaya", SehirID = 2 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Mudanya", SehirID = 3 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Nilüfer", SehirID = 3 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Kadıköy", SehirID = 4 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Beşiktaş", SehirID = 4 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Konak", SehirID = 5 });
            context.Ilceler.Add(new Ilce { IlceAdi = "YeşilHisar", SehirID = 6 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Ürgüp", SehirID = 7 });
            context.Ilceler.Add(new Ilce { IlceAdi = "Ereğli", SehirID = 8 });
            context.SaveChanges();

            context.Hastaneler.Add(new Hastane { HastaneAdi = "Merkez Hastanesi", Telefon = "11111111111", IlceID = 1 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Ankara Hastanesi", Telefon = "11111111111", IlceID = 2 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Mudanya Hastanesi", Telefon = "11111111111", IlceID = 3 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Nilüfer Hastanesi", Telefon = "11111111111", IlceID = 4 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Kadıköy Hastanesi", Telefon = "11111111111", IlceID = 5 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Beşiktaş Hastanesi", Telefon = "11111111111", IlceID = 6 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "İzmir Hastanesi", Telefon = "11111111111", IlceID = 7 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Kayseri Hastanesi", Telefon = "11111111111", IlceID = 8 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Nevşehir Hastanesi", Telefon = "11111111111", IlceID = 9 });
            context.Hastaneler.Add(new Hastane { HastaneAdi = "Zonguldak Hastanesi", Telefon = "11111111111", IlceID = 10 });
            context.SaveChanges();

            context.Branslar.Add(new Brans { BransAdi = "Genel Cerrahi", HastaneID = 1 });
            context.Branslar.Add(new Brans { BransAdi = "Göz Hastalıkları", HastaneID = 2 });
            context.Branslar.Add(new Brans { BransAdi = "Dahiliye", HastaneID = 2 });
            context.Branslar.Add(new Brans { BransAdi = "Kardiyoloji", HastaneID = 1 });
            context.Branslar.Add(new Brans { BransAdi = "Kulak Burun Boğaz", HastaneID = 1 });
            context.Branslar.Add(new Brans { BransAdi = "Ortepedi", HastaneID = 2 });
            context.SaveChanges();

            context.Doktorlar.Add(new Doktor { DoktorAdi = "Cevdet", DoktorSoyadi = "Korkmaz", Cinsiyet = "Erkek", BransID = 1 });
            context.Doktorlar.Add(new Doktor { DoktorAdi = "Ahmet", DoktorSoyadi = "Mehmet", Cinsiyet = "Erkek", BransID = 2 });
            context.SaveChanges();

            context.Tarihler.Add(new Tarih { TarihAdi = DateTime.Now.ToString("d") });
            context.Tarihler.Add(new Tarih { TarihAdi = DateTime.Now.AddDays(1).ToString("d") });
            context.Tarihler.Add(new Tarih { TarihAdi = DateTime.Now.AddDays(3).ToString("d") });
            context.Tarihler.Add(new Tarih { TarihAdi = DateTime.Now.AddDays(4).ToString("d") });
            context.Tarihler.Add(new Tarih { TarihAdi = DateTime.Now.AddDays(5).ToString("d") });
            context.SaveChanges();

            context.Saatler.Add(new Saat { SaatAdi = "12.00", TarihID = 1 });
            context.Saatler.Add(new Saat { SaatAdi = "13.00", TarihID = 1 });
            context.Saatler.Add(new Saat { SaatAdi = "14.00", TarihID = 1 });
            context.Saatler.Add(new Saat { SaatAdi = "15.00", TarihID = 1 });
            context.Saatler.Add(new Saat { SaatAdi = "16.00", TarihID = 1 });
            context.Saatler.Add(new Saat { SaatAdi = "12.00", TarihID = 2 });
            context.Saatler.Add(new Saat { SaatAdi = "13.00", TarihID = 2 });
            context.Saatler.Add(new Saat { SaatAdi = "14.00", TarihID = 2 });
            context.Saatler.Add(new Saat { SaatAdi = "15.00", TarihID = 2 });
            context.Saatler.Add(new Saat { SaatAdi = "16.00", TarihID = 2 });
            context.Saatler.Add(new Saat { SaatAdi = "12.00", TarihID = 3 });
            context.Saatler.Add(new Saat { SaatAdi = "14.00", TarihID = 3 });
            context.Saatler.Add(new Saat { SaatAdi = "15.00", TarihID = 4 });
            context.Saatler.Add(new Saat { SaatAdi = "16.00", TarihID = 5 });
            context.SaveChanges();

            context.Randevular.Add(new Randevu { HastaID = 1, DoktorID = 1, BransID = 1, HastaneID = 1, TarihID = 3, SaatID = 1, IlceID = 1, SehirID = 1 });
            context.Randevular.Add(new Randevu { HastaID = 1, DoktorID = 2, BransID = 2, HastaneID = 1, TarihID = 4, SaatID = 5, IlceID = 1, SehirID = 1 });
            context.SaveChanges();
        }
    }
}   