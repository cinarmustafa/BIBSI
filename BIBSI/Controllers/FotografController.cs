using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class FotografController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: Ilce
        public ActionResult ListFoto()
        {

            modell.foto = dbContext.Fotograflar.ToList(); //Veri tabanına select işlemi attık 
            return View(modell.foto);
        }

        [HttpPost]
        public ActionResult InsertFoto(Fotograf foto)
        {
            dbContext.Fotograflar.Add(foto);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateFoto(int? id)
        {
           Fotograf foto = null;
            if (id != null)
            {
                foto = dbContext.Fotograflar.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(foto);
        }

        [HttpPost]
        public ActionResult UpdateFoto(Fotograf model)
        {
            Fotograf foto = dbContext.Fotograflar.Where(x => x.Id == model.Id).FirstOrDefault();
           


            if (foto != null)
            {
                foto.Url = model.Url;
                foto.Tur = model.Tur;
                 //Burası önemli buradaki ID durumunu çöz

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
            return View(foto);
        }

        public ActionResult DeleteFoto(int? id)
        {
          Fotograf foto = null;
            if (id != null)
            {
                foto = dbContext.Fotograflar.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(foto);
        }


        [HttpPost, ActionName("DeleteFoto")]
        public ActionResult DeleteFotoo(int? id)
        {

            if (id != null)
            {
                Fotograf foto  = dbContext.Fotograflar.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Fotograflar.Remove(foto);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListFoto", "FotografController");
        }
    }
}