using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTOs;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            /* if (Request.Cookies["AdminInfo"] != null)
             {
                 var db = new ZeroHungerEntities();
                 var data = db.CollectRequests.ToList();
                 return View(data);

             }
             return RedirectToAction("Admin", "User" ,"Restaurant");*/

            return View();
        }

        public ActionResult Dashboard()
        {

            int userId = 0;


            if (Request.Cookies["AdminInfo"] != null && int.TryParse(Request.Cookies["AdminInfo"]["UserId"], out userId))
            {
                var db = new ZeroHungerEntities();
                var data = db.CollectRequests.ToList();
                return View(data);

            }


            return View("Index", "User");


        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,RestaurantUserId,MaxPreserveTime,Status,CollectionAddress,AssignedEmployeeId,CollectionTime,CompletionTime")] CollectRequestDTO collectRequest)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerEntities();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<CollectRequestDTO, CollectRequest>();
                });
                var mapper = new Mapper(config);
                var data2 = mapper.Map<CollectRequest>(collectRequest);

                db.CollectRequests.Add(data2);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View(collectRequest);
        }


/*        public ActionResult EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
     
        public ActionResult EmployeeCreate(EmployeeController em)
        {
            var db = new ZeroHungerEntities();
            db.DeliveryConfirmations.Add(em);
            db.SaveChanges();
            return RedirectToAction("EmployeeController");

        }*/




    }
}