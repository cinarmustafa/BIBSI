using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class PozisyonController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Pozisyon
        public ActionResult ListPozisyon()
        {
            modell.pozisyon = dbContext.Pozisyonlar.ToList(); //Veri tabanına select işlemi attık 

            return View(modell.pozisyon);
        }

        [HttpPost]
        public ActionResult InsertPozisyon(Pozisyon pozisyon)
        {
            dbContext.Pozisyonlar.Add(pozisyon);

            dbContext.SaveChanges();
            return View();
        }


        public ActionResult UpdatePozisyon(int? id)
        {
            Pozisyon pozisyon = null;
            if (id != null)
            {
                pozisyon = dbContext.Pozisyonlar.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(pozisyon);
        }




        [HttpPost]
        public ActionResult UpdatePozisyon(Pozisyon model)
        {
          Pozisyon pozisyon = dbContext.Pozisyonlar.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.pozisyon = dbContext.Pozisyonlar.ToList();


            if (pozisyon != null)
            {
                pozisyon.Ad = model.Ad;
              
                pozisyon.Aciklama = model.Aciklama; //Burası önemli buradaki ID durumunu çöz

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
            return View(pozisyon);
        }



        public ActionResult DeletePozisyon(int? id)
        {
            Pozisyon pozisyon = null;
            if (id != null)
            {
                pozisyon= dbContext.Pozisyonlar.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(pozisyon);
        }


        [HttpPost, ActionName("DeletePozisyon")]
        public ActionResult DeletePozisyonn(int? id)
        {

            if (id != null)
            {
                Pozisyon pozisyon = dbContext.Pozisyonlar.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Pozisyonlar.Remove(pozisyon);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListPozisyon", "PozisyonController");
        }
    }
}