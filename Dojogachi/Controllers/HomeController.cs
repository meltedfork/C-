using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojogachi.Controllers
{
    public class Dojochichi
    {
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
    
        public Dojochichi()
        {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }   

        public void play()
        {
            Random rand = new Random();
            int fun = rand.Next(5,10);
            happiness+= fun;
            energy-= 5;
        }
    }    
    
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
