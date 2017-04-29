using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class IsVeren
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public int MahalleId { get; set; }
        public string Adres { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email { get; set; }
        public string WebAdresi { get; set; }
        public int FotografId { get; set; }

        public virtual Sehir Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Mahalle Mahalle { get; set; }
        public virtual Fotograf Fotograf { get; set; }
        public virtual ICollection<Sirket> Sirketler { get; set; }
    }
}