using Microsoft.Extensions.DependencyInjection;
using RentaProject.Infrastructure.Repository.Contracts;
using RentaProject.Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Application.Service.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRentaProjectRepository, RentaProjectRepository>();
            return services;
        }
    }
}
