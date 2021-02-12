namespace ProjetZORK.DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DbContextFactory : IDesignTimeDbContextFactory<ZorkManagerDbContext>
    {
        public ZorkManagerDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<ZorkManagerDbContext>();

            dbContextBuilder.UseSqlServer("Server=localhost;Database=ZorkDb;Trusted_Connection=true;",
                opt => opt.MigrationsAssembly("ProjetZORK.DataAccessLayer"));

            return new ZorkManagerDbContext(dbContextBuilder.Options);
        }
    }
}
