using Microsoft.Extensions.DependencyInjection;
using RentaProject.Infrastructure.Utils.Contracts;
using RentaProject.Infrastructure.Utils.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Repository.Services
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IExcelManager, ExcelManager>();
            services.AddScoped<IFileManager, FileManager>();
            return services;
        }
    }
}
