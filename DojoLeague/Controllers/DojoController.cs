using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;

        public DojoController()
        {
            dojoFactory = new DojoFactory();
        }
        

        [HttpGet]
        [Route("Dojos")]
        public IActionResult Dojos()
        {
            ViewBag.Dojos = dojoFactory.FindAll();
            return View("DojoAll");
        }

        [HttpPost]
        [Route("AddDojo")]
        public IActionResult AddDojo(Dojo newDojo)
        {
            if(ModelState.IsValid)
            {
                dojoFactory.Add(newDojo);
                return RedirectToAction("Dojos");
            }
            else
            {
                ViewBag.Errors = ModelState.Values; // NEED to add errors to View
                return RedirectToAction("Dojos");
            }    
        }
    }
}
