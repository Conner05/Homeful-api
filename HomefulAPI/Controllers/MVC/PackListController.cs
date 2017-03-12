using HomefulAPI.Models;
using HomefulAPI.ViewModels.PckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HomefulAPI.Controllers.MVC
{
    public class PackListController : Controller
    {
        [System.Web.Http.HttpGet]
        public ActionResult ChooseCamps()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var locations = context.Locations.Select(l => new ChooseCampsViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Selected = false
                }).ToList();
                return View(locations);
            }

        }

        [System.Web.Http.HttpPost]
        public ActionResult ChooseCamps([FromBody] IEnumerable<ChooseCampsViewModel> model, int id)
        {
            return Redirect("/");
        }
    }

}