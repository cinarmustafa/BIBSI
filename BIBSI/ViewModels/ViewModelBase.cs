using BIBSI.Controllers;
using BIBSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.ViewModels
{
    public class ViewModelBase
    {
        public List<Sehir> Sehirler { get; set; }
        public List<Pozisyon> Pozisyonlar { get; set; }
        public ViewModelBase()
        {
            using (Context db = new Context())
            {
                Sehirler = db.Sehirler.ToList();
                Pozisyonlar = db.Pozisyonlar.ToList();
            }
        }
    }
}