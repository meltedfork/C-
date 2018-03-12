using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace passcode.Controllers
{
    public class PasscodeController : Controller
    {
        public static int count;
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string RandomCode = "";
            Random rand = new Random();
            for (int i = 0; i < 14; i++)
            {
                RandomCode += chars[rand.Next(chars.Length)];
            }
            count++;
            ViewBag.count = count;
            ViewBag.RandomCode = RandomCode;
            return View();
        }
        
        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            return RedirectToAction("Index");
        } 
    }
}
