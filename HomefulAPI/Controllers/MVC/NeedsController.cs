using HomefulAPI.Models;
using HomefulAPI.ViewModels.Needs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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


        [System.Web.Mvc.Route("locations/{id}/needs/create")]
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

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("locations/{id}/needs/create")]
        public async Task<ActionResult> Create([FromBody] CreateNeedViewModel model)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Need n = new Need()
                {
                    LocationId = model.LocationID,
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Active = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                };


                context.Needs.Add(n);
                await context.SaveChangesAsync();

            }
            //return Redirect(Request.UrlReferrer.ToString());
            return RedirectToAction("Details", "Locations", new { @id = model.LocationID });
        }

        public async Task<ActionResult> Complete(int id)
        {
            int locationID;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Need n = await context.Needs.FindAsync(id);
                locationID = n.LocationId;
                n.Active = false;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Locations", new { @id = locationID });
        }
    }
}