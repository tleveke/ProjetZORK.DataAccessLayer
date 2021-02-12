using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetZORK.DataAccessLayer.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.Extensions
{
    public static class DataAccessLayerServiceExtensions
    {
        public static IServiceCollection AddDataAccessLayerService(this IServiceCollection services)
        {
            services.AddDbContext<ZorkManagerDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=StudentManager;Trusted_Connection=true;", opt => opt.MigrationsAssembly("StudentManager.DataAccessLayer"));
            });

            services.AddTransient<ZorkAccessLayer>();

            return services;
        }
    }
}
