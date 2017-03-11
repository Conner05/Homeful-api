using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    public class OccupantController : Controller
    {
		[HttpPost]
		public IActionResult Create([FromBody] Occupant item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_occupantRepository.Add(item);

			return CreatedAtRoute("GetOccupant", new { id = item.Id }, item);
		}

		[HttpGet]
		public IEnumerable<Occupant> GetAll()
		{
			return _occupantRepository.GetAll();
		}

		[HttpGet("{id}", Name = "GetOccupant")]
		public IActionResult GetById(int id)
		{
			var occupant = _occupantRepository.Find(id);
			if (occupant == null)
			{
				return BadRequest();
			}

			return new ObjectResult(occupant);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Occupant item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var occupant = _occupantRepository.Find(id);
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

			_occupantRepository.Update(occupant);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var need = _occupantRepository.Find(id);
			if (need == null)
			{
				return NotFound();
			}

			_occupantRepository.Remove(id);
			return new NoContentResult();
		}        
    }
}
