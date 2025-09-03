using temu_back.Models;
using temu_back.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Services
{
	public class OrderDetailService : IOrderDetailService
	{
		private readonly IOrderDetailRepository _orderDetailRepository;

		public OrderDetailService(IOrderDetailRepository orderDetailRepository)
		{
			_orderDetailRepository = orderDetailRepository;
		}

		public async Task<IEnumerable<OrderDetail>> GetAllAsync()
		{
			return await _orderDetailRepository.GetAllAsync();
		}

		public async Task<OrderDetail?> GetByIdAsync(int id)
		{
			return await _orderDetailRepository.GetByIdAsync(id);
		}

		public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
		{
			return await _orderDetailRepository.AddAsync(orderDetail);
		}

		public async Task<OrderDetail?> UpdateAsync(OrderDetail orderDetail)
		{
			return await _orderDetailRepository.UpdateAsync(orderDetail);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _orderDetailRepository.DeleteAsync(id);
		}
	}
}
