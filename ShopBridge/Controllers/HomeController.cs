using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class HomeController : Controller
    {
        ShopBridgeEntities db;
        public HomeController()
        {
            db = new ShopBridgeEntities();
        }
        

        //public ActionResult Index(string searchTerm = null)
        //{
        //    var model =
        //       db.Restaurants
        //           .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
        //           .Where(r => searchTerm == null || r.Name.Contains(searchTerm))
        //           .Take(10)
        //           .Select(r => new RestaurantViewModel
        //           {
        //               RestaurantId = r.RestaurantId,
        //               Name = r.Name,
        //               City = r.City,
        //               Country = r.Country,
        //               Address = r.Address,
        //               CountOfReviews = r.Reviews.Count()
        //           });

        //    return View(model);
        //}

        public ActionResult Index()
        {
            try
            {
                return View(db.Posts.OrderByDescending(Model => Model.Date).Take(4).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return View(db.Posts.ToList());
        }

        //public string Limit(string input, int max)
        //{
        //    if (!String.IsNullOrEmpty(input) && input.Length > max)
        //    {
        //        return input.Substring(0, max);
        //    }
        //    return input;
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}