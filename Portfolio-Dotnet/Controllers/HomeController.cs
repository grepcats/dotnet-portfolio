using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Projects()
        {
            ViewData["Message"] = "Your porfolio page.";
            var allRepos = Repo.GetRepos();
            return View(allRepos);
        }

        public IActionResult Resume()
        {
            ViewData["Message"] = "Your resume page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       
    }
}
