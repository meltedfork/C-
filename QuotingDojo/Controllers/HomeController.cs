using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult AddQuotes(string name, string quote)
        {
           string query = $"INSERT into quoties (name, quote) VALUES('{name}', '{quote}')";
           DbConnector.Execute(query);
           return View("Results"); 
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult ShowQuotes()
        {
            string query = "SELECT * FROM quoties";
            var quote = DbConnector.Query(query);
            
            ViewBag.Quotes = quote;
            return View("Results");
        }
    }
}
