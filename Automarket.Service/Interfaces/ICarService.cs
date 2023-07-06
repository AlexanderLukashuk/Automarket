using System;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;

namespace Automarket.Service.Interfaces
{
	public interface ICarService
	{
		Task<BaseResponse<IEnumerable<Car>>> GetCars();
	}
}

