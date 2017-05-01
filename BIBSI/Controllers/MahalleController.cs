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
    public class MahalleController : Controller
    {
        private Context db = new Context();

        // GET: Mahalle
        public ActionResult Index()
        {
            var mahalleler = db.Mahalleler.Include(m => m.Ilce).Include(m => m.Sehir);
            return View(mahalleler.ToList());
        }

        // GET: Mahalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalleler.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // GET: Mahalle/Create
        public ActionResult Create()
        {
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad");
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad");
            return View();
        }

        // POST: Mahalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SehirId,IlceId,MahalleAdi,PostaKodu")] Mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.Mahalleler.Add(mahalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", mahalle.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", mahalle.SehirId);
            return View(mahalle);
        }

        // GET: Mahalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalleler.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", mahalle.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", mahalle.SehirId);
            return View(mahalle);
        }

        // POST: Mahalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SehirId,IlceId,MahalleAdi,PostaKodu")] Mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlceId = new SelectList(db.Ilceler, "Id", "Ad", mahalle.IlceId);
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", mahalle.SehirId);
            return View(mahalle);
        }

        // GET: Mahalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalleler.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // POST: Mahalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mahalle mahalle = db.Mahalleler.Find(id);
            db.Mahalleler.Remove(mahalle);
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
