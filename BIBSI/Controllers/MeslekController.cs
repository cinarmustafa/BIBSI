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
    public class MeslekController : Controller
    {
        private Context db = new Context();

        // GET: Meslek
        public ActionResult Index()
        {
            return View(db.Meslekler.ToList());
        }

        // GET: Meslek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslekler.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // GET: Meslek/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meslek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Aciklama")] Meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.Meslekler.Add(meslek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meslek);
        }

        // GET: Meslek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslekler.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: Meslek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Aciklama")] Meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meslek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meslek);
        }

        // GET: Meslek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslekler.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: Meslek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meslek meslek = db.Meslekler.Find(id);
            db.Meslekler.Remove(meslek);
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
