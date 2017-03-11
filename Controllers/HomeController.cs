using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
/*            Location l = new Location() 
            {
                Name = "Test",
                Latitude = 0,
                Longitude = 0

            };

            _dbcontext.Locations.Add(l);
            _dbcontext.SaveChanges();*/
            
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
