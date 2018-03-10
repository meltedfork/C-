using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("{firstName}/{lastName}/{age}/{favColor}")]
        public JsonResult DisplayInt(string firstName, string lastName, int age, string favColor)
        {
            var AnonObject = new {
                                 FirstName = firstName,
                                 LastName = lastName,
                                 Age = age,
                                 FavColor = favColor
                             };
            return Json(AnonObject);
        }

        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }

        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name)
        // {
        //     // Method body
        //     return "This param: {Name}";
        // }
    }
}
