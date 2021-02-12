using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetZORK.DataAccessLayer.Seeders;
using System;
using System.Threading.Tasks;

namespace ProjetZORK.DataAccessLayer.Extensions
{
    public static class HostExtension
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                SeedApplicationData(scope);
            }
            return host;
        }

        private static void SeedApplicationData(IServiceScope scope)
        {
            var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
            try
            {
                Task.WaitAll(seeder.EnsureSeedDataAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Seed application data Error : [O]", ex.Message));
            }
        }

    }
}
