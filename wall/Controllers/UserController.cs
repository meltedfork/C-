using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
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

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(User user)
        {
            if (ModelState.IsValid)
            {
                string emailQuery = $"SELECT * from users WHERE (email= '{user.login.email}' AND password= '{user.login.password}')";
                var email = DbConnector.Query(emailQuery);
                if (email.Count == 1)
                {
                    string queryid = $"SELECT * from users WHERE (email = '{user.login.email}')";
                    var insession = DbConnector.Query(queryid);

                    //grabbing the user id and setting to "id"
                    int id = (int)insession[0]["id"];
                    System.Console.WriteLine($"============> this is current user id: {id}");
                    HttpContext.Session.SetInt32("id", id);

                    //grabbing the first name and setting to "firstname"
                    string firstname = (string)insession[0]["firstname"];
                    System.Console.WriteLine($"============> this is current firstname: {firstname}");
                    HttpContext.Session.SetString("firstname", firstname);

                    //HttpContext.Session.SetString("username", user.register.firstname);
                    return RedirectToAction("wall");
                }
                else 
                {
                    //ViewBag.errors 
                    return View("Wall");
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
                string query = $"INSERT into users (firstname, lastname, email, password) VALUES('{newUser.register.firstname}', '{newUser.register.lastname}', '{newUser.register.email}', '{newUser.register.password}')";
                DbConnector.Execute(query);
                
                string queryid = $"SELECT * from users WHERE (email = '{newUser.register.email}')";
                var insession = DbConnector.Query(queryid);

                //grabbing the user id and setting to "id"
                int id = (int)insession[0]["id"];
                System.Console.WriteLine($"=======> this is current user id: {id}");
                HttpContext.Session.SetInt32("id", id);

                //grabbing the first name and setting to "firstname"
                string firstname = (string)insession[0]["firstname"];
                System.Console.WriteLine($"========> this is current firstname: {firstname}");
                HttpContext.Session.SetString("firstname", firstname);
                

                return RedirectToAction("wall");
            }  
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        { 
            string firstname = HttpContext.Session.GetString("firstname");
            if(firstname == null)  // this confirms if in session with a logged in user
            {
                return RedirectToAction("index");
            }
            
            ViewBag.Name = firstname;

            string query = $"SELECT messages.message, users.firstname, users.lastname, messages.created_at, messages.id FROM messages INNER JOIN users ON messages.users_id=users.id ORDER BY messages.created_at DESC";
            var messages = DbConnector.Query(query);
            ViewBag.Messages = messages;

            string query2 = $"SELECT comments.comment, messages.message, users.firstname, users.lastname, comments.created_at, comments.messages_id FROM comments LEFT JOIN messages ON messages.id=comments.messages_id INNER JOIN users ON comments.users_id=users.id ORDER BY comments.created_at DESC";
            var comments = DbConnector.Query(query2);
            ViewBag.Comments = comments;
            return View("Wall");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(string message)
        {
            
            int? userid = HttpContext.Session.GetInt32("id");
            //System.Console.WriteLine("the userid is ",id);
            System.Console.WriteLine($"========> in create method user id {userid}");

            // put conditional here to make sure message is not empty
            string query = $"INSERT INTO messages (message, users_id) VALUES('{message}', {userid})";
            System.Console.WriteLine(query);
            DbConnector.Execute(query);
            return RedirectToAction("wall");
        }

        [HttpPost]
        [Route("makeComment")]
        public IActionResult CommentMaker(string comment, int messageid)
        {
            int? userid = HttpContext.Session.GetInt32("id");
            string query = $"INSERT INTO comments (comment, messages_id, users_id) VALUES('{comment}', {messageid}, {userid})";
            System.Console.WriteLine($"========> in makeComment method user id {userid}");

            System.Console.WriteLine(query);
            DbConnector.Execute(query);
            return RedirectToAction("wall");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}