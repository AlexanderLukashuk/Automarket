using System;
using Automarket.DAL.Interfaces;
using Automarket.DAL.Repositories;
using Automarket.Domain.Entity;
using Automarket.Service.Implementations;
using Automarket.Service.Interfaces;

namespace Automarket
{
	public static class StartupInit
	{
		public static void InitializeRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBaseRepository<Car>, CarRepository>();
			//services.AddScoped<IBaseRepository<User>, UserRepository>();
		}

		public static void InitializeServices(this IServiceCollection services)
		{
			services.AddScoped<ICarService, CarService>();
			//services.AddScoped<IAccountService, AccountService>();
		}
	}
}

