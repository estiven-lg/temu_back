using temu_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public interface IOrderDetailRepository
	{
		Task<IEnumerable<OrderDetail>> GetAllAsync();
		Task<OrderDetail?> GetByIdAsync(int id);
		Task<OrderDetail> AddAsync(OrderDetail orderDetail);
		Task<OrderDetail?> UpdateAsync(OrderDetail orderDetail);
		Task<bool> DeleteAsync(int id);
	}
}
