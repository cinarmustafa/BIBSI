using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class MaasAraligi : Aralik<decimal>
    {
        public MaasAraligi() { }

        public MaasAraligi(decimal netMaas) : base(netMaas) { }

        public MaasAraligi(decimal min, decimal maks) : base(min, maks) { }
    }
}