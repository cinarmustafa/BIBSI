using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class IlceController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListIlce()
        {
            
           modell.ilce = dbContext.Ilceler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.ilce);
        }

        [HttpPost]
        public ActionResult InsertIlce(Ilce ilce)
        {
            dbContext.Ilceler.Add(ilce);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateIlce(int? id)
        {
            Ilce ilce = null;
            if (id != null)
            {
                ilce = dbContext.Ilceler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(ilce);
        }

        [HttpPost]
        public ActionResult UpdateIlce(Ilce model)
        {
            Ilce ilce = dbContext.Ilceler.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.sehir = dbContext.Sehirler.ToList();

            
            if (ilce != null)
            {
                ilce.Ad = model.Ad;
                ilce.Id = model.Id;
                ilce.SehirId = model.SehirId; //Burası önemli buradaki ID durumunu çöz

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
            return View(ilce);
        }

        public ActionResult DeleteIlce(int? id)
        {
            Ilce ilce = null;
            if (id != null)
            {
                ilce = dbContext.Ilceler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(ilce);
        }


        [HttpPost,ActionName("DeleteIlce")]
        public ActionResult DeleteIlcee(int? id)
        {
          
            if (id != null)
            {
               Ilce ilce = dbContext.Ilceler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Ilceler.Remove(ilce);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListIlce", "IlceController");
        }







    }
}