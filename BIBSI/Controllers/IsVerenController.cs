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
    public class IsVerenController : Controller
    {
        private Context db = new Context();

        // GET: IsVeren
        public ActionResult Index()
        {
            var isVerenler = db.IsVerenler.Include(i => i.Fotograf).Include(i => i.Ilce).Include(i => i.Mahalle).Include(i => i.Sehir);
            return View(isVerenler.ToList());
        }

        // GET: IsVeren/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsVeren isVeren = db.IsVerenler.Find(id);
            if (isVeren == null)
            {
                return HttpNotFound();
            }
            return View(isVeren);
        }

        // GET: IsVeren/Create
        public ActionResult Create()
        {
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url");
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad");
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi");
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad");
            return View();
        }

        // POST: IsVeren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,SehirId,IlceId,MahalleId,Adres,Telefon1,Telefon2,Email,WebAdresi,FotografId")] IsVeren isVeren)
        {
            if (ModelState.IsValid)
            {
                db.IsVerenler.Add(isVeren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isVeren.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isVeren.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isVeren.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isVeren.SehirId);
            return View(isVeren);
        }

        // GET: IsVeren/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsVeren isVeren = db.IsVerenler.Find(id);
            if (isVeren == null)
            {
                return HttpNotFound();
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isVeren.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isVeren.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isVeren.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isVeren.SehirId);
            return View(isVeren);
        }

        // POST: IsVeren/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,SehirId,IlceId,MahalleId,Adres,Telefon1,Telefon2,Email,WebAdresi,FotografId")] IsVeren isVeren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isVeren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", isVeren.FotografId);
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", isVeren.IlceId);
            ViewBag.MahalleId = new SelectList(db.Mahalleler, "Id", "MahalleAdi", isVeren.MahalleId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", isVeren.SehirId);
            return View(isVeren);
        }

        // GET: IsVeren/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsVeren isVeren = db.IsVerenler.Find(id);
            if (isVeren == null)
            {
                return HttpNotFound();
            }
            return View(isVeren);
        }

        // POST: IsVeren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IsVeren isVeren = db.IsVerenler.Find(id);
            db.IsVerenler.Remove(isVeren);
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
