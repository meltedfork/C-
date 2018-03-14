using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, int age, string email, string password)
        {
            var user = new User
            {
                firstname = firstname,
                lastname = lastname,
                age = age,
                email = email,
                password = password
            };

            if(TryValidateModel(user) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View("Errors");
            }

            return View("Success");
        }
        
        // [HttpGet]
        // [Route("success")]
        // public IActionResult Success()
        // {
        //     return View();
        // }

    }
}
