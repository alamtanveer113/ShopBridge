using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBridge.Models;

namespace ShopBridge.Controllers.ManageOrder1
{
    public class ManageOrdersController : Controller
    {
        private ShopBridgeEntities db = new ShopBridgeEntities();

        // GET: ManageOrders
        public ActionResult Index()
        {
            try
            {
                if (!(Session["RoleId"] == null) && Convert.ToInt32(Session["RoleId"]) == 1)
                {
                    var manageOrders = db.ManageOrders.Include(m => m.User);
                    return View(manageOrders.ToList());
                }
                else if (Convert.ToInt32(Session["RoleId"]) == 2)
                {
                    var manageOrders = db.ManageOrders.Include(m => m.User);
                    //ManageOrder manageOrder = db.ManageOrders.Find("test");
                    //return View(db.ManageOrders.OrderByDescending(Model => Model.UserId).Where(u => u.UserId == "test"));
                    //return View(manageOrder);
                    return View(db.ManageOrders.OrderByDescending(Model => Model.UserId).ToList());
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: ManageOrders/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var manageOrder = db.ManageOrders.Find(id);
                if (manageOrder == null)
                {
                    return HttpNotFound();
                }
                return View(manageOrder);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: ManageOrders/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // POST: ManageOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderName,OrderCity,OrderCountry,OrderAddress,OrderDescription,Status,Amount,UserId")] ManageOrder manageOrder)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    db.ManageOrders.Add(manageOrder);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", manageOrder.UserId);
                return View(manageOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: ManageOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (Convert.ToInt32(Session["RoleId"]) == 1)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ManageOrder manageOrder = db.ManageOrders.Find(id);
                    if (manageOrder == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", manageOrder.UserId);
                    return View(manageOrder);
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
}

        // POST: ManageOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderName,OrderCity,OrderCountry,OrderAddress,OrderDescription,Status,Amount,UserId")] ManageOrder manageOrder)
        {
            try
            {
                if (Convert.ToInt32(Session["RoleId"]) == 1)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(manageOrder).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", manageOrder.UserId);
                    return View(manageOrder);
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: ManageOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Convert.ToInt32(Session["RoleId"]) == 1)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    var manageOrder = db.ManageOrders.Find(id);
                    if (manageOrder == null)
                    {
                        return HttpNotFound();
                    }
                    return View(manageOrder);
                }
                else
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: ManageOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var manageOrder = db.ManageOrders.Find(id);
                db.ManageOrders.Remove(manageOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
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
