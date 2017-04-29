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
            Tecilli = 1
        }

        public enum FotografTur
        {
            IsArayan = 0,
            IsVeren = 1,
            Ilan = 2,
            SirketLogosu = 3
        }
    }
}