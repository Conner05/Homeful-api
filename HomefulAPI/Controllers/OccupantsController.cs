using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomefulAPI.Controllers
{
    public class OccupantsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public OccupantsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("/occupants/{id}")]
        public IHttpActionResult Create([FromBody] Occupant item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _dbContext.Occupants.Add(item);

            return CreatedAtRoute("GetOccupant", new { id = item.Id }, item);
        }

        [HttpGet]
        [Route("/occupants")]
        public IHttpActionResult GetAll()
        {
            return Ok(_dbContext.Occupants.ToList());
        }

        [HttpGet]
        [Route("/occupants/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            var occupant = _dbContext.Occupants.FirstOrDefault(x => x.Id == id);
            if (occupant == null)
            {
                return BadRequest();
            }

            return Ok(occupant);
        }

        [HttpPut]
        [Route("/occupants/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Occupant item)
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
            occupant.UpdatedOn = DateTime.Now;
            occupant.Active = item.Active;
            //TODO:  What about changing an occupant's location

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("/occupants/{id}")]
        public IHttpActionResult Delete(int id)
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