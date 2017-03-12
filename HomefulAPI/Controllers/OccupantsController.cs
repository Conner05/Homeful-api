using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomefulAPI.Controllers
{
    [RoutePrefix("api")]
    public class OccupantsController : ApiController
    {
        
        public OccupantsController()
        {
        }

        [HttpPost]
        [Route("occupants/{id}")]
        public IHttpActionResult Create([FromBody] Occupant item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null)
                {
                    return BadRequest();
                }

                item.CreatedOn = DateTime.UtcNow;

                _dbContext.Occupants.Add(item);

                return CreatedAtRoute("GetOccupant", new { id = item.Id }, item);
            }
        }

        [HttpGet]
        [Route("occupants")]
        public IHttpActionResult GetAll()
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                return Ok(_dbContext.Occupants.ToList());
            }
        }

        [HttpGet]
        [Route("occupants/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var occupant = _dbContext.Occupants.FirstOrDefault(x => x.Id == id);
                if (occupant == null)
                {
                    return NotFound();
                }

                return Ok(occupant);
            }
        }

        [HttpPut]
        [Route("occupants/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Occupant item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null || item.Id != id)
                {
                    return BadRequest();
                }

                var occupant = _dbContext.Occupants.FirstOrDefault(x => x.Id == id);
                if (occupant == null)
                {
                    return NotFound();
                }

                //set fields to match item passed in
                occupant.Name = item.Name;
                occupant.Phone = item.Phone;
                occupant.Email = item.Email;
                occupant.Birthdate = item.Birthdate;
                occupant.UpdatedOn = DateTime.UtcNow;
                occupant.LocationId = item.LocationId;
                occupant.Active = item.Active;

                _dbContext.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        [Route("occupants/{id}")]
        public IHttpActionResult Delete(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var occupant = _dbContext.Occupants.FirstOrDefault(x => x.Id == id);
                if (occupant == null)
                {
                    return NotFound();
                }

                _dbContext.Occupants.Remove(occupant);
                return Ok();
            }
        }
    }
}