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
    public class CollectRequestFoodController : Controller
    {
        // GET: CollectRequestFood
        public ActionResult Index()
        {
            var db = new ZeroHungerEntities();
            var data = db.CollectRequestsFooditems.ToList();
            return View(data);
           
        }

    
    public ActionResult Create()
    {

        return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectRequestsFoodItemId,RequestId,ItemName,Quantity,ExpiryDate,Description")] CollectRequestsFooditemDTO collectRequestsFooditem)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerEntities();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<CollectRequestsFooditemDTO, CollectRequestsFooditem>();
                });
                var mapper = new Mapper(config);
                var data2 = mapper.Map<CollectRequestsFooditem>(collectRequestsFooditem);

                db.CollectRequestsFooditems.Add(data2);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(collectRequestsFooditem);
        }

        /*  [HttpPost]
          public ActionResult Create(CollectRequestsFooditemDTO o)
          {
              if (ModelState.IsValid)
              {
                  #region
                  var config = new MapperConfiguration(cfg => {

                      cfg.CreateMap<CollectRequestsFooditemDTO, CollectRequestsFooditem>();

                  });

                  var Mapper = new Mapper(config);
                  var data2 = Mapper.Map<CollectRequestsFooditemDTO>(o);
                  #endregion

                  var db = new ZeroHungerEntities();
                      db.CollectRequestsFooditems.Add(data2);
                  db.SaveChanges();
                  return RedirectToAction("collectRequestsFooditem");

              }

              return View(o);
          }*/


        /*     public ActionResult Details(int? id)
             {
                 if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }

                 CollectRequestFoodController CollectRequestsFooditem = db.CollectRequestsFooditems.Find(id);
                 if (CollectRequestsFooditem == null)
                 {
                     return HttpNotFound();
                 }

                 return View((CollectRequestsFooditem));
             }
     */
        public ActionResult Details(int id)
        {
            var db = new ZeroHungerEntities();
            var CollectRequestsFooditem = db.CollectRequestsFooditems.Find(id);

            return View(CollectRequestsFooditem);

        }



    }
}