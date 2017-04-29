using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class MaasAraligi
    {
        public decimal Minimum { get; set; }
        public decimal Maksimum { get; set; }

        public MaasAraligi() { }

        public MaasAraligi(decimal min, decimal maks)
        {
            Minimum = min;
            Maksimum = maks;
        }
    }
}