using System;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
	public interface ICarService
	{
        Task<IBaseResponse<List<Car>>> GetCars();

		Task<IBaseResponse<Car>> GetCar(int id);

		Task<IBaseResponse<Car>> CreateCar(CarViewModel carViewModel, byte[] imageData);

		Task<IBaseResponse<bool>> DeleteCar(int id);

		Task<BaseResponse<Dictionary<long, string>>> GetCar(string name);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
	}
}

