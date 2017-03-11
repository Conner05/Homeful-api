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
        private ApplicationDbContext _dbContext;

        public LocationsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("/locations/{id}")]
        public IHttpActionResult Create([FromBody] Location item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _dbContext.Locations.Add(item);
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetLocation", new { id = item.Id }, item);
        }

        [HttpGet]
        [Route("/locations")]
        public IHttpActionResult GetAll()
        {
            return Ok(_dbContext.Locations.ToList());
        }

        [HttpGet]
        [Route("/locations/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);
            if (location == null)
            {
                return BadRequest();
            }

            return Ok(location);
        }

        [HttpPut]
        [Route("/locations/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Location item)
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

        [HttpDelete]
        [Route("/locations/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            _dbContext.Locations.Remove(location);

            return Ok();
        }

        [Route("/locations/{id}/occupants")]
        public ICollection<Occupant> GetOccupantsAtLocation(int id)
        {
            var location = _dbContext.Locations.Include(x => x.Occupants).FirstOrDefault(x => x.Id == id);

            return location?.Occupants ?? null;
        }

        [Route("/locations/{id}/needs")]
        public ICollection<Need> GetNeedsAtLocation(int id)
        {
            var location = _dbContext.Locations.Include(x => x.Needs).FirstOrDefault(x => x.Id == id);

            return location?.Needs ?? null;
        }
    }
}