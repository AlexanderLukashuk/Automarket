using System;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "0 elements found";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}

