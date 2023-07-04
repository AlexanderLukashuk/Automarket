using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum
{
	public enum TypeCar
	{
		[Display(Name = "Passenger Car")]
		PassengerCar = 0,
		[Display(Name = "Sedan")]
		Sedan = 1,
		[Display(Name = "Hatchback")]
		HatchBack = 2,
		[Display(Name = "Minivan")]
		Minivan = 3,
		[Display(Name = "Sports Car")]
		SportsCar = 4,
		[Display(Name = "Sport Utility Vehicle")]
		Suv = 5
	}
}

