using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carRepository.Select();
            return View(response);
        }
    }
}

