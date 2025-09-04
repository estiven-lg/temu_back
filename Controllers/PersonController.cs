
using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
using temu_back.Models.DTOs;
using temu_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
			public async Task<ActionResult<IEnumerable<PersonReadDto>>> GetAll()
			{
				var persons = await _personService.GetAllAsync();
				var dtos = persons.Select(p => new PersonReadDto
				{
					Id = p.Id,
					FirstName = p.FirstName,
					LastName = p.LastName,
					Email = p.Email,
					CreatedAt = p.CreatedAt,
					UpdatedAt = p.UpdatedAt
				});
				return Ok(dtos);
			}


			[HttpGet("{id}")]
			public async Task<ActionResult<PersonReadDto>> GetById(int id)
			{
				var person = await _personService.GetByIdAsync(id);
				if (person == null) return NotFound();
				var dto = new PersonReadDto
				{
					Id = person.Id,
					FirstName = person.FirstName,
					LastName = person.LastName,
					Email = person.Email,
					CreatedAt = person.CreatedAt,
					UpdatedAt = person.UpdatedAt
				};
				return Ok(dto);
			}


			[HttpPost]
			public async Task<ActionResult<PersonReadDto>> Create(PersonWriteDto dto)
			{
				var person = new Person
				{
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					Email = dto.Email,
					CreatedAt = DateTime.UtcNow
				};
				var created = await _personService.AddAsync(person);
				var readDto = new PersonReadDto
				{
					Id = created.Id,
					FirstName = created.FirstName,
					LastName = created.LastName,
					Email = created.Email,
					CreatedAt = created.CreatedAt,
					UpdatedAt = created.UpdatedAt
				};
				return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
			}


			[HttpPut("{id}")]
			public async Task<ActionResult<PersonReadDto>> Update(int id, PersonWriteDto dto)
			{
				var existing = await _personService.GetByIdAsync(id);
				if (existing == null) return NotFound();
				existing.FirstName = dto.FirstName;
				existing.LastName = dto.LastName;
				existing.Email = dto.Email;
				existing.UpdatedAt = DateTime.UtcNow;
				var updated = await _personService.UpdateAsync(existing);
				if (updated == null) return NotFound();
				var readDto = new PersonReadDto
				{
					Id = updated.Id,
					FirstName = updated.FirstName,
					LastName = updated.LastName,
					Email = updated.Email,
					CreatedAt = updated.CreatedAt,
					UpdatedAt = updated.UpdatedAt
				};
				return Ok(readDto);
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
