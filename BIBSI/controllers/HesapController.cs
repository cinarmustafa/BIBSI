using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YeniUyelik()
        {
            return View();
        }

        public ActionResult UyeGirisi()
        {
            return View();
        }
    }
}