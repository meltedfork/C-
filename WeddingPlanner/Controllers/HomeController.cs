using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;

        public HomeController(WeddingContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? currentUser = HttpContext.Session.GetInt32("inSession");
            if(currentUser != null)
            {
                return RedirectToAction("Dashboard", "Wedding");
            }
            else
            {
                return View();  
            }
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserView model)
        {    
            if(ModelState.IsValid)
            { 
                var currentUser = _context.Users.Any(u => u.Email == model.register.Email);
                if(currentUser == true)
                {
                    ModelState.AddModelError("register.Email", "An account already exists with that email");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<RegisterUser> Hasher = new PasswordHasher<RegisterUser>();
                    string hashed = Hasher.HashPassword(model.register, model.register.Password);
                    
                    User newUser = new User
                    {
                        UserFirstName = model.register.UserFirstName,
                        UserLastName = model.register.UserLastName,
                        Email = model.register.Email,
                        Password = hashed
                    };
                
                    _context.Add(newUser);
                    _context.SaveChanges();

                    User inSession = _context.Users.Where(u => u.Email == model.register.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("inSession", inSession.UserId);
                    System.Console.WriteLine("=============> REGISTER SUCCESS");
                    return RedirectToAction("Dashboard", "Wedding");
                }
            }
            else
            {
               return View("Index"); 
            }
            
        }


        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(UserView model)
        {
            User RealUser = _context.Users.SingleOrDefault(user => user.Email == model.login.Email);
            if(RealUser != null)    
            {    
                if (ModelState.IsValid)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if(Hasher.VerifyHashedPassword(RealUser, RealUser.Password, model.login.Password) == 0)    //means if it doesn't match anything
                    {
                        ModelState.AddModelError("login.Password", "Incorrect password.");
                        return View("Index");   
                    }
                  
                    HttpContext.Session.SetInt32("inSession", RealUser.UserId);
                    System.Console.WriteLine("=============> LOGIN SUCCESS");
                    return RedirectToAction("Dashboard", "Wedding");
                    
                }
                else
                {
                    return View("Index");         
                }
            }
            else
            {
                ModelState.AddModelError("login.Email", "There is no record of this email - Please register!");
                return View("Index");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
