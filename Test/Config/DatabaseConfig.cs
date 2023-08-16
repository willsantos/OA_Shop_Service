using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Test.Config
{
    public class DatabaseConfig : IDisposable
    {
        public readonly AppDbContext context;
        public DatabaseConfig()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: "AppDbInMemory");

            var dbContextOptions = builder.Options;
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
