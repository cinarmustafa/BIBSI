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
    public class IlanController : Controller
    {
        private Context db = new Context();

        // GET: Ilan
        public ActionResult Index()
        {
            var ilanlar = db.Ilanlar.Include(i => i.IsVeren).Include(i => i.Meslek).Include(i => i.Pozisyon).Include(i => i.Sektor);
            return View(ilanlar.ToList());
        }

        // GET: Ilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilanlar.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Ilan/Create
        public ActionResult Create()
        {
            ViewBag.IsverenId = new SelectList(db.IsVerenler, "Id", "Ad");
            ViewBag.MeslekId = new SelectList(db.Meslekler, "Id", "Ad");
            ViewBag.PozisyonId = new SelectList(db.Pozisyonlar, "Id", "Ad");
            ViewBag.SektorId = new SelectList(db.Sektorler, "Id", "Ad");
            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsTanimi,Aciklama,IsverenId,SektorId,PozisyonId,MeslekId,Cinsiyet,AskerlikDurumu,YolMasrafi,SSKMasrafi,CalismaBicimi,EgitimDurumu,MaasAraligi,Deneyim,IlanSuresi,IsciSayisi,EklenmeTarihi")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Ilanlar.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IsverenId = new SelectList(db.IsVerenler, "Id", "Ad", ilan.IsverenId);
            ViewBag.MeslekId = new SelectList(db.Meslekler, "Id", "Ad", ilan.MeslekId);
            ViewBag.PozisyonId = new SelectList(db.Pozisyonlar, "Id", "Ad", ilan.PozisyonId);
            ViewBag.SektorId = new SelectList(db.Sektorler, "Id", "Ad", ilan.SektorId);
            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilanlar.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsverenId = new SelectList(db.IsVerenler, "Id", "Ad", ilan.IsverenId);
            ViewBag.MeslekId = new SelectList(db.Meslekler, "Id", "Ad", ilan.MeslekId);
            ViewBag.PozisyonId = new SelectList(db.Pozisyonlar, "Id", "Ad", ilan.PozisyonId);
            ViewBag.SektorId = new SelectList(db.Sektorler, "Id", "Ad", ilan.SektorId);
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsTanimi,Aciklama,IsverenId,SektorId,PozisyonId,MeslekId,Cinsiyet,AskerlikDurumu,YolMasrafi,SSKMasrafi,CalismaBicimi,EgitimDurumu,MaasAraligi,Deneyim,IlanSuresi,IsciSayisi,EklenmeTarihi")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IsverenId = new SelectList(db.IsVerenler, "Id", "Ad", ilan.IsverenId);
            ViewBag.MeslekId = new SelectList(db.Meslekler, "Id", "Ad", ilan.MeslekId);
            ViewBag.PozisyonId = new SelectList(db.Pozisyonlar, "Id", "Ad", ilan.PozisyonId);
            ViewBag.SektorId = new SelectList(db.Sektorler, "Id", "Ad", ilan.SektorId);
            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilanlar.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilanlar.Find(id);
            db.Ilanlar.Remove(ilan);
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
