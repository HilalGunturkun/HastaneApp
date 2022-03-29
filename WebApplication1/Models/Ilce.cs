using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Ilce
    {
        [Key]
        public int IlceID { get; set; }
        [Display(Name = "İlçe Adı")]
        public string IlceAdi { get; set; }
        [Display(Name = "Şehir Adı")]
        public int SehirID { get; set; }

        //Navigation Property
        [ForeignKey("SehirID")]
        public virtual Sehir Sehir { get; set; }
        public virtual ICollection<Hastane> Hastaneler { get; set; } 
    }
}