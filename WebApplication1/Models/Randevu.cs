using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Randevu
    {
        public int? RandevuID { get; set; }
        public int? HastaID { get; set; }
        public int? BransID { get; set; }    
        public int? DoktorID { get; set; }
        public int? HastaneID { get; set; }
        public int? TarihID { get; set; }
        public int? SaatID { get; set; }
        public int? SehirID { get; set; }
        public int? IlceID { get; set; } 

        //Navigation Property
        public virtual Hasta Hasta { get; set; }
        public virtual Doktor Doktor { get; set; }
        public virtual Hastane Hastane { get; set; }
        public virtual Brans Brans { get; set; }    
        public virtual Tarih Tarih { get; set; }    
        public virtual Saat Saat { get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }

    }   
}