using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
using temu_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		public async Task<ActionResult<IEnumerable<Order>>> GetAll()
		{
			var orders = await _orderService.GetAllAsync();
			return Ok(orders);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetById(int id)
		{
			var order = await _orderService.GetByIdAsync(id);
			if (order == null) return NotFound();
			return Ok(order);
		}

		[HttpPost]
		public async Task<ActionResult<Order>> Create(Order order)
		{
			var created = await _orderService.AddAsync(order);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Order>> Update(int id, Order order)
		{
			if (id != order.Id) return BadRequest();
			var updated = await _orderService.UpdateAsync(order);
			if (updated == null) return NotFound();
			return Ok(updated);
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
