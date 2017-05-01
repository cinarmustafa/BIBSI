using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class IsArayan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EvTelefonu { get; set; }
        public string CepTelefonu { get; set; }
        public Enums.CinsiyetTur Cinsiyet { get; set; }
        public Enums.AskerlikDurumuTur AskerlikDurumu { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int MahalleId { get; set; }
        public string Adres { get; set; }
        public int FotografId { get; set; }
        public MaasAraligi MaasAraligi { get; set; }
        public Enums.EgitimDurumu EgitimDurumu { get; set; }

        public virtual Sehir Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Mahalle Mahalle { get; set; }
        public virtual Fotograf Fotograf { get; set; }
        public virtual ICollection<IsDeneyimi> IsDeneyimleri { get; set; }
    }
}