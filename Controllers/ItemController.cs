using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
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
		public async Task<ActionResult<IEnumerable<Item>>> GetAll()
		{
			var items = await _itemService.GetAllAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Item>> GetById(int id)
		{
			var item = await _itemService.GetByIdAsync(id);
			if (item == null) return NotFound();
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<Item>> Create(Item item)
		{
			var created = await _itemService.AddAsync(item);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Item>> Update(int id, Item item)
		{
			if (id != item.Id) return BadRequest();
			var updated = await _itemService.UpdateAsync(item);
			if (updated == null) return NotFound();
			return Ok(updated);
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
