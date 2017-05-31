using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AGM.Models;
using AGM.DB;
namespace AGM.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.User u)
        {
            if (ModelState.IsValid)
            {
                using (MyConnection db = new MyConnection())
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = u.name + " Successfully registerd";
            }
            return RedirectToAction("Login");
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (MyConnection db = new MyConnection())
            {
                var usr = db.Users.Where(u => u.email == user.email && u.password == user.password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.users_id.ToString();
                    Session["RoleID"] = usr.role_id.ToString();
                    Session["UserName"] = usr.name.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", " Your email or password is not correct!");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
          
            if (Session["UserID"] != null)
            {
                if (Session["RoleID"].Equals("1"))
                {
                    return View("Admin");
                }
                else
                {
                    return View("RegularUsers");
                }
            }
            else
            if(Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}