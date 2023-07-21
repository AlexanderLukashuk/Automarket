using System;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;

namespace Automarket.Service.Interfaces
{
	public interface IOrderService
	{
		Task<IBaseResponse<Order>> Create(CreateOrderViewModel model);

		Task<IBaseResponse<bool>> Delete(long id);
	}
}

