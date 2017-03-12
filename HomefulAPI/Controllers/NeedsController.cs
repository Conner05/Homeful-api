using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomefulAPI.Controllers
{
    [RoutePrefix("api")]
    public class NeedsController : ApiController
    {
        public NeedsController()
        {
        }

        [HttpPost]
        [Route("needs/{id}")]
        public IHttpActionResult Create([FromBody] Need item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null)
                {
                    return BadRequest();
                }
                item.CreatedOn = DateTime.UtcNow;
                item.UpdatedOn = DateTime.UtcNow;
                _dbContext.Needs.Add(item);

                return CreatedAtRoute("GetNeed", new { id = item.Id }, item);
            }
        }

        [HttpGet]
        [Route("needs")]
        public IHttpActionResult GetAll()
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                return Ok(_dbContext.Needs.ToList());
            }
        }

        [HttpGet]
        [Route("needs/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
                if (need == null)
                {
                    return NotFound();
                }

                return Ok(need);
            }
        }

        [HttpPut]
        [Route("needs/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Need item)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                if (item == null || item.Id != id)
                {
                    return BadRequest();
                }

                var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
                if (need == null)
                {
                    return NotFound();
                }

                //set fields to match item passed in
                need.Name = item.Name;
                need.UpdatedOn = DateTime.UtcNow;
                need.LocationId = item.LocationId;
                need.OccupantId = item.OccupantId;
                need.Quantity = item.Quantity;
                

                _dbContext.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        [Route("needs/{id}")]
        public IHttpActionResult Delete(int id)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
                if (need == null)
                {
                    return NotFound();
                }

                _dbContext.Needs.Remove(need);
                return Ok();
            }
        }
    }
}