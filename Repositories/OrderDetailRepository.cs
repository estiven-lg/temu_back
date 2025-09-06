using temu_back.Models;
using temu_back.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly AppDbContext _context;

		public OrderDetailRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<OrderDetail>> GetAllAsync()
		{
			return await _context.OrderDetails.Include(od => od.Item).ToListAsync();
		}

		public async Task<OrderDetail?> GetByIdAsync(int id)
		{
			return await _context.OrderDetails.Include(od => od.Item).FirstOrDefaultAsync(od => od.Id == id);
		}

		public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
		{
			_context.OrderDetails.Add(orderDetail);
			await _context.SaveChangesAsync();
			return orderDetail;
		}

		public async Task<OrderDetail?> UpdateAsync(OrderDetail orderDetail)
		{
			var existing = await _context.OrderDetails.FindAsync(orderDetail.Id);
			if (existing == null) return null;
			_context.Entry(existing).CurrentValues.SetValues(orderDetail);
			await _context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var orderDetail = await _context.OrderDetails.FindAsync(id);
			if (orderDetail == null) return false;
			_context.OrderDetails.Remove(orderDetail);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
		{
			return await _context.OrderDetails
				.Where(od => od.OrderId == orderId)
				.Include(od => od.Item)
				.ToListAsync();
		}
	}
}
