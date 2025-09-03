using Microsoft.AspNetCore.Mvc;
using temu_back.Models;
using temu_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderDetailController : ControllerBase
	{
		private readonly IOrderDetailService _orderDetailService;

		public OrderDetailController(IOrderDetailService orderDetailService)
		{
			_orderDetailService = orderDetailService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAll()
		{
			var details = await _orderDetailService.GetAllAsync();
			return Ok(details);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderDetail>> GetById(int id)
		{
			var detail = await _orderDetailService.GetByIdAsync(id);
			if (detail == null) return NotFound();
			return Ok(detail);
		}

		[HttpPost]
		public async Task<ActionResult<OrderDetail>> Create(OrderDetail orderDetail)
		{
			var created = await _orderDetailService.AddAsync(orderDetail);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<OrderDetail>> Update(int id, OrderDetail orderDetail)
		{
			if (id != orderDetail.Id) return BadRequest();
			var updated = await _orderDetailService.UpdateAsync(orderDetail);
			if (updated == null) return NotFound();
			return Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _orderDetailService.DeleteAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
