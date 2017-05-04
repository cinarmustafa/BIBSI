using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class SirketController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Sirket
        public ActionResult ListSirket()
        {
            modell.sirket = dbContext.Sirketler.ToList();

            return View(modell.sirket);
        }

        [HttpPost]
        public ActionResult InsertSirket(Sirket sirket)
        {
            dbContext.Sirketler.Add(sirket);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateSirket(int? id)
        {
            Sirket sirket = null;
            if (id != null)
            {
                sirket = dbContext.Sirketler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(sirket);
        }


        [HttpPost]
        public ActionResult UpdateSirket(Sirket model)
        {
            Sirket sirket = dbContext.Sirketler.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.sehir = dbContext.Sehirler.ToList();


            if (sirket != null)
            {
                sirket.Ad = model.Ad;
           
                sirket.FotografId = model.FotografId; //Burası önemli buradaki ID durumunu çöz
                sirket.Unvan = model.Unvan;
                sirket.IsVerenId = model.IsVerenId;
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
            return View(sirket);
        }

        public ActionResult DeleteSirket(int? id)
        {
            Sirket sirket = null;
            if (id != null)
            {
                sirket = dbContext.Sirketler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(sirket);
        }


        [HttpPost, ActionName("DeleteSirket")]
        public ActionResult DeleteSirkett(int? id)
        {

            if (id != null)
            {
                Sirket sirket = dbContext.Sirketler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Sirketler.Remove(sirket);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListSirket", "SirketController");
        }










    }
}