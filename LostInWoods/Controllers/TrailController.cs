using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInWoods.Models;
using LostInWoods.Factory;

namespace LostInWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;

        public TrailController()
        {
            trailFactory = new TrailFactory();
        }
        

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
              ViewBag.Trail = trailFactory.FindAll();
              return View();
        }

        [HttpGet]
        [Route("createTrail")]
        public IActionResult createTrail()
        {
            return View("AddTrail");
        }

        [HttpPost]
        [Route("addTrail")]
        public IActionResult AddTrail(Trail newTrail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(newTrail);
                return RedirectToAction("Index");
            }
            ViewBag.Errors = ModelState.Values; // NEED to add errors to View
            return View();
            
        }

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult ViewTrail(int id)
        {
            ViewBag.Trail = trailFactory.FindByID(id);
            return View();
        }
    }
}
