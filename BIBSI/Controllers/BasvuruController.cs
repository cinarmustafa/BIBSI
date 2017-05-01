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
    public class BasvuruController : Controller
    {
        private Context db = new Context();

        // GET: Basvuru
        public ActionResult Index()
        {
            var basvurular = db.Basvurular.Include(b => b.Ilan).Include(b => b.IsArayan);
            return View(basvurular.ToList());
        }

        // GET: Basvuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvurular.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // GET: Basvuru/Create
        public ActionResult Create()
        {
            ViewBag.IlanId = new SelectList(db.Ilanlar, "Id", "IsTanimi");
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad");
            return View();
        }

        // POST: Basvuru/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsArayanId,IlanId,BasvuruTarih")] Basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.Basvurular.Add(basvuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlanId = new SelectList(db.Ilanlar, "Id", "IsTanimi", basvuru.IlanId);
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", basvuru.IsArayanId);
            return View(basvuru);
        }

        // GET: Basvuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvurular.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlanId = new SelectList(db.Ilanlar, "Id", "IsTanimi", basvuru.IlanId);
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", basvuru.IsArayanId);
            return View(basvuru);
        }

        // POST: Basvuru/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsArayanId,IlanId,BasvuruTarih")] Basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basvuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlanId = new SelectList(db.Ilanlar, "Id", "IsTanimi", basvuru.IlanId);
            ViewBag.IsArayanId = new SelectList(db.IsArayanlar, "Id", "Ad", basvuru.IsArayanId);
            return View(basvuru);
        }

        // GET: Basvuru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basvuru basvuru = db.Basvurular.Find(id);
            if (basvuru == null)
            {
                return HttpNotFound();
            }
            return View(basvuru);
        }

        // POST: Basvuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basvuru basvuru = db.Basvurular.Find(id);
            db.Basvurular.Remove(basvuru);
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
