using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Aralik<T>
    {
        public T Minimum { get; set; }
        public T Maksimum { get; set; }
        public T Net { get; set; }

        public Aralik()
        {

        }

        public Aralik(T net)
        {
            Net = net;
        }

        public Aralik(T minimum,T maksimum)
        {
            Minimum = minimum;
            Maksimum = maksimum;
        }
    }
}