using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class IsArayanController : Controller
    {

        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListIsArayan()
        {

            modell.isArayan = dbContext.IsArayanlar.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.isArayan);
        }

        [HttpPost]
        public ActionResult InsertIsArayan(IsArayan isArayan)
        {
            dbContext.IsArayanlar.Add(isArayan);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateIsArayan(int? id)
        {
            IsArayan isArayan = null;
            if (id != null)
            {
                isArayan = dbContext.IsArayanlar.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(isArayan);
        }

        [HttpPost]
        public ActionResult UpdateIsArayan(IsArayan model)
        {
            IsArayan isArayan = dbContext.IsArayanlar.Where(x => x.Id == model.Id).FirstOrDefault();
            


            if (isArayan != null)
            {
                isArayan.Ad = model.Ad;
                isArayan.Soyad = model.Soyad;
                isArayan.EvTelefonu = model.EvTelefonu;
                isArayan.CepTelefonu = model.CepTelefonu;
                isArayan.Cinsiyet = model.Cinsiyet;
                isArayan.AskerlikDurumu = model.AskerlikDurumu;
                isArayan.DogumTarihi = model.DogumTarihi;
                isArayan.SehirId = model.SehirId;
                isArayan.IlceId = model.IlceId;
                isArayan.MahalleId = model.MahalleId;
                isArayan.Adres = model.Adres;
                isArayan.FotografId = model.FotografId;
                isArayan.MaasAraligi =model.MaasAraligi;
                isArayan.EgitimDurumu = model.EgitimDurumu;
                

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
            return View(isArayan);
        }

        public ActionResult DeleteIsArayan(int? id)
        {
            IsArayan isArayan = null;
            if (id != null)
            {
                isArayan = dbContext.IsArayanlar.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(isArayan);
        }


        [HttpPost, ActionName("DeleteIsArayan")]
        public ActionResult DeleteIsArayann(int? id)
        {

            if (id != null)
            {
                IsArayan isArayan = dbContext.IsArayanlar.Where(x => x.Id == id).FirstOrDefault();

                dbContext.IsArayanlar.Remove(isArayan);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListIsArayan", "IsArayanController");
        }

    }
}