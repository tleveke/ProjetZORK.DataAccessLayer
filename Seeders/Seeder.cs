using ProjetZORK.DataAccessLayer;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetZORK
{
    public class Seeder
    {
        private readonly ZorkManagerDbContext dbContext;

        public Seeder(ZorkManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task EnsureSeedDataAsync()
        {
/*            if (!this.dbContext.Weapons.Any())
            {
                await this.dbContext.AddRangeAsync(WeaponsSeeder.Seed()).ConfigureAwait(false);
            }

            if (!this.dbContext.Spots.Any())
            {
                await this.dbContext.AddRangeAsync(SpotsSeeder.Seed()).ConfigureAwait(false);
            }*/
            await this.dbContext.SaveChangesAsync();
        }

    }
}
