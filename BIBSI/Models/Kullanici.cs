using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
    }
}