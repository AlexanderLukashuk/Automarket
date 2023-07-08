using System;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using Enable.EnumDisplayName;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                //var car = await _carRepository.Get(id);
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                var data = new Car()
                {
                    DateCreate = car.DateCreate,
                    Desctiption = car.Desctiption,
                    TypeCar = car.TypeCar,
                    Speed = car.Speed,
                    Model = car.Model,
                    Price = car.Price
                };

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
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

        public async Task<BaseResponse<Dictionary<long, string>>> GetCar(string name)
        {
            //var baseResponse = new BaseResponse<Car>();

            var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var cars = await _carRepository.GetAll()
                    .Select(c => new CarViewModel()
                    {
                        Id = c.Id,
                        Speed = c.Speed,
                        Name = c.Name,
                        Desctiption = c.Desctiption,
                        Model = c.Model,
                        DateCreate = c.DateCreate.ToLongDateString(),
                        Price = c.Price,
                        TypeCar = c.TypeCar.GetDisplayName()
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Name);

                baseResponse.Data = cars;
                return baseResponse;

                //if (car == null)
                //{
                //    baseResponse.Description = "Car not found";
                //    baseResponse.StatusCode = StatusCode.CarNotFound;
                //    return baseResponse;
                //}

                //baseResponse.Data = car;
                //return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<long, string>>()
                {
                    Description = $"[GetCarByName]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            //var baseResponse = new BaseResponse<bool>()
            //{
            //    Data = true
            //};

            try
            {
                //var car = await _carRepository.Get(id);
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
                if (car == null)
                {
                    //baseResponse.Description = "Car not found";
                    //baseResponse.StatusCode = StatusCode.CarNotFound;
                    //baseResponse.Data = false;
                    //return baseResponse;

                    return new BaseResponse<bool>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                //return baseResponse;

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> CreateCar(CarViewModel carViewModel, byte[] imageData)
        {
            //var baseResponse = new BaseResponse<CarViewModel>();

            try
            {
                var car = new Car()
                {
                    Name = carViewModel.Name,
                    Model = carViewModel.Model,
                    Desctiption = carViewModel.Desctiption,
                    DateCreate = DateTime.Now,
                    Speed = carViewModel.Speed,
                    Price = carViewModel.Price,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar),
                    Avatar = imageData
                };

                await _carRepository.Create(car);

                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<List<Car>>> GetCars()
        {
            //var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                //var cars = await _carRepository.Select();
                var cars = await _carRepository.GetAll().ToListAsync();
                //if (cars.Count == 0)
                if (!cars.Any())
                {
                    //baseResponse.Description = "0 elements found";
                    //baseResponse.StatusCode = StatusCode.OK;
                    //return baseResponse;

                    return new BaseResponse<List<Car>>()
                    {
                        Description = "0 elements found",
                        StatusCode = StatusCode.OK
                    };
                }

                //baseResponse.Data = cars;
                //baseResponse.StatusCode = StatusCode.OK;

                //return baseResponse;

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //return new BaseResponse<IEnumerable<Car>>()
                //{
                //    Description = $"[GetCars]: {ex.Message}",
                //    StatusCode = StatusCode.InternalServerError
                //};

                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            //var baseResponse = new BaseResponse<Car>();

            try
            {
                //var car = await _carRepository.Get(id);
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(c => c.Id == id);
                if (car == null)
                {
                    //baseResponse.StatusCode = StatusCode.CarNotFound;
                    //baseResponse.Description = "Car not found";
                    //return baseResponse;

                    return new BaseResponse<Car>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }

                car.Desctiption = model.Desctiption;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = DateTime.ParseExact(model.DateCreate, "yyyyMMdd HH:mm", null);
                car.Name = model.Name;

                await _carRepository.Update(car);

                //return baseResponse;

                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };

                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}

