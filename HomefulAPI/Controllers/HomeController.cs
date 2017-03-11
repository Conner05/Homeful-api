using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomefulAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Home Page";
                using (ApplicationDbContext c = new ApplicationDbContext())
                {
                    var locations = c.Locations.ToList();
                    ViewBag.Count = locations.Count();

                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }

        public ActionResult Create()
        {
            Location l = new Location()
            {
                Name = "Test",
                Longitude = 0,
                Latitude = 1
            };

            using (ApplicationDbContext c = new ApplicationDbContext())
            {
                c.Locations.Add(l);
                c.SaveChangesAsync();
            }

            return Redirect("/");
        }
    }
}
