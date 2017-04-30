using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Basvuru
    {
        public int Id { get; set; }
        public int IsArayanId { get; set; }
        public int IlanId { get; set; }
        public DateTime BasvuruTarih { get; set; }

        public Basvuru()
        {

        }

        public Basvuru(int isArayanId,int ilanId)
        {
            IsArayanId = isArayanId;
            IlanId = ilanId;
            BasvuruTarih = DateTime.Now;
        }

        public Basvuru(int isArayanId, int ilanId, DateTime basvuruTarihi)
        {
            IsArayanId = isArayanId;
            IlanId = ilanId;
            BasvuruTarih = basvuruTarihi;
        }

        public virtual IsArayan IsArayan { get; set; }
        public virtual Ilan Ilan { get; set; }
    }
}