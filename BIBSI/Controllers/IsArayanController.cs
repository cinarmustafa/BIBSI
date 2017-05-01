using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BIBSI.Models;

namespace BIBSI.Controllers
{
    public class IsArayanController : Controller
    {
        private Context db = new Context();

        // GET: IsArayan
        public ActionResult Index()
        {
            var isArayanlar = db.IsArayanlar.Include(i => i.Fotograf).Include(i => i.Ilce).Include(i => i.Mahalle).Include(i => i.Sehir);
            return View(isArayanlar.ToList());
        }

        // GET: IsArayan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsArayan isArayan = db.IsArayanlar.Find(id);
            if (isArayan == null)
            {
                return HttpNotFound();
            }
            return View(isArayan);
        }

        // GET: IsArayan/Create
        public ActionResult Create()
        {
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url");
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad");
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi");
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad");
            return View();
        }

        // POST: IsArayan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,EvTelefonu,CepTelefonu,Cinsiyet,AskerlikDurumu,DogumTarihi,SehirId,IlceId,MahalleId,Adres,FotografId,MaasAraligi,EgitimDurumu")] IsArayan isArayan)
        {
            if (ModelState.IsValid)
            {
                db.IsArayanlar.Add(isArayan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isArayan.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isArayan.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isArayan.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isArayan.SehirId);
            return View(isArayan);
        }

        // GET: IsArayan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsArayan isArayan = db.IsArayanlar.Find(id);
            if (isArayan == null)
            {
                return HttpNotFound();
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isArayan.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isArayan.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isArayan.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isArayan.SehirId);
            return View(isArayan);
        }

        // POST: IsArayan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,EvTelefonu,CepTelefonu,Cinsiyet,AskerlikDurumu,DogumTarihi,SehirId,IlceId,MahalleId,Adres,FotografId,MaasAraligi,EgitimDurumu")] IsArayan isArayan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isArayan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isArayan.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isArayan.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isArayan.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isArayan.SehirId);
            return View(isArayan);
        }

        // GET: IsArayan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsArayan isArayan = db.IsArayanlar.Find(id);
            if (isArayan == null)
            {
                return HttpNotFound();
            }
            return View(isArayan);
        }

        // POST: IsArayan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IsArayan isArayan = db.IsArayanlar.Find(id);
            db.IsArayanlar.Remove(isArayan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
