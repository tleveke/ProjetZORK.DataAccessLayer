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
            /*services.AddDbContext<ZorkManagerDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=ZorkDb;Trusted_Connection=true;", opt => opt.MigrationsAssembly("ProjetZORK.DataAccessLayer"));
            });*/
            services.AddDbContext<ZorkManagerDbContext>(options => options.UseSqlServer("Server=localhost;Database=ZorkDb;Trusted_Connection=true;", 
                opt => { opt.MigrationsAssembly("ProjetZORK.DataAccessLayer"); /*opt.EnableRetryOnFailure();*/ }), ServiceLifetime.Transient);
            //services.AddScoped<ZorkManagerDbContext>();
            services.AddTransient<ZorkAccessLayer>();
            services.AddTransient<CellAccessLayer>();
            services.AddTransient<MonsterAccessLayer>();

            return services;
        }

    }
}
