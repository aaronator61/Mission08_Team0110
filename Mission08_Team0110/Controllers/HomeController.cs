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
            return View(applications);
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = quadContext.Categories.ToList();
            string pageTitle = "Add Task";
            ViewBag.Title = pageTitle;
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
            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = quadContext.Categories.ToList();
            var application = quadContext.responses.Include(x => x.Category)
                                .Single(x => x.taskId == id);

            string pageTitle = "Edit Task";
            ViewBag.Title = pageTitle;
            return View("TaskForm", application);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                quadContext.Update(ar);
                quadContext.SaveChanges();
            }
            

            return RedirectToAction("Quadrants");
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

            return RedirectToAction("Quadrants");
        }

        public IActionResult Completed(int id)
        {
            var completed = quadContext.responses.Single(x => x.taskId == id);
            completed.Completed= true;

            quadContext.Update(completed);
            quadContext.SaveChanges();


            return RedirectToAction("Quadrants");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
