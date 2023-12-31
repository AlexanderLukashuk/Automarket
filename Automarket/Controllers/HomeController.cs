﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Automarket.Models;
using Automarket.Domain.Entity;

namespace Automarket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Car car = new Car()
        {
            Name = "Alex",
            Speed = 320
        };
        return View(car);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

