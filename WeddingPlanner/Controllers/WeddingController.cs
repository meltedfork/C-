using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _context;

        public WeddingController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? currentId = HttpContext.Session.GetInt32("inSession");
            if (currentId == null)
            {
                TempData["LogError"] = "Log in to view your events";
                return RedirectToAction("Index", "Home");
            }
            else
            
            {
                System.Console.WriteLine("================ currentid in Dashboard", (int)currentId);
                
                List<Guest> guests = _context.Guests.Include(u => u.Wedding).ThenInclude(u => u.User).ToList();
                List<Wedding> weddings = _context.Weddings.Include(w => w.Guests).OrderBy(w => w.WeddingDate).ToList();
                System.Console.WriteLine("==================== List of Wedding", weddings);
                ViewBag.Weddings = weddings;
                ViewBag.UserId = currentId;
                return View("Dashboard");
            }  
        }
        
        [HttpGet]
        [Route("newWedding")]
        public IActionResult NewWedding()
        {
            return View("Wedding");
        }

        [HttpPost]
        [Route("createWedding")]
        public IActionResult CreateWedding(Wedding wedding)
        {
            int? currentId = HttpContext.Session.GetInt32("inSession");
            System.Console.WriteLine("================ currentid in CreateWedding", currentId);
            
            if (currentId == null)
            {
                TempData["LogError"] = "Log in to view your events";
                return RedirectToAction("Index", "Home");
            }
            else
            System.Console.WriteLine("================ currentid in CreateWedding", currentId);
            
            {
                if(ModelState.IsValid)
                {
                    Wedding newWedding = new Wedding
                    {
                        UserId = (int)currentId,
                        WedOneName = wedding.WedOneName,
                        WedTwoName = wedding.WedTwoName,
                        WeddingDate = wedding.WeddingDate
                    };

                    _context.Add(newWedding);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return View("Wedding", wedding);
                }
            }
        }
        
        [HttpGet]
        [Route("showWedding/{WeddingId}")]
        public IActionResult ShowWedding(int WeddingId)
        {
            System.Console.WriteLine("================ currentid in ShowWedding", HttpContext.Session.GetInt32(key: "inSession"));
           
            Wedding showOne = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
            ViewBag.ThisOne = showOne;
            List<Wedding> guests = _context.Weddings.Where(w => w.WeddingId == WeddingId).Include(g => g.Guests).ThenInclude(u => u.User).ToList();
            ViewBag.AllGuests = guests;
            return View("ShowWedding");
        }


        [HttpGet]
        [Route("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
           Wedding byegirl =  _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
           _context.Remove(byegirl);
           _context.SaveChanges();
           return RedirectToAction("Dashboard");
        }


        [HttpGet]
        [Route("rsvp/{WeddingId}")]
        public IActionResult RSVP(int GuestId, int WeddingId)
        {
            int? currentId = HttpContext.Session.GetInt32("inSession");
            Guest RSVP = new Guest
            {
                UserId = (int)currentId,
                WeddingId = WeddingId
            };
            Guest existingGuest = _context.Guests.SingleOrDefault(u => u.UserId == (int)currentId && u.WeddingId == WeddingId);
            System.Console.WriteLine("================ currentid in RSVP", currentId);
            
            if(existingGuest == null)
            {
                _context.Guests.Add(RSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        [Route("unrsvp/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId)
        {
            System.Console.WriteLine("================ WeddingId in unRSVP", WeddingId);
             
            int? currentId = HttpContext.Session.GetInt32("inSession");
            Guest notAttending = _context.Guests.Where(w => w.WeddingId == WeddingId).Where(u =>u.UserId == currentId).SingleOrDefault();
            _context.Remove(notAttending);
            _context.SaveChanges();
            return RedirectToAction("DashBoard");
        }
    }

}        