using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Fotograf
    {
        public int Id { get; set; }
        public string Url { get; set; }    
        public Enums.FotografTur Tur { get; set; }

        private DateTime EklenmeTarihi { get; set; }

        public Fotograf()
        {
            EklenmeTarihi = DateTime.Now;
        }

        public Fotograf(string url,Enums.FotografTur fotoTur)
        {
            Url = url;
            Tur = fotoTur;
            EklenmeTarihi = DateTime.Now;
        }

        public Fotograf(string url, Enums.FotografTur fotoTur,DateTime eklenmeTarihi)
        {
            Url = url;
            Tur = fotoTur;
            EklenmeTarihi = eklenmeTarihi;
        }
    }
}