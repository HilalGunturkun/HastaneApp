using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sehir
    {
        [Key]
        public int SehirID { get; set; }
        [Display(Name = "Şehir Adı")]
        public string SehirAdi { get; set; }

        public virtual ICollection<Ilce> Ilceler { get; set; }
    }
} 