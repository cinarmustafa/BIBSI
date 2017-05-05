using BIBSI.Controllers;
using BIBSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBSI.ViewModels
{
    public class ViewModelBase
    {
        Context db = new Context();
        public List<Sehir> Sehirler { get; set; }
    }
}