using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class AnasayfaModel
    {
        //Dropdownlar için
        public string SehirID { get; set; }
        public string IlceID { get; set; }
        public string HastaneID { get; set; }
        public string BransID { get; set; } 
        public string DoktorID { get; set; }
        public string TarihID { get; set; }
        public string SaatID { get; set; }  

        public SelectList Sehirler { get; set; }
        public SelectList Ilceler { get; set; } 
        public SelectList Hastaneler { get; set; }
        public SelectList Branslar { get; set; }
        public SelectList Doktorlar { get; set; }
        public SelectList Tarihler { get; set; }
        public SelectList Saatler { get; set; }   

        //
        public ICollection<Randevu> Randevular { get; set; }
        public Hasta Hastalar { get; set; }

    }
}