using temu_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAllAsync();
		Task<Order?> GetByIdAsync(int id);
		Task<Order> AddAsync(Order order);
		Task<Order?> UpdateAsync(Order order);
		Task<bool> DeleteAsync(int id);
	}
}
