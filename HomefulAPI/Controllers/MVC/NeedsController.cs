using HomefulAPI.Models;
using HomefulAPI.ViewModels.Needs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomefulAPI.Controllers.MVC
{
    public class NeedsController : Controller
    {
        // GET: Needs
        public ActionResult Index()
        {
            return View();
        }


        [Route("locations/{id}/needs/create")]
        public async Task<ActionResult> Create(int id)
        {
            CreateNeedViewModel model = new CreateNeedViewModel();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Location l = (await context.Locations.FindAsync(id));
                model.Location = l;
                model.LocationID = l.Id;
            }


            return View(model);
        }
    }
}