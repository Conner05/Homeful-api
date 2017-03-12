using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HomefulAPI.Controllers
{
    public class PackListController : Controller
    {
        public ViewResult Index()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var camps = context.Locations.Include(l => l.Needs).ToList();

                return View(camps);
            }
        }
    }
}