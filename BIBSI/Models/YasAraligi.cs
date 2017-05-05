using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class YasAraligi : Aralik<byte>
    {
        public YasAraligi() { }

        public YasAraligi(byte netYas) : base(netYas) { }

        public YasAraligi(byte min, byte maks) : base(min, maks) { }
    }
}