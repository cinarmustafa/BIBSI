using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class IsDeneyimiController : Controller
    {
        Context dbContext = new Context();
        ModelViewer modell = new ModelViewer();
        // GET: IsDeneyimi
        public ActionResult ListIsDeneyimi()
        {
            modell.isDeneyimi = dbContext.IsDeneyimleri.ToList();

            return View(modell.isDeneyimi);
        }

        [HttpPost]
        public ActionResult IsDeneyimi(IsDeneyimi isDeneyimi)
        {
            dbContext.IsDeneyimleri.Add(isDeneyimi);

            dbContext.SaveChanges();
            return View();
        }

        public ActionResult UpdateIsDeneyimi(int? id)
        {
            IsDeneyimi isDeneyimi = null;
            if (id != null)
            {
                isDeneyimi = dbContext.IsDeneyimleri.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(isDeneyimi);
        }
        [HttpPost]
        public ActionResult UpdateIIsDeneyimi(IsDeneyimi model)
        {
            IsDeneyimi isDeneyimi = dbContext.IsDeneyimleri.Where(x => x.Id == model.Id).FirstOrDefault();
            


            if (isDeneyimi != null)
            {
                isDeneyimi.DeneyimAdi = model.DeneyimAdi;
             
               isDeneyimi.BaslangicTarihi = model.BaslangicTarihi; //Burası önemli buradaki ID durumunu çöz
                isDeneyimi.BitisTarihi = model.BitisTarihi;
                isDeneyimi.Aciklama = model.Aciklama;
                isDeneyimi.IsArayanId = model.IsArayanId;
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
            return View(isDeneyimi);
        }



        public ActionResult DeleteIsDeneyimi(int? id)
        {
            IsDeneyimi isDeneyimi = null;
            if (id != null)
            {
               isDeneyimi = dbContext.IsDeneyimleri.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(isDeneyimi);
        }


        [HttpPost, ActionName("DeleteIsDeneyimi")]
        public ActionResult DeleteIsDeneyimii(int? id)
        {

            if (id != null)
            {
               IsDeneyimi isDeneyimi = dbContext.IsDeneyimleri.Where(x => x.Id == id).FirstOrDefault();


                dbContext.IsDeneyimleri.Remove(isDeneyimi);
                dbContext.SaveChanges();

            }

            return RedirectToAction("ListIsDeneyimi", "IsDeneyimiController");
        }






    }
}