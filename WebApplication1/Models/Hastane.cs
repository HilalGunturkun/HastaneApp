using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Hastane
    {
        [Key]
        public int HastaneID { get; set; }
        [Display(Name = "Hastane Adı")]
        public string HastaneAdi { get; set; }
        public string Telefon { get; set; }    
        public int IlceID { get; set; }

        //Navigation Property

        [ForeignKey("IlceID")]
        public virtual Ilce Ilce { get; set; }
        public virtual ICollection<Randevu> Randevular { get; set; }
        public virtual ICollection<Brans> Branslar { get; set; }    


    }
}   