using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class HomeController : Controller
    {
        ModelViewer modelViewer = new ModelViewer();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Sehirler = modelViewer.Sehirler;
            ViewBag.Pozisyonlar = modelViewer.Pozisyonlar;
            return View();
        }

        public ActionResult Iletisim()
        {
            ViewBag.Sehirler = modelViewer.Sehirler;
            ViewBag.Pozisyonlar = modelViewer.Pozisyonlar;
            return View();
        }

        [HttpGet]
        public ActionResult IlanlariListele(string AramaCumlesi,string SehirId)
        {
            List<Ilan> arananIlanlar;
            int _sehirId = int.Parse(SehirId);
            using (Context db = new Context())
            {
                arananIlanlar = db.Ilanlar.Where(i => i.SehirId == _sehirId && (i.IsTanimi.Contains(AramaCumlesi) || i.Aciklama.Contains(AramaCumlesi))).ToList();
            }
            return View(arananIlanlar);
        }
    }
}