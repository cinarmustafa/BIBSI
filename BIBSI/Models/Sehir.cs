using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Sehir
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public Sehir() { }

        public Sehir(string ad)
        {
            Ad = ad;
        }

        public virtual ICollection<Ilce> Ilceler { get; set; }
    }
}