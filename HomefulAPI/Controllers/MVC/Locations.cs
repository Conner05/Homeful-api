using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HomefulAPI.Controllers
{
    public class Locations : Controller
    {
        public ViewResult All()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var locations = context.Locations.ToList();

                return View(locations);
            }
        }
    }
}