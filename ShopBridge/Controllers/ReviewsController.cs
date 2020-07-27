using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class ReviewsController : Controller
    {
        private ShopBridgeEntities db;

        public ReviewsController()
        {
            db = new ShopBridgeEntities();
        }
        // GET: Reviews
        //public ActionResult Index()
        //{
        //    if (Session["UserId"]==null)
        //    {
        //        return RedirectToAction("Login", "Users");
        //    }
        //    else
        //    {
        //        int test = Convert.ToInt32(Session["UserId"]);
        //        var reviews = db.Reviews.Include(r => r.Restaurant).Include(r => r.User).Where(r => r.User.UserId == test);
        //        return View(reviews.ToList());
        //    }

        //}

        public ActionResult Index([Bind(Prefix = "id")]int restaurantId)
        {
            try
            {
                var restaurant = db.Restaurants.Find(restaurantId);
                if (restaurant != null)
                {
                    return View(restaurant);
                }
                return HttpNotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name");
                //ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    review.UserId = Convert.ToInt32(Session["UserId"]);

                    db.Reviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = review.RestaurantId });
                }
                //ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", review.RestaurantId);
                //ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", review.UserId);
                return View(review);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                //ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", review.RestaurantId);
                //ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", review.UserId);
                return View(review);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //review.UserId = Convert.ToInt32(Session["UserId"]);
                    //review.RestaurantId = 
                    //db.Entry(review).Property(x => x.RestaurantId).IsModified = false;
                    db.Entry(review).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("List", "Restaurants");
                }
                //ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", review.RestaurantId);
                //ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", review.UserId);
                return View(review);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                db.Reviews.Remove(review);
                db.SaveChanges();
                return RedirectToAction("List", "Restaurants");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
