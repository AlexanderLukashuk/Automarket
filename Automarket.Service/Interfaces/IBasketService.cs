using System;
using Automarket.Domain.Response;

namespace Automarket.Service.Interfaces
{
	public interface IBasketService
	{
		Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

		Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
	}
}

