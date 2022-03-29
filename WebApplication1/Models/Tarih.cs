using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tarih
    {
        public int TarihID { get; set; }
        public string TarihAdi { get; set; }

        //Navigation Property
        public ICollection<Randevu> Randevular { get; set; }
        public virtual ICollection<Saat> Saatler { get; set; }
    }
}