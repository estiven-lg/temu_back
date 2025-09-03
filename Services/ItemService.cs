using temu_back.Models;
using temu_back.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Services
{
	public class ItemService : IItemService
	{
		private readonly IItemRepository _itemRepository;

		public ItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public async Task<IEnumerable<Item>> GetAllAsync()
		{
			return await _itemRepository.GetAllAsync();
		}

		public async Task<Item?> GetByIdAsync(int id)
		{
			return await _itemRepository.GetByIdAsync(id);
		}

		public async Task<Item> AddAsync(Item item)
		{
			return await _itemRepository.AddAsync(item);
		}

		public async Task<Item?> UpdateAsync(Item item)
		{
			return await _itemRepository.UpdateAsync(item);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _itemRepository.DeleteAsync(id);
		}
	}
}
