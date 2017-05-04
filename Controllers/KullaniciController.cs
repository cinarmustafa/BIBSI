using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class KullaniciController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();

        // GET: Kullanici
        public ActionResult ListKullanici()
        {
            modell.kullanici = dbContext.Kullanicilar.ToList();

            return View(modell.kullanici);
        }
        [HttpPost]
        public ActionResult InsertKullanici(Kullanici kullanici)
        {
            dbContext.Kullanicilar.Add(kullanici);

            dbContext.SaveChanges();
            return View();
        }
        public ActionResult UpdateKullanici(int? id)
        {
            Kullanici kullanici = null;
            if (id != null)
            {
                kullanici = dbContext.Kullanicilar.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult UpdateKullanici(Kullanici model)
        {
            Kullanici kullanici = dbContext.Kullanicilar.Where(x => x.Id == model.Id).FirstOrDefault();
            modell.sehir = dbContext.Sehirler.ToList();


            if (kullanici != null)
            {
                kullanici.KullaniciAdi = model.KullaniciAdi;
                kullanici.Parola = model.Parola;
               kullanici.Email= model.Email; //Burası önemli buradaki ID durumunu çöz

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
            return View(kullanici);
        }

        public ActionResult DeleteKullanici(int? id)
        {
            Kullanici kullanici = null;
            if (id != null)
            {
                kullanici = dbContext.Kullanicilar.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(kullanici);
        }


        [HttpPost, ActionName("DeleteKullanici")]
        public ActionResult DeleteKullanicii(int? id)
        {

            if (id != null)
            {
                Kullanici kullanici = dbContext.Kullanicilar.Where(x => x.Id == id).FirstOrDefault();

                dbContext.Kullanicilar.Remove(kullanici);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListKullanici", "KullaniciController");
        }


    }
}