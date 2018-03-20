using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Ninjas = ninjaFactory.FindAll();
            ViewBag.Dojos = dojoFactory.FindAll();
            
            return View("NinjaAll");
        }

        [HttpPost]
        [Route("AddNinja")]
        public IActionResult AddNinja(Ninja newNinja)
        {
            if(ModelState.IsValid)
            {
                ninjaFactory.Add(newNinja);
                return RedirectToAction("Index", "Ninja");
            }
            else
            {
                ViewBag.Errors = ModelState.Values; // NEED to add errors to View
                return RedirectToAction("Index", "Ninja");
            }    
        }

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult FindById(int id)
        {
            ViewBag.Ninjas = ninjaFactory.FindById(id);
            ViewBag.Dojos = dojoFactory.FindById(id);
            return View("NinjaOne");
        }

    }
}
