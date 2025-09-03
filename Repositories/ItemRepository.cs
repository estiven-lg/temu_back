using temu_back.Models;
using temu_back.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly AppDbContext _context;

		public ItemRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Item>> GetAllAsync()
		{
			return await _context.Items.ToListAsync();
		}

		public async Task<Item?> GetByIdAsync(int id)
		{
			return await _context.Items.FindAsync(id);
		}

		public async Task<Item> AddAsync(Item item)
		{
			_context.Items.Add(item);
			await _context.SaveChangesAsync();
			return item;
		}

		public async Task<Item?> UpdateAsync(Item item)
		{
			var existing = await _context.Items.FindAsync(item.Id);
			if (existing == null) return null;
			_context.Entry(existing).CurrentValues.SetValues(item);
			await _context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var item = await _context.Items.FindAsync(id);
			if (item == null) return false;
			_context.Items.Remove(item);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
