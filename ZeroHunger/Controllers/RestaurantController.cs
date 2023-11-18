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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {

            int userId = 0;
           

            if (Request.Cookies["RestaurantInfo"] != null && int.TryParse(Request.Cookies["RestaurantInfo"]["UserId"], out userId))
            {
                var db = new ZeroHungerEntities();
                var data = db.CollectRequestsFooditems.ToList();
                return View(data);
               
            }


            return View("Index", "User");


        }

      



        public ActionResult Logout()
        {

            if (Request.Cookies["RestaurantInfo"] != null)
            {
                var UserCookie = new HttpCookie("RestaurantInfo");
                UserCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(UserCookie);
            }


            return RedirectToAction("Index");
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
  



        public ActionResult CollectedFood(int CollectRequestsFoodItemId, int RequestId, string ItemName, int Quantity, string ExpiryDate, string Description)
        {
            if (Session["foodItems"] == null)
            {
                Session["foodItems"] = new List<FoodList>();
            }

            List<FoodList> foodItems = (List<FoodList>)Session["foodItems"];




            var existingFood = foodItems.FirstOrDefault(item => item.CollectRequestsFoodItemId == CollectRequestsFoodItemId);
       
            if (existingFood != null)
            {
                
                existingFood.Quantity += Quantity;

            }
            else
            {
               
                foodItems.Add(new FoodList
                {
                    CollectRequestsFoodItemId = CollectRequestsFoodItemId,
                    RequestId = RequestId,

                    ItemName = ItemName,
                    Quantity = Quantity,
                    ExpiryDate = ExpiryDate,
                    Description = Description


                });
            }

            Session["foodItems"] = foodItems;

            return RedirectToAction("Dashboard");

        }

        [HttpGet]
        public ActionResult ViewFoodItems()
        {
            
            List<FoodList> foodAllItems = Session["foodItems"] as List<FoodList>;

            if (foodAllItems == null)
            {
                ViewBag.Message = "Your food items are empty.";
            }
            else
            {

                ViewBag.FoodViewDetails = foodAllItems;
            }

            return View("ViewFoodItems");
        }






        [HttpPost]
        public ActionResult PlaceFoodOrder()
        {
    
            var FoodViewDetails = Session["foodItems"] as List<FoodList>;

            if (FoodViewDetails != null)
            {
            
                int UserId;
                if (Request.Cookies["RestaurantInfo"] != null && int.TryParse(Request.Cookies["RestaurantInfo"]["UserId"], out UserId))
                {
                    using (var db = new ZeroHungerEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {

                            try
                            {
                                
                                var collected = new CollectRequest
                                {
                                    MaxPreserveTime = DateTime.Now,
                                    Status = "Ordered",
                                  
                                    AssignedEmployeeId = UserId,

                                    CollectionTime = DateTime.Now,


                                    CompletionTime = DateTime.Now,




                                };
                                db.CollectRequests.Add(collected);
                                db.SaveChanges();

                                
                                foreach (var CollectedFood in FoodViewDetails)
                                {
                                    var foodCollected = new CollectRequestsFooditem
                                    {
                                        RequestId = CollectedFood.RequestId,
                                        ItemName = CollectedFood.ItemName,
                                        Quantity = CollectedFood.Quantity,
                                        ExpiryDate = CollectedFood.ExpiryDate,
                                        Description = CollectedFood.Description
                                    };
                                    db.CollectRequestsFooditems.Add(foodCollected);
                                }

                                db.SaveChanges();

                            
                                Session.Remove("foodItems");

                                transaction.Commit(); 


                                return RedirectToAction("ThankYouForTheFood");
                            }
                            catch (Exception ex)
                            {
                                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                                transaction.Rollback();
                            }
                        }
                    }
                }
            }

            return RedirectToAction("ThankYouForTheFood");
        }




        public ActionResult ThankYouForTheFood()
        {
            return View();
        }

        public ActionResult FoodHistory(int userId)
        {
            var db = new ZeroHungerEntities();

            var userFoods = db.CollectRequests.Where(o => o.AssignedEmployeeId == userId).ToList();

            return View(userFoods);
        }





    }
}