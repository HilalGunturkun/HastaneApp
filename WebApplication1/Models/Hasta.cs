using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Hasta
    {
        public int HastaID { get; set; }
        [Display(Name = "Hasta Adı")]      
        public string HastaAdi { get; set; }
        [Display(Name = "Hasta Soyadı")]
        public string HastaSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        [Display(Name = "Cep Telefonu")]
        public string CepTel { get; set; }
        public int? KullaniciID { get; set; }         

        //Navigation Property
        public ICollection<Randevu> Randevular { get; set; }    
        public virtual Kullanici Kullanici { get; set; }    
    }
}