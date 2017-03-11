using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class NeedController : Controller
	{
		[HttpPost]
		public IActionResult Create([FromBody] Need item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_needRepository.Add(item);

			return CreatedAtRoute("GetNeed", new { id = item.Id }, item);
		}

		[HttpGet]
		public IEnumerable<Need> GetAll()
		{
			return _needRepository.GetAll();
		}

		[HttpGet("{id}", Name = "GetNeed")]
		public IActionResult GetById(int id)
		{
			var need = _needRepository.Find(id);
			if (need == null)
			{
				return BadRequest();
			}

			return new ObjectResult(need);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Need item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var need = _needRepository.Find(id);
			if (need == null)
			{
				return NotFound();
			}

			//set fields to match item passed in
			need.Medical = item.Medical;

			_needRepository.Update(need);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var need = _needRepository.Find(id);
			if (need == null)
			{
				return NotFound();
			}

			_needRepository.Remove(id);
			return new NoContentResult();
		}
	}
}
