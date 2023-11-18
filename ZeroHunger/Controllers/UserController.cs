/*using System;
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
    public class UserController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [HttpPost]

        public ActionResult Index(User User)
        {
            var db = new ZeroHungerEntities();
            var existingUser = db.Users.FirstOrDefault(c => c.UserName == User.UserName);


            if (existingUser != null && User.Password == existingUser.Password && existingUser.Role == "Employee")
            {
                // Create cookie so that it can store user information
                HttpCookie EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie["UserName"] = existingUser.UserName;
                EmployeeCookie["UserId"] = existingUser.UserId.ToString();
                EmployeeCookie.Expires = DateTime.Now.AddMinutes(2); // Set the cookie to expire time
                Response.Cookies.Add(EmployeeCookie);

                return RedirectToAction("firstPage", "Employee");
            }
            else if (existingUser != null && User.Password == existingUser.Password && existingUser.Role == "Admin")
            {
                HttpCookie adminCookie = new HttpCookie("AdminInfo");
                adminCookie["UserName"] = existingUser.UserName;
                adminCookie["UserId"] = existingUser.UserId.ToString();
                adminCookie.Expires = DateTime.Now.AddMinutes(2); //set time
                Response.Cookies.Add(adminCookie);

                return RedirectToAction("Index", "Admin");

            }
            else if (existingUser != null && User.Password == existingUser.Password && existingUser.Role == "Restaurant")
            {
                HttpCookie RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie["UserName"] = existingUser.UserName;
                RestaurantCookie["UserId"] = existingUser.UserId.ToString();
                RestaurantCookie.Expires = DateTime.Now.AddMinutes(2); //set time
                Response.Cookies.Add(RestaurantCookie);

                return RedirectToAction("Index", "Restaurant");

            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }



        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User c)
        {
            var db = new ZeroHungerEntities();
            db.Users.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Logout()
        {

            if (Request.Cookies["AdminInfo"] != null)
            {
                var adminCookie = new HttpCookie("AdminInfo");
                adminCookie.Expires = DateTime.Now.AddYears(-1); // remove user info from cookie so that user can logout
                Response.Cookies.Add(adminCookie);
            }
            else if (Request.Cookies["EmployeeInfo"] != null)
            {
                var EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie.Expires = DateTime.Now.AddYears(-1); // logout
                Response.Cookies.Add(EmployeeCookie);
            }

            else if (Request.Cookies["RestaurantInfo"] != null)
            {
                var RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie.Expires = DateTime.Now.AddYears(-1); // logout
                Response.Cookies.Add(RestaurantCookie);
            }




            return RedirectToAction("Index");
        }


     
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,Role,Name,ContactInfo,Location")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,Role,Name,ContactInfo,Location")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
*/










/*
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
    public class UserController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();
       // private IMapper mapper;


        // GET: User
        public ActionResult Index()
        {
            *//* var users = db.Users.Select(u => mapper.Map<UserDTO>(u)).ToList();
             return View(users);*//*
            var db = new ZeroHungerEntities();
            var data = db.Users.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<UserDTO>>(data);
            return View(data2);
        }

        [HttpPost]
        public ActionResult Index(UserDTO userDTO)
        {
            var existingUser = db.Users.FirstOrDefault(c => c.UserName == userDTO.UserName);

            if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Employee")
            {
                HttpCookie EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie["UserName"] = existingUser.UserName;
                EmployeeCookie["UserId"] = existingUser.UserId.ToString();
                EmployeeCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(EmployeeCookie);

                return RedirectToAction("firstPage", "Employee");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Admin")
            {
                HttpCookie adminCookie = new HttpCookie("AdminInfo");
                adminCookie["UserName"] = existingUser.UserName;
                adminCookie["UserId"] = existingUser.UserId.ToString();
                adminCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(adminCookie);

                return RedirectToAction("Index", "Admin");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Restaurant")
            {
                HttpCookie RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie["UserName"] = existingUser.UserName;
                RestaurantCookie["UserId"] = existingUser.UserId.ToString();
                RestaurantCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(RestaurantCookie);

                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        *//*public ActionResult SignUp(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*//*
        public ActionResult SignUp(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["AdminInfo"] != null)
            {
                var adminCookie = new HttpCookie("AdminInfo");
                adminCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(adminCookie);
            }
            else if (Request.Cookies["EmployeeInfo"] != null)
            {
                var EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(EmployeeCookie);
            }
            else if (Request.Cookies["RestaurantInfo"] != null)
            {
                var RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(RestaurantCookie);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
*/
/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ZeroHunger.DTOs;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class UserController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();
        private IMapper mapper;

        public UserController()
        {
            // Configure AutoMapper mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });

            mapper = config.CreateMapper();
        }

        // GET: User
        public ActionResult Index()
        {
            var data = db.Users.ToList();
            var data2 = mapper.Map<List<UserDTO>>(data);
            return View(data2);
        }

        [HttpPost]
        public ActionResult Index(UserDTO userDTO)
        {
            var existingUser = db.Users.FirstOrDefault(c => c.UserName == userDTO.UserName);

            if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Employee")
            {
                HttpCookie EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie["UserName"] = existingUser.UserName;
                EmployeeCookie["UserId"] = existingUser.UserId.ToString();
                EmployeeCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(EmployeeCookie);

                return RedirectToAction("firstPage", "Employee");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Admin")
            {
                HttpCookie adminCookie = new HttpCookie("AdminInfo");
                adminCookie["UserName"] = existingUser.UserName;
                adminCookie["UserId"] = existingUser.UserId.ToString();
                adminCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(adminCookie);

                return RedirectToAction("Index", "Admin");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Restaurant")
            {
                HttpCookie RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie["UserName"] = existingUser.UserName;
                RestaurantCookie["UserId"] = existingUser.UserId.ToString();
                RestaurantCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(RestaurantCookie);

                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["AdminInfo"] != null)
            {
                var adminCookie = new HttpCookie("AdminInfo");
                adminCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(adminCookie);
            }
            else if (Request.Cookies["EmployeeInfo"] != null)
            {
                var EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(EmployeeCookie);
            }
            else if (Request.Cookies["RestaurantInfo"] != null)
            {
                var RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(RestaurantCookie);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
*/


/*


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
    public class UserController : Controller
    {
        private readonly ZeroHungerEntities db = new ZeroHungerEntities();
        private readonly IMapper mapper;

        public UserController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });

            mapper = config.CreateMapper();
        }

        // GET: User
        public ActionResult Index()
        {
            var data = db.Users.ToList();
            var data2 = mapper.Map<List<UserDTO>>(data);
            return View(data2);
        }

        [HttpPost]
        public ActionResult Index(UserDTO userDTO)
        {
            var existingUser = db.Users.FirstOrDefault(c => c.UserName == userDTO.UserName);

            if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Employee")
            {
                HttpCookie EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie["UserName"] = existingUser.UserName;
                EmployeeCookie["UserId"] = existingUser.UserId.ToString();
                EmployeeCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(EmployeeCookie);

                return RedirectToAction("firstPage", "Employee");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Admin")
            {
                HttpCookie adminCookie = new HttpCookie("AdminInfo");
                adminCookie["UserName"] = existingUser.UserName;
                adminCookie["UserId"] = existingUser.UserId.ToString();
                adminCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(adminCookie);

                return RedirectToAction("Index", "Admin");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Restaurant")
            {
                HttpCookie RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie["UserName"] = existingUser.UserName;
                RestaurantCookie["UserId"] = existingUser.UserId.ToString();
                RestaurantCookie.Expires = DateTime.Now.AddMinutes(2);
                Response.Cookies.Add(RestaurantCookie);

                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["AdminInfo"] != null)
            {
                var adminCookie = new HttpCookie("AdminInfo");
                adminCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(adminCookie);
            }
            else if (Request.Cookies["EmployeeInfo"] != null)
            {
                var EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(EmployeeCookie);
            }
            else if (Request.Cookies["RestaurantInfo"] != null)
            {
                var RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(RestaurantCookie);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(userDTO);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDTO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(mapper.Map<UserDTO>(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
*/




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
    public class UserController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();


        // GET: User
        public ActionResult Index()
        {
            return View();
           /* var data = db.Users.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<UserDTO>>(data);
            return View(data2);*/
        }

        [HttpPost]
        public ActionResult Index(UserDTO userDTO)
        {
            var existingUser = db.Users.FirstOrDefault(c => c.UserName == userDTO.UserName);

            if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Employee")
            {
                HttpCookie EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie["UserName"] = existingUser.UserName;
                EmployeeCookie["UserId"] = existingUser.UserId.ToString();
                EmployeeCookie.Expires = DateTime.Now.AddMinutes(40);
                Response.Cookies.Add(EmployeeCookie);

                return RedirectToAction("Index", "Employee");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Admin")
            {
                HttpCookie adminCookie = new HttpCookie("AdminInfo");
                adminCookie["UserName"] = existingUser.UserName;
                adminCookie["UserId"] = existingUser.UserId.ToString();
                adminCookie.Expires = DateTime.Now.AddMinutes(40);
                Response.Cookies.Add(adminCookie);

                return RedirectToAction("Dashboard", "Admin");
            }
            else if (existingUser != null && userDTO.Password == existingUser.Password && existingUser.Role == "Restaurant")
            {
                HttpCookie RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie["UserName"] = existingUser.UserName;
                RestaurantCookie["UserId"] = existingUser.UserId.ToString();
                RestaurantCookie.Expires = DateTime.Now.AddMinutes(40);
                Response.Cookies.Add(RestaurantCookie);

                return RedirectToAction("Dashboard", "Restaurant");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
        }



        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserDTO c)
        {
            var db = new ZeroHungerEntities();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var signupData = mapper.Map<User>(c);
            db.Users.Add(signupData);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View((user));
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["AdminInfo"] != null)
            {
                var adminCookie = new HttpCookie("AdminInfo");
                adminCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(adminCookie);
            }
            else if (Request.Cookies["EmployeeInfo"] != null)
            {
                var EmployeeCookie = new HttpCookie("EmployeeInfo");
                EmployeeCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(EmployeeCookie);
            }
            else if (Request.Cookies["RestaurantInfo"] != null)
            {
                var RestaurantCookie = new HttpCookie("RestaurantInfo");
                RestaurantCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(RestaurantCookie);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,Role,Name,ContactInfo,Location")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerEntities();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UserDTO, User>();
                });
                var mapper = new Mapper(config);
                var data2 = mapper.Map<User>(user);

                db.Users.Add(data2);
                db.SaveChanges();

                switch (user.Role)
                {
                    case "Admin":
                        return RedirectToAction("Dashboard", "Admin");
                    case "Employee":
                        return RedirectToAction("Index", "Employee");
                    case "Restaurant":
                        return RedirectToAction("FoodInfo", "Restaurant");
                    default:
                        // Handle other roles or provide a default redirection
                        return RedirectToAction("Index", "Home");
                }
                /*return RedirectToAction("Index","Restaurant");*/
                // return RedirectToAction("Index", "Admin");
            }

            return View(user);
        }
      
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var db = new ZeroHungerEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<UserDTO>(user);


            return View(data2);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,Role,Name,ContactInfo,Location")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerEntities();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UserDTO, User>();
                });
                var mapper = new Mapper(config);
                var data2 = mapper.Map<User>(user);

                db.Entry(data2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View((user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
