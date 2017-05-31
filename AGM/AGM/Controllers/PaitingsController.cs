using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGM.Models;
using AGM.DB;
namespace AGM.Controllers
{
    public class PaitingsController : Controller
    {
        private MyConnection db = new MyConnection();

        // GET: Paitings
        public ActionResult Index()
        {
            return View(db.Paiting.ToList());
        }

        // GET: Paitings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paitings paitings = db.Paiting.Find(id);
            if (paitings == null)
            {
                return HttpNotFound();
            }
            return View(paitings);
        }

        // GET: Paitings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paitings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paiting_id,paiting_url,artist_id,paiting_description")] Paitings paitings)
        {
            if (ModelState.IsValid)
            {
                db.Paiting.Add(paitings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paitings);
        }

        // GET: Paitings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paitings paitings = db.Paiting.Find(id);
            if (paitings == null)
            {
                return HttpNotFound();
            }
            return View(paitings);
        }

        // POST: Paitings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paiting_id,paiting_url,artist_id,paiting_description")] Paitings paitings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paitings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paitings);
        }

        // GET: Paitings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paitings paitings = db.Paiting.Find(id);
            if (paitings == null)
            {
                return HttpNotFound();
            }
            return View(paitings);
        }

        // POST: Paitings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paitings paitings = db.Paiting.Find(id);
            db.Paiting.Remove(paitings);
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
