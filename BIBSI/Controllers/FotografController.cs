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
    public class FotografController : Controller
    {
        private Context db = new Context();

        // GET: Fotograf
        public ActionResult Index()
        {
            return View(db.Fotograflar.ToList());
        }

        // GET: Fotograf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotograf fotograf = db.Fotograflar.Find(id);
            if (fotograf == null)
            {
                return HttpNotFound();
            }
            return View(fotograf);
        }

        // GET: Fotograf/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fotograf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Tur")] Fotograf fotograf)
        {
            if (ModelState.IsValid)
            {
                db.Fotograflar.Add(fotograf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fotograf);
        }

        // GET: Fotograf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotograf fotograf = db.Fotograflar.Find(id);
            if (fotograf == null)
            {
                return HttpNotFound();
            }
            return View(fotograf);
        }

        // POST: Fotograf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Tur")] Fotograf fotograf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotograf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fotograf);
        }

        // GET: Fotograf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotograf fotograf = db.Fotograflar.Find(id);
            if (fotograf == null)
            {
                return HttpNotFound();
            }
            return View(fotograf);
        }

        // POST: Fotograf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fotograf fotograf = db.Fotograflar.Find(id);
            db.Fotograflar.Remove(fotograf);
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
