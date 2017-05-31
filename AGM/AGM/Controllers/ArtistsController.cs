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
    public class ArtistsController : Controller
    {
        private MyConnection db = new MyConnection();
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Artists
        public ActionResult Index()
        {
            var artist = unitOfWork.ArtistRepository.Get();
            return View(artist.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Artist artist = db.Artists.Find(id);
            Artist artist = unitOfWork.ArtistRepository.GetByID(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }
            if (Session["RoleID"].Equals("2"))
            {
                return View("~/Views/Shared/NoAccess.cshtml");
            }
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "artist_id,artist_name,birthday_date,birth_place,artist_description")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ArtistRepository.Insert(artist);
                unitOfWork.Save();
                //db.Artists.Add(artist);
               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }
            if (Session["RoleID"].Equals("2"))
            {
                return View("~/Views/Shared/NoAccess.cshtml");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Artist artist = db.Artists.Find(id);
                Artist artist = unitOfWork.ArtistRepository.GetByID(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "artist_id,artist_name,birthday_date,birth_place,artist_description")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ArtistRepository.Update(artist);
                unitOfWork.Save();
                //db.Entry(artist).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }
            if (Session["RoleID"].Equals("2"))
            {
                return View("~/Views/Shared/NoAccess.cshtml");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //Artist artist = db.Artists.Find(id);
                Artist artist = unitOfWork.ArtistRepository.GetByID(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = unitOfWork.ArtistRepository.GetByID(id);
            unitOfWork.ArtistRepository.Delete(artist);
            unitOfWork.Save();
            //db.Artists.Remove(artist);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }*/
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
