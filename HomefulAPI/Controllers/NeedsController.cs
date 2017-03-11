using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomefulAPI.Controllers
{
    public class NeedsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public NeedsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("/locations/{id}")]
        public IHttpActionResult Create([FromBody] Need item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _dbContext.Needs.Add(item);

            return CreatedAtRoute("GetNeed", new { id = item.Id }, item);
        }

        [HttpGet]
        [Route("/locations")]
        public IHttpActionResult GetAll()
        {
            return Ok(_dbContext.Needs.ToList());
        }


        [Route("/locations/{id}")]
        public IHttpActionResult Retrieve(int id)
        {
            var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
            if (need == null)
            {
                return BadRequest();
            }

            return Ok(need);
        }

        [HttpPut]
        [Route("/locations/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Need item)
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
            need.UpdatedOn = DateTime.Now;

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("/locations/{id}")]
        public IHttpActionResult Delete(int id)
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