using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class IlanController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListIlan()
        {
            modell.ilanlar = dbContext.Ilanlar.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.ilanlar);
        }

        [HttpPost]
        public ActionResult InsertIlan(Ilan ilan)
        {
            dbContext.Ilanlar.Add(ilan);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateIlan(int? id)
        {
            Ilan ilan = null;
            if (id != null)
            {
                ilan = dbContext.Ilanlar.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ilan);
        }

        [HttpPost]
        public ActionResult UpdateIlan(Ilan model)
        {
            Ilan ilan = dbContext.Ilanlar.Where(x => x.Id == model.Id).FirstOrDefault();
          

            if (ilan != null)
            {
                ilan.IsTanimi = model.IsTanimi;
                ilan.Aciklama = model.Aciklama;
                ilan.IsverenId = model.IsverenId;
                ilan.SektorId = model.SektorId;
                ilan.PozisyonId = model.PozisyonId;
                ilan.MeslekId = model.MeslekId;
                ilan.Cinsiyet = model.Cinsiyet;
                ilan.AskerlikDurumu = model.AskerlikDurumu;
                ilan.YolMasrafi = model.YolMasrafi;
                ilan.SSKMasrafi = model.SSKMasrafi;
                ilan.CalismaBicimi = model.CalismaBicimi;
                ilan.EgitimDurumu = model.EgitimDurumu;
                ilan.MaasAraligi = model.MaasAraligi;
                ilan.Deneyim = model.Deneyim;
                ilan.YasAraligi = model.YasAraligi;
                ilan.IlanSuresi = model.IlanSuresi;
                ilan.IsciSayisi = model.IsciSayisi;
                ilan.EklenmeTarihi = model.EklenmeTarihi;
             
                
                int sonuc = dbContext.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Güncelleme işlemi başarılı.";
                    ViewBag.Status = "success";

                }

                else
                {
                    ViewBag.Result = "Güncelleme işlemi başarısız.";
                    ViewBag.Status = "danger";
                }
            }
            return View(ilan);
        }

        public ActionResult DeleteIlan(int? id)
        {
            Ilan ilan = null;
            if (id != null)
            {
                ilan = dbContext.Ilanlar.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(ilan);
        }


        [HttpPost, ActionName("DeleteIlan")]
        public ActionResult DeleteIlann(int? id)
        {

            if (id != null)
            {
                Ilan ilan = dbContext.Ilanlar.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Ilanlar.Remove(ilan);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListIlan", "IlanController");
        }
    }
}