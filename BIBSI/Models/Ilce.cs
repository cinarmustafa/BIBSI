using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Ilce
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int SehirId { get; set; }

        public Ilce()
        {

        }

        public Ilce(string ad,int sehirId)
        {
            SehirId = sehirId;
            Ad = ad;
        }

        public virtual Sehir Sehir { get; set; }
        public virtual ICollection<Mahalle> Mahalleler { get; set; }
    }
}