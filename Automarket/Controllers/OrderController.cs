using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automarket.Domain.ViewModels.Order;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult CreateOrder(long id)
        {
            var orderModel = new CreateOrderViewModel()
            {
                CarId = id,
                Login = User.Identity?.Name,
                Quantity = 0
            };
            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderService.Create(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderService.Delete(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error", $"{response.Description}");
        }
    }
}

