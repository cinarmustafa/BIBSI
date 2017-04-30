using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class SureModel
    {
        public Enums.SureTipi SureTipi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        public SureModel()
        {
            SureTipi = Enums.SureTipi.Suresiz;
        }

        public SureModel(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            BaslangicTarihi = baslangicTarihi;
            BitisTarihi = bitisTarihi;
            SureTipi = Enums.SureTipi.Sureli;
        }
    }
}