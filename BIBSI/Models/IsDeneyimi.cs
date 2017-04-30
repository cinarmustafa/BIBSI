using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class IsDeneyimi
    {
        public int Id { get; set; }
        public int IsArayanId { get; set; }
        public string DeneyimAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }

        public virtual IsArayan IsArayan { get; set; }
    }
}