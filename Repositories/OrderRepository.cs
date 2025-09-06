using temu_back.Models;
using temu_back.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>> GetAllAsync()
		{
			return await _context.Orders.Include(o => o.Person).ToListAsync();
		}

		public async Task<Order?> GetByIdAsync(int id)
		{
			return await _context.Orders.Include(o => o.Person).FirstOrDefaultAsync(o => o.Id == id);
		}

		public async Task<Order> AddAsync(Order order)
		{
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();
			return order;
		}

		public async Task<Order?> UpdateAsync(Order order)
		{
			var existing = await _context.Orders.FindAsync(order.Id);
			if (existing == null) return null;
			_context.Entry(existing).CurrentValues.SetValues(order);
			await _context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order == null) return false;
			_context.Orders.Remove(order);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
