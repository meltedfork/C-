using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace timeDisplay.Controllers
{
    public class TimeController : Controller
    {
        // A GET method
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
