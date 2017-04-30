using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public static class Enums
    {
        public enum CinsiyetTur
        {
            Bay = 0,
            Bayan = 1
        }

        public enum AskerlikDurumuTur
        {
            Yapildi = 0,
            Tecilli = 1,
            Muaf = 2
        }

        public enum FotografTur
        {
            IsArayan = 0,
            IsVeren = 1,
            Ilan = 2,
            SirketLogosu = 3
        }

        public enum CalismaBicimi
        {
            TamZamanli = 0,
            YariZamanli = 1,
            Stajyer = 2
        }

        public enum EgitimDurumu
        {
            Ilkokul = 0,
            Ortaokul = 1,
            Lise = 2,
            Universite = 3,
            YuksekLisans = 4,
            Doktora = 5
        }

        public enum ZamanPeriyodu
        {
            Gun = 0,
            Ay = 1,
            Yıl = 2
        }

        public enum SureTipi
        {
            Suresiz = 0,
            Sureli = 1
        }
    }
}