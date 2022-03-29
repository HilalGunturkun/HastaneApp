using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class RandevuContext : DbContext
    {
        public RandevuContext()
        {
            Database.SetInitializer<RandevuContext>(new InitDB());
        }

        public DbSet<Rol> Roller { get; set; }  
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Brans> Branslar { get; set; }  
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }  
        public DbSet<Tarih> Tarihler { get; set; }  
        public DbSet<Saat> Saatler { get; set; }    
    }
}