using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Brans
    {
        public int BransID { get; set; }
        [Display(Name = "Branş Adı")]
        public string BransAdi { get; set; }
        public int? HastaneID { get; set; }  

        //Navigation Property
        public virtual Hastane Hastane { get; set; } 
        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Randevu> Randevular { get; set; }    

    }
}   