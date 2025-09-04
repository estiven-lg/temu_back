
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
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}


			[HttpGet]
			public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
			{
				var orders = await _orderService.GetAllAsync();
				var dtos = orders.Select(o => new OrderReadDto
				{
					Id = o.Id,
					PersonId = o.PersonId,
					Number = o.Number,
					CreatedAt = o.CreatedAt,
					UpdatedAt = o.UpdatedAt
				});
				return Ok(dtos);
			}


			[HttpGet("{id}")]
			public async Task<ActionResult<OrderReadDto>> GetById(int id)
			{
				var order = await _orderService.GetByIdAsync(id);
				if (order == null) return NotFound();
				var dto = new OrderReadDto
				{
					Id = order.Id,
					PersonId = order.PersonId,
					Number = order.Number,
					CreatedAt = order.CreatedAt,
					UpdatedAt = order.UpdatedAt
				};
				return Ok(dto);
			}


			[HttpPost]
			public async Task<ActionResult<OrderReadDto>> Create(OrderWriteDto dto)
			{
				var order = new Order
				{
					PersonId = dto.PersonId,
					Number = dto.Number,
					CreatedAt = DateTime.UtcNow
				};
				var created = await _orderService.AddAsync(order);
				var readDto = new OrderReadDto
				{
					Id = created.Id,
					PersonId = created.PersonId,
					Number = created.Number,
					CreatedAt = created.CreatedAt,
					UpdatedAt = created.UpdatedAt
				};
				return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
			}


			[HttpPut("{id}")]
			public async Task<ActionResult<OrderReadDto>> Update(int id, OrderWriteDto dto)
			{
				var existing = await _orderService.GetByIdAsync(id);
				if (existing == null) return NotFound();
				existing.PersonId = dto.PersonId;
				existing.Number = dto.Number;
				existing.UpdatedAt = DateTime.UtcNow;
				var updated = await _orderService.UpdateAsync(existing);
				if (updated == null) return NotFound();
				var readDto = new OrderReadDto
				{
					Id = updated.Id,
					PersonId = updated.PersonId,
					Number = updated.Number,
					CreatedAt = updated.CreatedAt,
					UpdatedAt = updated.UpdatedAt
				};
				return Ok(readDto);
			}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _orderService.DeleteAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
