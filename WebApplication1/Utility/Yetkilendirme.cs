using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Utility
{
    public class Yetkilendirme : AuthorizeAttribute
    {
        string roller;
        public Yetkilendirme(string rol)
        {
            roller = rol;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool kontrol = false;

            RandevuContext db = new RandevuContext();

            if (httpContext.Session["KullaniciID"] != null)
            {

                int kullaniciID = (int)httpContext.Session["KullaniciID"];
                string rol = db.Kullanicilar.Include("Rol").Where(u => u.KullaniciID == kullaniciID).Single().Rol.RolAdi;

                if (roller.Contains(rol))
                    kontrol = true;
            }
            return kontrol;
        }


    }
}