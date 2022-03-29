using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Saat
    {
        public int SaatID { get; set; }
        public string SaatAdi { get; set; }
        public int TarihID { get; set; }

        //Navigation Property
        public ICollection<Randevu> Randevular { get; set; }
        public virtual Tarih Tarih { get; set; }
    }
}