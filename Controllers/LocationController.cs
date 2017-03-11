using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class LocationController : Controller
    {
		private ApplicationDbContext _dbContext;

		public LocationController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}		

		[HttpPost]
		public IActionResult Create([FromBody] Location item)
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
		public IEnumerable<Location> GetAll()
		{
			return _dbContext.Locations.ToList();
		}

		[HttpGet("{id}", Name = "GetLocation")]
		public IActionResult GetById(int id)
		{
			var location = _dbContext.Locations.Find(id);
			if (location == null)
			{
				return BadRequest();
			}

			return new ObjectResult(location);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Location item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var location = _dbContext.Locations.Find(id);
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

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var location = _dbContext.Locations.Find(id);
			if (location == null)
			{
				return NotFound();
			}

			_dbContext.Remove(location);
			
			return new NoContentResult();
		}
    }
}
