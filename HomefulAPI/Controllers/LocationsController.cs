using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
namespace HomefulAPI.Controllers
{
    [RoutePrefix("api")]
    public class LocationsController : ApiController
    {

        public LocationsController()
        {
            
        }


        [HttpPost]
        [Route("locations")]
        public IHttpActionResult Create([FromBody] Location item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null)
                {
                    return BadRequest();
                }

                _dbContext.Locations.Add(item);
                _dbContext.SaveChanges();

                return CreatedAtRoute("GetLocation", new { id = item.Id }, item);
            }
        }

        [HttpGet]
        [Route("locations")]
        public IHttpActionResult GetAll()
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                try
                {
                    var l = (_dbContext.Locations.ToList());
                    return Ok(l);

                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet]
        [Route("locations/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var location = _dbContext.Locations
                    .Include(x => x.Needs)
                    .Include(x => x.Occupants)
                    .FirstOrDefault(x => x.Id == id);

                if (location == null)
                {
                    return BadRequest();
                }

                return Ok(location);
            }
        }

        [HttpPut]
        [Route("locations/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Location item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null || item.Id != id)
                {
                    return BadRequest();
                }

                var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);
                if (location == null)
                {
                    return NotFound();
                }

                //set fields to match item passed in
                location.Name = item.Name;
                location.Latitude = item.Latitude;
                location.Longitude = item.Longitude;
                location.Notes = item.Notes;

                _dbContext.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        [Route("locations/{id}")]
        public IHttpActionResult Delete(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);
                if (location == null)
                {
                    return NotFound();
                }

                _dbContext.Locations.Remove(location);

                return Ok();
            }
        }

        [Route("locations/{id}/occupants")]
        public ICollection<Occupant> GetOccupantsAtLocation(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var location = _dbContext.Locations.Include(x => x.Occupants).FirstOrDefault(x => x.Id == id);

                return location?.Occupants ?? null;
            }
        }

        [Route("locations/{id}/needs")]
        public ICollection<Need> GetNeedsAtLocation(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var location = _dbContext.Locations.Include(x => x.Needs).FirstOrDefault(x => x.Id == id);

                return location?.Needs ?? null;
            }
        }
    }
}