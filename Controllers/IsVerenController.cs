using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class IsVerenController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListIsVeren()
        {

            modell.isVeren = dbContext.IsVerenler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.isVeren);
        }

        [HttpPost]
        public ActionResult InsertIsVeren(IsVeren isveren)
        {
            dbContext.IsVerenler.Add(isveren);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateIsVeren(int? id)
        {
            IsVeren isveren = null;
            if (id != null)
            {
                isveren = dbContext.IsVerenler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(isveren);
        }

        [HttpPost]
        public ActionResult UpdateIsVeren(IsVeren model)
        {
            IsVeren isveren = dbContext.IsVerenler.Where(x => x.Id == model.Id).FirstOrDefault();
            


            if (isveren != null)
            {
                isveren.Ad = model.Ad;
                isveren.Soyad = model.Soyad;
                isveren.SehirId = model.SehirId;
                isveren.IlceId = model.SehirId;
                isveren.MahalleId = model.MahalleId;
                isveren.Adres = model.Adres;
                isveren.Telefon1 = model.Telefon1;
                isveren.Telefon2 = model.Telefon2;
                isveren.Email = model.Email;
                isveren.WebAdresi = model.WebAdresi;
                isveren.FotografId = model.FotografId;




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
            return View(isveren);
        }

        public ActionResult DeleteIsVeren(int? id)
        {
              IsVeren isveren = null;
            if (id != null)
            {
                isveren = dbContext.IsVerenler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(isveren);
        }


        [HttpPost, ActionName("DeleteIsVeren")]
        public ActionResult DeleteIsVerenn(int? id)
        {

            if (id != null)
            {
                IsVeren isveren = dbContext.IsVerenler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.IsVerenler.Remove(isveren);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListIsVeren", "IsVerenController");
        }


    }
}