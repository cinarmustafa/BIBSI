using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Ilan
    {
        public int Id { get; set; }
        public string IsTanimi { get; set; }
        public string Aciklama { get; set; }
        public int IsverenId { get; set; }
        public int SektorId { get; set; }
        public int PozisyonId { get; set; }
        public int MeslekId { get; set; }
        public Enums.CinsiyetTur Cinsiyet { get; set; }
        public Enums.AskerlikDurumuTur AskerlikDurumu { get; set; }
        public bool YolMasrafi { get; set; }
        public bool SSKMasrafi { get; set; }
        public bool CalismaBicimi { get; set; }
        public Enums.EgitimDurumu EgitimDurumu { get; set; }
        public MaasAraligi MaasAraligi { get; set; }
        public IlanIsDeneyimi Deneyim { get; set; }
        public Aralik<byte> YasAraligi { get; set; }
        public SureModel IlanSuresi { get; set; }
        public int IsciSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public Ilan()
        {
            EklenmeTarihi = DateTime.Now;
        }

        public Ilan(DateTime eklenmeTarihi)
        {
            EklenmeTarihi = eklenmeTarihi;
        }

        public virtual IsVeren IsVeren { get; set; }
        public virtual Sektor Sektor { get; set; }
        public virtual Pozisyon Pozisyon { get; set; }
        public virtual Meslek Meslek { get; set; }
    }
}