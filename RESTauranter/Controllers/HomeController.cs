using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("addReview")]
        public IActionResult AddReview(Review newReview)
        {
           if(ModelState.IsValid)
           {
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("AllReviews");
           }
           else
           {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
           }
            
        }


        [HttpGet]
        [Route("allReviews")]
        public IActionResult AllReviews()
        {
            List<Review> allReviews = _context.Reviews.OrderByDescending(r => r.VisitDate).ToList();
            //System.Console.WriteLine(allReviews);
            ViewBag.reviews = allReviews;
            return View("AllReviews");
        }
    }
}
