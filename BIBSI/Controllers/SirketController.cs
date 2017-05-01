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
    public class SirketController : Controller
    {
        private Context db = new Context();

        // GET: Sirket
        public ActionResult Index()
        {
            var sirketler = db.Sirketler.Include(s => s.Fotograf).Include(s => s.IsVeren);
            return View(sirketler.ToList());
        }

        // GET: Sirket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirketler.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        // GET: Sirket/Create
        public ActionResult Create()
        {
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url");
            ViewBag.IsVerenId = new SelectList(db.IsVerenler, "Id", "Ad");
            return View();
        }

        // POST: Sirket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Unvan,FotografId,IsVerenId")] Sirket sirket)
        {
            if (ModelState.IsValid)
            {
                db.Sirketler.Add(sirket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", sirket.FotografId);
            ViewBag.IsVerenId = new SelectList(db.IsVerenler, "Id", "Ad", sirket.IsVerenId);
            return View(sirket);
        }

        // GET: Sirket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirketler.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", sirket.FotografId);
            ViewBag.IsVerenId = new SelectList(db.IsVerenler, "Id", "Ad", sirket.IsVerenId);
            return View(sirket);
        }

        // POST: Sirket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Unvan,FotografId,IsVerenId")] Sirket sirket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sirket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FotografId = new SelectList(db.Fotograflar, "Id", "Url", sirket.FotografId);
            ViewBag.IsVerenId = new SelectList(db.IsVerenler, "Id", "Ad", sirket.IsVerenId);
            return View(sirket);
        }

        // GET: Sirket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirketler.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        // POST: Sirket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sirket sirket = db.Sirketler.Find(id);
            db.Sirketler.Remove(sirket);
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
