// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using WebApplication.Models;
// using WebApplication.Data;
// using System.Linq;

// namespace WebApplication.Controllers
// {
// 	[RouteAttribute("api/needs")]
// 	public class NeedController : Controller
// 	{
// 		private ApplicationDbContext _dbContext;

// 		public NeedController(ApplicationDbContext dbContext)
// 		{
// 				_dbContext = dbContext;
// 		}		

// 		[HttpPost]
// 		public IActionResult Create([FromBody] Need item)
// 		{
// 			if (item == null)
// 			{
// 				return BadRequest();
// 			}

// 			_dbContext.Needs.Add(item);

// 			return CreatedAtRoute("GetNeed", new { id = item.Id }, item);
// 		}

// 		[HttpGet]
// 		public IEnumerable<Need> GetAll()
// 		{
// 			return _dbContext.Needs.ToList();
// 		}

// 		[HttpGet("{id}", Name = "GetNeed")]
// 		public IActionResult GetById(int id)
// 		{
// 			var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
// 			if (need == null)
// 			{
// 				return BadRequest();
// 			}

// 			return new ObjectResult(need);
// 		}

// 		[HttpPut("{id}")]
// 		public IActionResult Update(int id, [FromBody] Need item)
// 		{
// 			if (item == null || item.Id != id)
// 			{
// 				return BadRequest();
// 			}

// 			var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
// 			if (need == null)
// 			{
// 				return NotFound();
// 			}

// 			//set fields to match item passed in
// 			need.Name = item.Name;
// 			need.UpdatedOn = DateTime.Now;

// 			_dbContext.SaveChanges();

// 			return new NoContentResult();
// 		}

// 		[HttpDelete("{id}")]
// 		public IActionResult Delete(int id)
// 		{
// 			var need = _dbContext.Needs.SingleOrDefault(x => x.Id == id);
// 			if (need == null)
// 			{
// 				return NotFound();
// 			}

// 			_dbContext.Needs.Remove(need);
// 			return new NoContentResult();
// 		}
// 	}
// }
