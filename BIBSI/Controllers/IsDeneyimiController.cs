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
    public class IsDeneyimiController : Controller
    {
        private Context db = new Context();

        // GET: IsDeneyimi
        public ActionResult Index()
        {
            var isDeneyimleri = db.IsDeneyimleri.Include(i => i.IsArayan);
            return View(isDeneyimleri.ToList());
        }

        // GET: IsDeneyimi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsDeneyimi isDeneyimi = db.IsDeneyimleri.Find(id);
            if (isDeneyimi == null)
            {
                return HttpNotFound();
            }
            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Create
        public ActionResult Create()
        {
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad");
            return View();
        }

        // POST: IsDeneyimi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsArayanId,DeneyimAdi,BaslangicTarihi,BitisTarihi,Aciklama")] IsDeneyimi isDeneyimi)
        {
            if (ModelState.IsValid)
            {
                db.IsDeneyimleri.Add(isDeneyimi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", isDeneyimi.IsArayanId);
            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsDeneyimi isDeneyimi = db.IsDeneyimleri.Find(id);
            if (isDeneyimi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", isDeneyimi.IsArayanId);
            return View(isDeneyimi);
        }

        // POST: IsDeneyimi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsArayanId,DeneyimAdi,BaslangicTarihi,BitisTarihi,Aciklama")] IsDeneyimi isDeneyimi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isDeneyimi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", isDeneyimi.IsArayanId);
            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IsDeneyimi isDeneyimi = db.IsDeneyimleri.Find(id);
            if (isDeneyimi == null)
            {
                return HttpNotFound();
            }
            return View(isDeneyimi);
        }

        // POST: IsDeneyimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IsDeneyimi isDeneyimi = db.IsDeneyimleri.Find(id);
            db.IsDeneyimleri.Remove(isDeneyimi);
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
