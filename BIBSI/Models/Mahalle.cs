using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Mahalle
    {
        public int Id { get; set; }
        public int IlceId { get; set; }
        public string MahalleAdi { get; set; }
        public string PostaKodu { get; set; }

        public Mahalle()
        {

        }

        public Mahalle(string mahalleAdi,int sehirId, int ilceId)
        {
            MahalleAdi = mahalleAdi;
            IlceId = ilceId;
        }

        public Mahalle(string mahalleAdi, int sehirId, int ilceId, string postaKodu)
        {
            MahalleAdi = mahalleAdi;
            IlceId = ilceId;
            PostaKodu = postaKodu;
        }

        public virtual Ilce Ilce { get; set; }
    }
}