using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomPassword;

namespace ShopBridge.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        //public ActionResult Index()
        //{
        //    using (ShopBridgeEntities db = new ShopBridgeEntities())
        //    {
        //        return View(db.Users.ToList());
        //    }
        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                Custom cp = new Custom();
                if (ModelState.IsValid)
                {
                    using (ShopBridgeEntities db = new ShopBridgeEntities())
                    {
                        user.RoleId = 2;
                        user.Password = cp.Encrypt(user.Password);
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = user.Username + " successfully registered. You may now login with your credential";
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                Custom cp = new Custom();
                using (ShopBridgeEntities db = new ShopBridgeEntities())
                {
                    user.Password = cp.Encrypt(user.Password);
                    var usr = db.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["Username"] = usr.Username.ToString();
                        Session["RoleId"] = usr.RoleId.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult LoggedIn()
        //{
        //    if (Session["UserId"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Session["RoleId"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}