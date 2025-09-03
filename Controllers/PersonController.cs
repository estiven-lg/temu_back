using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
using temu_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Person>>> GetAll()
		{
			var persons = await _personService.GetAllAsync();
			return Ok(persons);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Person>> GetById(int id)
		{
			var person = await _personService.GetByIdAsync(id);
			if (person == null) return NotFound();
			return Ok(person);
		}

		[HttpPost]
		public async Task<ActionResult<Person>> Create(Person person)
		{
			var created = await _personService.AddAsync(person);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Person>> Update(int id, Person person)
		{
			if (id != person.Id) return BadRequest();
			var updated = await _personService.UpdateAsync(person);
			if (updated == null) return NotFound();
			return Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _personService.DeleteAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
