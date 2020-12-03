using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddCoreUtilEfRepositories(this IServiceCollection services)
		{
			services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));

			return services;
		}
	}
}
