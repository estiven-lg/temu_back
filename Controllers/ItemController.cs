
using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
using temu_back.Models.DTOs;
using temu_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _itemService;

		public ItemController(IItemService itemService)
		{
			_itemService = itemService;
		}


			[HttpGet]
			public async Task<ActionResult<IEnumerable<ItemReadDto>>> GetAll()
			{
				var items = await _itemService.GetAllAsync();
				var dtos = items.Select(i => new ItemReadDto
				{
					Id = i.Id,
					Name = i.Name,
					Price = i.Price,
					CreatedAt = i.CreatedAt,
					UpdatedAt = i.UpdatedAt
				});
				return Ok(dtos);
			}


			[HttpGet("{id}")]
			public async Task<ActionResult<ItemReadDto>> GetById(int id)
			{
				var item = await _itemService.GetByIdAsync(id);
				if (item == null) return NotFound();
				var dto = new ItemReadDto
				{
					Id = item.Id,
					Name = item.Name,
					Price = item.Price,
					CreatedAt = item.CreatedAt,
					UpdatedAt = item.UpdatedAt
				};
				return Ok(dto);
			}


			[HttpPost]
			public async Task<ActionResult<ItemReadDto>> Create(ItemWriteDto dto)
			{
				var item = new Item
				{
					Name = dto.Name,
					Price = dto.Price,
					CreatedAt = DateTime.UtcNow
				};
				var created = await _itemService.AddAsync(item);
				var readDto = new ItemReadDto
				{
					Id = created.Id,
					Name = created.Name,
					Price = created.Price,
					CreatedAt = created.CreatedAt,
					UpdatedAt = created.UpdatedAt
				};
				return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
			}


			[HttpPut("{id}")]
			public async Task<ActionResult<ItemReadDto>> Update(int id, ItemWriteDto dto)
			{
				var existing = await _itemService.GetByIdAsync(id);
				if (existing == null) return NotFound();
				existing.Name = dto.Name;
				existing.Price = dto.Price;
				existing.UpdatedAt = DateTime.UtcNow;
				var updated = await _itemService.UpdateAsync(existing);
				if (updated == null) return NotFound();
				var readDto = new ItemReadDto
				{
					Id = updated.Id,
					Name = updated.Name,
					Price = updated.Price,
					CreatedAt = updated.CreatedAt,
					UpdatedAt = updated.UpdatedAt
				};
				return Ok(readDto);
			}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _itemService.DeleteAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
