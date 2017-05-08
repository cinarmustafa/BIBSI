using BIBSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.ViewModels
{
    public class ModelViewer : ViewModelBase
    {
        public List<IsVeren> isVeren { get; set; }
        public List<Kullanici> kullanici { get; set; }
        public List<Mahalle> mahalle { get; set; }
        public List<Meslek> meslek { get; set; }
        public List<Pozisyon> pozisyon { get; set; }
        public List<Sehir> sehir { get; set; }
        public List<Ilce> ilce { get; set; }
        public List<Sektor> sektor { get; set; }
        public List<Sirket> sirket { get; set; }
        public List<IsDeneyimi> isDeneyimi { get; set; }
        public List<IsArayan> isArayan { get; set; }
        public List<Ilan> ilanlar { get; set; }
        public List<Fotograf> foto { get; set; }
        public List<Basvuru> basvurular { get; set; }

        public ModelViewer()
        {
            using (Context db = new Context())
            {
                Sehirler = db.Sehirler.ToList();
                Pozisyonlar = db.Pozisyonlar.ToList();
            }
        }
    }
}