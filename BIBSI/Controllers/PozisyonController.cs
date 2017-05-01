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
    public class PozisyonController : Controller
    {
        private Context db = new Context();

        // GET: Pozisyon
        public ActionResult Index()
        {
            return View(db.Pozisyonlar.ToList());
        }

        // GET: Pozisyon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozisyon pozisyon = db.Pozisyonlar.Find(id);
            if (pozisyon == null)
            {
                return HttpNotFound();
            }
            return View(pozisyon);
        }

        // GET: Pozisyon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pozisyon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Aciklama")] Pozisyon pozisyon)
        {
            if (ModelState.IsValid)
            {
                db.Pozisyonlar.Add(pozisyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pozisyon);
        }

        // GET: Pozisyon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozisyon pozisyon = db.Pozisyonlar.Find(id);
            if (pozisyon == null)
            {
                return HttpNotFound();
            }
            return View(pozisyon);
        }

        // POST: Pozisyon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Aciklama")] Pozisyon pozisyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozisyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pozisyon);
        }

        // GET: Pozisyon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozisyon pozisyon = db.Pozisyonlar.Find(id);
            if (pozisyon == null)
            {
                return HttpNotFound();
            }
            return View(pozisyon);
        }

        // POST: Pozisyon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pozisyon pozisyon = db.Pozisyonlar.Find(id);
            db.Pozisyonlar.Remove(pozisyon);
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
