using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class BasvuruController : Controller
    {
       
            Context dbContext = new Context();
            ModelViewer modell = new ModelViewer();
            // GET: Ilce
            public ActionResult ListBasvuru()
            {

                modell.basvurular = dbContext.Basvurular.ToList(); //Veri tabanına select işlemi attık 
                return View(modell.basvurular);
            }

            [HttpPost]
            public ActionResult InsertBasvuru(Basvuru basvuru)
            {
                dbContext.Basvurular.Add(basvuru);

                dbContext.SaveChanges();
                return View();
            }

            public ActionResult UpdateBasvuru(int? id)
            {
                Basvuru basvuru = null;
                if (id != null)
                {
                    basvuru = dbContext.Basvurular.Where(x => x.Id == id).FirstOrDefault();
                }
                return View(basvuru);
            }

            [HttpPost]
            public ActionResult UpdateBasvuru(Basvuru model)
            {
                Basvuru basvuru = dbContext.Basvurular.Where(x => x.Id == model.Id).FirstOrDefault();
          


                if (basvuru != null)
                {
                    basvuru.IsArayanId = model.IsArayanId;

                    basvuru.IlanId = model.IlanId;
                    basvuru.BasvuruTarih = model.BasvuruTarih;


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
                return View(basvuru);
            }

            public ActionResult DeleteBasvuru(int? id)
            {
               Basvuru basvuru = null;
                if (id != null)
                {
                    basvuru = dbContext.Basvurular.Where(x => x.Id == id).FirstOrDefault();
                }

                return View(basvuru);
            }


            [HttpPost, ActionName("DeleteBasvuru")]
            public ActionResult DeleteBasvuruu(int? id)
            {

                if (id != null)
                {
                    Basvuru basvuru = dbContext.Basvurular.Where(x => x.Id == id).FirstOrDefault();

                    dbContext.Basvurular.Remove(basvuru);
                    dbContext.SaveChanges();

                }

                return RedirectToAction("ListBasvuru", "BasvuruController");
            }
        }
}