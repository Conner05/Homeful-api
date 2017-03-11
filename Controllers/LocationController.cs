using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LocationController : Controller
    {
		[HttpPost]
		public IActionResult Create([FromBody] Location item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_locationRepository.Add(item);

			return CreatedAtRoute("GetLocation", new { id = item.Id }, item);
		}

		[HttpGet]
		public IEnumerable<Location> GetAll()
		{
			return _locationRepository.GetAll();
		}

		[HttpGet("{id}", Name = "GetLocation")]
		public IActionResult GetById(int id)
		{
			var need = _locationRepository.Find(id);
			if (need == null)
			{
				return BadRequest();
			}

			return new ObjectResult(need);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Location item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var location = _locationRepository.Find(id);
			if (location == null)
			{
				return NotFound();
			}

			//set fields to match item passed in
            location.Name = item.Name;
            location.Latitude = item.Latitude;
            location.Longitude = item.Longitude;
            location.Notes = item.Notes;

			_locationRepository.Update(location);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var need = _locationRepository.Find(id);
			if (need == null)
			{
				return NotFound();
			}

			_locationRepository.Remove(id);
			return new NoContentResult();
		}
    }
}
