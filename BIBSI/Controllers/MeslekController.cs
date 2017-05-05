using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class MeslekController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListMeslek()
        {

            modell.meslek = dbContext.Meslekler.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.meslek);
        }

        [HttpPost]
        public ActionResult InsertMeslek(Meslek meslek)
        {
            dbContext.Meslekler.Add(meslek);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateMeslek(int? id)
        {
            Meslek meslek = null;
            if (id != null)
            {
                meslek = dbContext.Meslekler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(meslek);
        }

        [HttpPost]
        public ActionResult UpdateMeslek(Meslek model)
        {
            Meslek meslek = dbContext.Meslekler.Where(x => x.Id == model.Id).FirstOrDefault();
          


            if (meslek != null)
            {
                meslek.Ad = model.Ad;
       
                meslek.Aciklama = model.Aciklama; //Burası önemli buradaki ID durumunu çöz

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
            return View(meslek);
        }

        public ActionResult DeleteMeslek(int? id)
        {
            Meslek meslek = null;
            if (id != null)
            {
                meslek = dbContext.Meslekler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(meslek);
        }


        [HttpPost, ActionName("DeleteMeslek")]
        public ActionResult DeleteMeslekk(int? id)
        {

            if (id != null)
            {
                Meslek  meslek = dbContext.Meslekler.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Meslekler.Remove(meslek);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListMeslek", "MeslekController");
        }




    }
}