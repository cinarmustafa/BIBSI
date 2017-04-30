using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class IlanIsDeneyimi : Aralik<int>
    {
        public Enums.ZamanPeriyodu Periyot { get; set; }

        public IlanIsDeneyimi()
        {

        }

        public IlanIsDeneyimi(int net, Enums.ZamanPeriyodu periyot) : base(net)
        {
            Periyot = periyot;
        }

        public IlanIsDeneyimi(int minimum, int maksimum, Enums.ZamanPeriyodu periyot) : base(minimum, maksimum)
        {
            Periyot = periyot;
        }
    }
}