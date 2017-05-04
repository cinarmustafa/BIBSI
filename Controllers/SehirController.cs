using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class SehirController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListSehir()
        {

            modell.sehir = dbContext.Sehirler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.sehir);
        }

        [HttpPost]
        public ActionResult InsertSehir(Sehir sehir)
        {
            dbContext.Sehirler.Add(sehir);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateSehir(int? id)
        {
            Sehir sehir = null;
            if (id != null)
            {
                sehir = dbContext.Sehirler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(sehir);
        }

        [HttpPost]
        public ActionResult UpdateSehir(Sehir model)
        {
            Sehir sehir = dbContext.Sehirler.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.sehir = dbContext.Sehirler.ToList();


            if (sehir != null)
            {
                sehir.Ad = model.Ad;
               
             

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
            return View(sehir);
        }

        public ActionResult DeleteSehir(int? id)
        {
            Sehir sehir = null;
            if (id != null)
            {
                sehir = dbContext.Sehirler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(sehir);
        }


        [HttpPost, ActionName("DeleteSehir")]
        public ActionResult DeleteSehirr(int? id)
        {

            if (id != null)
            {
             Sehir sehir = dbContext.Sehirler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Sehirler.Remove(sehir);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListSehir", "SehirController");
        }
    }
}