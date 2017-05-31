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
    public class UsersController : Controller
    {
        // private MyConnection db = new MyConnection();
        //private IUserRepository userRepository;

        private UnitOfWork unitOfWork = new UnitOfWork();
       /* public UsersController()
        {
            this.userRepository = new UserRepository(new MyConnection());
        }
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }*/

        // GET: Users
        public ActionResult Index()
        { 
            if(Session["UserID"]==null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }
                if(Session["RoleID"].Equals("2"))
            {
                return View("~/Views/Shared/NoAccess.cshtml");
            }
            var user = unitOfWork.UserRepository.Get();
                return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user;
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }

            if (Session["RoleID"].Equals("2"))
            {
                id = Convert.ToInt32(Session["UserID"]);
                user = unitOfWork.UserRepository.GetByID(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user = unitOfWork.UserRepository.GetByID(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
            }
            return View(user);
        }

        // GET: Users/Create
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

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "users_id,role_id,name,address,email,password,phone,amounnt,short_description")] User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.Insert(user);
                unitOfWork.Save();
                //userRepository.InsertUser(user);
                //userRepository.Save();
               // db.Users.Add(user);
               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user;
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }

            if (Session["RoleID"].Equals("2"))
            {
                id = Convert.ToInt32(Session["UserID"]);
                //user = db.Users.Find(id);
               user = unitOfWork.UserRepository.GetByID(id);
               unitOfWork.Save();
                //user=userRepository.GetUserById(id);
                //userRepository.Save();
                if (user == null)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //user = db.Users.Find(id);
                user = unitOfWork.UserRepository.GetByID(id);
                unitOfWork.Save();
                if (user == null)
                {
                    return HttpNotFound();
                }
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "users_id,role_id,name,address,email,password,phone,amounnt,short_description")] User user)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(user).State = EntityState.Modified;
                //db.SaveChanges();
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
                if(Session["RoleID"].Equals("2"))
                    return RedirectToAction("Details");
                else
                    if(Session["RoleID"].Equals("1"))
                        return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user;
            if (Session["UserID"] == null)
            {
                return View("~/Views/Shared/NotLoggedIn.cshtml");
            }

            if (Session["RoleID"].Equals("2"))
            {
                id = Convert.ToInt32(Session["UserID"]);
                //user = db.Users.Find(id);
                //user = userRepository.GetUserById(id);
                user = unitOfWork.UserRepository.GetByID(id);
            }
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //user = db.Users.Find(id);
                user = unitOfWork.UserRepository.GetByID(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //User user = db.Users.Find(id);
            User user= unitOfWork.UserRepository.GetByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            unitOfWork.UserRepository.Delete(user);
            unitOfWork.Save();
            //userRepository.DeleteUser(id);
            //userRepository.Save();
            //db.Users.Remove(user);
            //db.SaveChanges();
            if (id == Convert.ToInt32(Session["UserID"]))
            {
                Session.Clear();
                return View("~/Views/Home/Index.cshtml");
            }
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
