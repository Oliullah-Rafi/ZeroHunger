using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class StoredFoodItemController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();

        // GET: StoredFoodItem
        public ActionResult Index()
        {
            var storedFoodItems = db.StoredFoodItems.Include(s => s.CollectRequest);
            return View(storedFoodItems.ToList());
        }

        // GET: StoredFoodItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredFoodItem storedFoodItem = db.StoredFoodItems.Find(id);
            if (storedFoodItem == null)
            {
                return HttpNotFound();
            }
            return View(storedFoodItem);
        }

        // GET: StoredFoodItem/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status");
            return View();
        }

        // POST: StoredFoodItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodItemId,RequestId,ItemName,Quantity,ExpiryDate,Description")] StoredFoodItem storedFoodItem)
        {
            if (ModelState.IsValid)
            {
                db.StoredFoodItems.Add(storedFoodItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", storedFoodItem.RequestId);
            return View(storedFoodItem);
        }

        // GET: StoredFoodItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredFoodItem storedFoodItem = db.StoredFoodItems.Find(id);
            if (storedFoodItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", storedFoodItem.RequestId);
            return View(storedFoodItem);
        }

        // POST: StoredFoodItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodItemId,RequestId,ItemName,Quantity,ExpiryDate,Description")] StoredFoodItem storedFoodItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storedFoodItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", storedFoodItem.RequestId);
            return View(storedFoodItem);
        }

        // GET: StoredFoodItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredFoodItem storedFoodItem = db.StoredFoodItems.Find(id);
            if (storedFoodItem == null)
            {
                return HttpNotFound();
            }
            return View(storedFoodItem);
        }

        // POST: StoredFoodItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoredFoodItem storedFoodItem = db.StoredFoodItems.Find(id);
            db.StoredFoodItems.Remove(storedFoodItem);
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
