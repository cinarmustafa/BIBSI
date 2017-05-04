using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class MahalleController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListMahalle()
        {

            modell.mahalle = dbContext.Mahalleler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.mahalle);
        }

        [HttpPost]
        public ActionResult InsertMahalle(Mahalle mahalle)
        {
            dbContext.Mahalleler.Add(mahalle);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateMahalle(int? id)
        {
            Mahalle mahalle = null;
            if (id != null)
            {
                mahalle = dbContext.Mahalleler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(mahalle);
        }

        [HttpPost]
        public ActionResult UpdateMahalle(Mahalle model)
        {
            Mahalle mahalle  = dbContext.Mahalleler.Where(x => x.Id == model.Id).FirstOrDefault();
             


            if (mahalle != null)
            {
  
                mahalle.IlceId = model.IlceId;
                mahalle.MahalleAdi = model.MahalleAdi; //Burası önemli buradaki ID durumunu çöz
                mahalle.PostaKodu = model.PostaKodu;
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
            return View(mahalle);
        }

        public ActionResult DeleteMahalle(int? id)
        {
            Mahalle mahalle = null;
            if (id != null)
            {
                mahalle = dbContext.Mahalleler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(mahalle);
        }


        [HttpPost, ActionName("DeleteMahalle")]
        public ActionResult DeleteMahallee(int? id)
        {

            if (id != null)
            {
                Ilce ilce = dbContext.Ilceler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Ilceler.Remove(ilce);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListMahalle", "MahalleController");
        }


    }
}