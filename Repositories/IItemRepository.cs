using temu_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public interface IItemRepository
	{
		Task<IEnumerable<Item>> GetAllAsync();
		Task<Item?> GetByIdAsync(int id);
		Task<Item> AddAsync(Item item);
		Task<Item?> UpdateAsync(Item item);
		Task<bool> DeleteAsync(int id);
	}
}
