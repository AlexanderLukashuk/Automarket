using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Automarket.Domain.ViewModels.Car
{
	public class CarViewModel
	{
        public long Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name")]
        [MinLength(2, ErrorMessage = "The minimum length must be more than two characters")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [MinLength(50, ErrorMessage = "The minimum length must be more than 50 characters")]
        public string? Desctiption { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Specify the model")]
        [MinLength(2, ErrorMessage = "The minimum length must be more than two characters")]
        public string? Model { get; set; }

        [Display(Name = "Speed")]
        [Required(ErrorMessage = "Specify the speed")]
        [Range(0, 600, ErrorMessage = "The speed should be in the range from 0 to 600")]
        public double Speed { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Specify the price")]
        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        [Display(Name = "Type of car")]
        [Required(ErrorMessage = "Select the type")]
        public string? TypeCar { get; set; }

        public IFormFile? Avatar { get; set; }

        public byte[]? Image { get; set; }
    }
}

