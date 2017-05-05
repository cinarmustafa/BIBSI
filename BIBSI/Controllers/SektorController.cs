using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{

    public class SektorController : Controller
    {

        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Sektor
        public ActionResult ListSektor()
        {
            modell.sektor = dbContext.Sektorler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.sektor);
        }


        [HttpPost]
        public ActionResult InsertSektor(Sektor  sektor)
        {
            dbContext.Sektorler.Add(sektor);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateSektor(int? id)
        {
            Sektor sektor = null;
            if (id != null)
            {
               sektor = dbContext.Sektorler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(sektor);
        }

        [HttpPost]
        public ActionResult UpdateSektor(Sektor model)
        {
            Sektor sektor = dbContext.Sektorler.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.sektor = dbContext.Sektorler.ToList();


            if (sektor != null)
            {
                
                sektor.Ad = model.Ad;

                sektor.Aciklama = model.Aciklama; //Burası önemli buradaki ID durumunu çöz

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
            return View(sektor);
        }


        public ActionResult DeleteSektor(int? id)
        {
            Sektor sektor = null;
            if (id != null)
            {
                sektor = dbContext.Sektorler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(sektor);
        }


        [HttpPost, ActionName("DeleteSektor")]
        public ActionResult DeleteSektorr(int? id)
        {

            if (id != null)
            {
                Sektor sektor= dbContext.Sektorler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Sektorler.Remove(sektor);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListSektor", "SektorController");
        }




    }
}