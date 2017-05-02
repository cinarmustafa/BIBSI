using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class UyeGirisiModel
    {
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}