
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
	public class OrderDetailController : ControllerBase
	{
		private readonly IOrderDetailService _orderDetailService;

		public OrderDetailController(IOrderDetailService orderDetailService)
		{
			_orderDetailService = orderDetailService;
		}


			[HttpGet]
			public async Task<ActionResult<IEnumerable<OrderDetailReadDto>>> GetAll()
			{
				var details = await _orderDetailService.GetAllAsync();
				var dtos = details.Select(d => new OrderDetailReadDto
				{
					Id = d.Id,
					OrderId = d.OrderId,
					ItemId = d.ItemId,
					Quantity = d.Quantity,
					Price = d.Price,
					CreatedAt = d.CreatedAt,
					UpdatedAt = d.UpdatedAt
				});
				return Ok(dtos);
			}


			[HttpGet("{id}")]
			public async Task<ActionResult<OrderDetailReadDto>> GetById(int id)
			{
				var detail = await _orderDetailService.GetByIdAsync(id);
				if (detail == null) return NotFound();
				var dto = new OrderDetailReadDto
				{
					Id = detail.Id,
					OrderId = detail.OrderId,
					ItemId = detail.ItemId,
					Quantity = detail.Quantity,
					Price = detail.Price,
					Total = detail.Total,
					CreatedAt = detail.CreatedAt,
					UpdatedAt = detail.UpdatedAt
				};
				return Ok(dto);
			}


			[HttpPost]
			public async Task<ActionResult<OrderDetailReadDto>> Create(OrderDetailWriteDto dto)
			{
				var orderDetail = new OrderDetail
				{
					OrderId = dto.OrderId,
					ItemId = dto.ItemId,
					Quantity = dto.Quantity,
					Price = dto.Price,
					Total = dto.Quantity * dto.Price,
					CreatedAt = DateTime.UtcNow
				};
				var created = await _orderDetailService.AddAsync(orderDetail);
				var readDto = new OrderDetailReadDto
				{
					Id = created.Id,
					OrderId = created.OrderId,
					ItemId = created.ItemId,
					Quantity = created.Quantity,
					Price = created.Price,
					Total = created.Total,
					CreatedAt = created.CreatedAt,
					UpdatedAt = created.UpdatedAt
				};
				return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
			}


			[HttpPut("{id}")]
			public async Task<ActionResult<OrderDetailReadDto>> Update(int id, OrderDetailWriteDto dto)
			{
				var existing = await _orderDetailService.GetByIdAsync(id);
				if (existing == null) return NotFound();
				existing.OrderId = dto.OrderId;
				existing.ItemId = dto.ItemId;
				existing.Quantity = dto.Quantity;
				existing.Price = dto.Price;
				existing.Total = dto.Total;
				existing.UpdatedAt = DateTime.UtcNow;
				var updated = await _orderDetailService.UpdateAsync(existing);
				if (updated == null) return NotFound();
				var readDto = new OrderDetailReadDto
				{
					Id = updated.Id,
					OrderId = updated.OrderId,
					ItemId = updated.ItemId,
					Quantity = updated.Quantity,
					Price = updated.Price,
					Total = updated.Total,
					CreatedAt = updated.CreatedAt,
					UpdatedAt = updated.UpdatedAt
				};
				return Ok(readDto);
			}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _orderDetailService.DeleteAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}

		[HttpGet("ByOrder/{orderId}")]
		public async Task<ActionResult<IEnumerable<OrderDetailReadDto>>> GetByOrderId(int orderId)
		{
			var details = await _orderDetailService.GetByOrderIdAsync(orderId);
			var dtos = details.Select(d => new OrderDetailReadDto
			{
				Id = d.Id,
				OrderId = d.OrderId,
				ItemId = d.ItemId,
				Quantity = d.Quantity,
				Price = d.Price,
				Total = d.Total,
				CreatedAt = d.CreatedAt,
				UpdatedAt = d.UpdatedAt
			});
			return Ok(dtos);
		}
	}
}
