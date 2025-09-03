using temu_back.Models;
using temu_back.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<IEnumerable<Order>> GetAllAsync()
		{
			return await _orderRepository.GetAllAsync();
		}

		public async Task<Order?> GetByIdAsync(int id)
		{
			return await _orderRepository.GetByIdAsync(id);
		}

		public async Task<Order> AddAsync(Order order)
		{
			return await _orderRepository.AddAsync(order);
		}

		public async Task<Order?> UpdateAsync(Order order)
		{
			return await _orderRepository.UpdateAsync(order);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _orderRepository.DeleteAsync(id);
		}
	}
}
