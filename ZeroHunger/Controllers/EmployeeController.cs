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
    public class EmployeeController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var deliveryConfirmations = db.DeliveryConfirmations.Include(d => d.CollectRequest).Include(d => d.User);
            return View(deliveryConfirmations.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryConfirmation deliveryConfirmation = db.DeliveryConfirmations.Find(id);
            if (deliveryConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(deliveryConfirmation);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status");
            ViewBag.ConfirmingEmployeeId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConfirmationId,ConfirmingEmployeeId,RequestId,ConfirmationTime,DetailsComments")] DeliveryConfirmation deliveryConfirmation)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryConfirmations.Add(deliveryConfirmation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", deliveryConfirmation.RequestId);
            ViewBag.ConfirmingEmployeeId = new SelectList(db.Users, "UserId", "UserName", deliveryConfirmation.ConfirmingEmployeeId);
            return View(deliveryConfirmation);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryConfirmation deliveryConfirmation = db.DeliveryConfirmations.Find(id);
            if (deliveryConfirmation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", deliveryConfirmation.RequestId);
            ViewBag.ConfirmingEmployeeId = new SelectList(db.Users, "UserId", "UserName", deliveryConfirmation.ConfirmingEmployeeId);
            return View(deliveryConfirmation);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConfirmationId,ConfirmingEmployeeId,RequestId,ConfirmationTime,DetailsComments")] DeliveryConfirmation deliveryConfirmation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryConfirmation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CollectRequests, "RequestId", "Status", deliveryConfirmation.RequestId);
            ViewBag.ConfirmingEmployeeId = new SelectList(db.Users, "UserId", "UserName", deliveryConfirmation.ConfirmingEmployeeId);
            return View(deliveryConfirmation);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryConfirmation deliveryConfirmation = db.DeliveryConfirmations.Find(id);
            if (deliveryConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(deliveryConfirmation);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryConfirmation deliveryConfirmation = db.DeliveryConfirmations.Find(id);
            db.DeliveryConfirmations.Remove(deliveryConfirmation);
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
