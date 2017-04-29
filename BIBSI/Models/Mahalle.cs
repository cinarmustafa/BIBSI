using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Mahalle
    {
        public int Id { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public string MahalleAdi { get; set; }
        public string PostaKodu { get; set; }

        public Mahalle()
        {

        }

        public Mahalle(string mahalleAdi,int sehirId, int ilceId)
        {
            MahalleAdi = mahalleAdi;
            SehirId = sehirId;
            IlceId = ilceId;
        }

        public Mahalle(string mahalleAdi, int sehirId, int ilceId, string postaKodu)
        {
            MahalleAdi = mahalleAdi;
            SehirId = sehirId;
            IlceId = ilceId;
            PostaKodu = postaKodu;
        }

        public virtual Sehir Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }
    }
}