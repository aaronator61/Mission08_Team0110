using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_Team0110.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team0110.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TimeManagement quadContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TimeManagement someName)
        {
            _logger = logger;
            quadContext = someName;
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var applications = quadContext.responses.Include(x => x.Category)
                               .ToList();
            return View();
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = quadContext.Categories.ToList();
            return View(new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult TaskForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                quadContext.Add(ar);
                quadContext.SaveChanges();
            }

            ViewBag.Categories = quadContext.Categories.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = quadContext.responses.ToList();
            var application = quadContext.responses.Include(x => x.Category)
                                .Single(x => x.taskId == id);
            return View("TaskForm");
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                quadContext.Update(ar);
                quadContext.SaveChanges();
            }
            

            return RedirectToAction("Quadrant");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = quadContext.responses.Single(x => x.taskId == id);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            quadContext.responses.Remove(ar);
            quadContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
