using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //ViewBag.errors = "";
            return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(User user)
        {
            if (ModelState.IsValid)
            {
                string emailQuery = $"SELECT * from Users WHERE (Email= '{user.login.Email}' AND Password= '{user.login.Password}')";
                var email = DbConnector.Query(emailQuery);
                if (email.Count == 1)
                {
                    string queryid = $"SELECT * from Users WHERE (email = '{user.login.Email}')";
                    var insession = DbConnector.Query(queryid);
                    int id = (int)insession[0]["id"]; //grabbing the user id and setting to "id"
                    HttpContext.Session.SetInt32("id", id);
                    System.Console.WriteLine($"this is current user id: {id}");
                    return RedirectToAction("Success");
                }
                else 
                {
                    //ViewBag.errors 
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            } 
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT into Users (FirstName, LastName, Email, Password) VALUES('{newUser.register.FirstName}', '{newUser.register.LastName}', '{newUser.register.Email}', '{newUser.register.Password}')";
                DbConnector.Execute(query);
                string queryid = $"SELECT * from Users WHERE (email = '{newUser.register.Email}')";
                var insession = DbConnector.Query(queryid);
                int id = (int)insession[0]["id"]; //grabbing the user id and setting to "id"
                HttpContext.Session.SetInt32("id", id);
                System.Console.WriteLine("this is current user id:", id);
                return RedirectToAction("Success");
            }  
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            
            return View("Success");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
