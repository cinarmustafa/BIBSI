using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Sirket
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Unvan { get; set; }
        public int FotografId { get; set; }
        public int IsVerenId { get; set; }

        public Sirket()
        {

        }

        public Sirket(string ad, string unvan, int isVerenId)
        {
            Ad = ad;
            Unvan = unvan;
            IsVerenId = isVerenId;
        }

        public Sirket(string ad, string unvan, int isVerenId, int logoId)
        {
            Ad = ad;
            Unvan = unvan;
            IsVerenId = isVerenId;
            FotografId = logoId;
        }

        //Logo
        public virtual Fotograf Fotograf { get; set; }
        public virtual IsVeren IsVeren { get; set; }
    }
}