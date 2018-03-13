using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;


namespace postNotes.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM notes";
            var note = DbConnector.Query(query);
            ViewBag.Notes = note;
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Add(string title, string content)
        {
           System.Console.WriteLine($"this is in index:");
           string query = $"INSERT into notes (title, content) VALUES('{title}', '{content}')";
           DbConnector.Execute(query);
           return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, string title, string content)
        {
            string query = $"SELECT * FROM notes Where id = {id}";
            var notes = DbConnector.Query(query);
            ViewBag.Notes = notes;
            return View("Edit");
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(string title, string content, int id)
        {
            string query = $"UPDATE notes SET title='{title}', content=\"{content}\" WHERE id='{id}'";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            System.Console.WriteLine($"this is id in delete: {id}");
            string query = $"DELETE FROM notes Where id = {id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }
    }    
}    