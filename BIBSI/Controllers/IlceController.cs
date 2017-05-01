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
    public class IlceController : Controller
    {
        private Context db = new Context();

        // GET: Ilce
        public ActionResult Index()
        {
            var ilceler = db.Ilceler.Include(i => i.Sehir);
            return View(ilceler.ToList());
        }

        // GET: Ilce/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // GET: Ilce/Create
        public ActionResult Create()
        {
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad");
            return View();
        }

        // POST: Ilce/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,SehirId")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Ilceler.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", ilce.SehirId);
            return View(ilce);
        }

        // GET: Ilce/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", ilce.SehirId);
            return View(ilce);
        }

        // POST: Ilce/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,SehirId")] Ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SehirId = new SelectList(db.Sehirler, "Id", "Ad", ilce.SehirId);
            return View(ilce);
        }

        // GET: Ilce/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilce ilce = db.Ilceler.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // POST: Ilce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilce ilce = db.Ilceler.Find(id);
            db.Ilceler.Remove(ilce);
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
