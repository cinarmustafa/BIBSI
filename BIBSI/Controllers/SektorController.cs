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
    public class SektorController : Controller
    {
        private Context db = new Context();

        // GET: Sektor
        public ActionResult Index()
        {
            return View(db.Sektorler.ToList());
        }

        // GET: Sektor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektor sektor = db.Sektorler.Find(id);
            if (sektor == null)
            {
                return HttpNotFound();
            }
            return View(sektor);
        }

        // GET: Sektor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sektor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Aciklama")] Sektor sektor)
        {
            if (ModelState.IsValid)
            {
                db.Sektorler.Add(sektor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sektor);
        }

        // GET: Sektor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektor sektor = db.Sektorler.Find(id);
            if (sektor == null)
            {
                return HttpNotFound();
            }
            return View(sektor);
        }

        // POST: Sektor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Aciklama")] Sektor sektor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sektor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sektor);
        }

        // GET: Sektor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektor sektor = db.Sektorler.Find(id);
            if (sektor == null)
            {
                return HttpNotFound();
            }
            return View(sektor);
        }

        // POST: Sektor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sektor sektor = db.Sektorler.Find(id);
            db.Sektorler.Remove(sektor);
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
