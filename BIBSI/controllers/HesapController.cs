using BIBSI.ViewModels;
using BIBSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class HesapController : Controller
    {
        ModelViewer modelViewer = new ModelViewer();
        // GET: Hesap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YeniUyelik()
        {
            ViewBag.Sehirler = modelViewer.Sehirler;
            return View();
        }

        public ActionResult UyeGirisi()
        {
            ViewBag.Sehirler = modelViewer.Sehirler;
            return View();
        }

        [HttpPost]
        public ActionResult UyeGirisi(UyeGirisiModel uyeGirisiModel)
        {
            return View();
        }
    }
}