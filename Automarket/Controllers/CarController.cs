using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        //private readonly ICarRepository _carRepository;

        //public CarController(ICarRepository carRepository)
        //{
        //    _carRepository = carRepository;
        //}

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            //var response = await _carRepository.Select();
            //var response1 = await _carRepository.GetByName("BMW X5");
            //var response2 = await _carRepository.Get(4);

            //var car = new Car()
            //{
            //    Name = "Vaz 2114",
            //    Model = "VAZ",
            //    Speed = 140,
            //    Price = 150000,
            //    Desctiption = "Test",
            //    DateCreate = DateTime.Now
            //};

            //await _carRepository.Create(car);
            //await _carRepository.Delete(car);

            var response = await _carService.GetCars();
            //if (response.StatusCode == Domain.Enum.StatusCode.OK)
            //{
            //    return View(response.Data);
            //}
            //return RedirectToAction("Error");

            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Save(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await _carService.CreateCar(model);
                }
                else
                {
                    await _carService.Edit();
                }
            }
        }
    }
}

