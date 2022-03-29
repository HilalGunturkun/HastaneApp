using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Doktor
    {     
        public int DoktorID { get; set; }
        [Display(Name = "Doktor Adı")]
        public string DoktorAdi { get; set; }
        [Display(Name = "Doktor Soyadı")]
        public string DoktorSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public int BransID { get; set; }


        //Navigation Property
        public virtual Brans Brans { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}