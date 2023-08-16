using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Test.Helpers
{
    public class DatabaseHelper
    {
        private readonly AppDbContext _context;
        public DatabaseHelper()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: "InMemoryDbParaTestes");
            var dbContextOptions = builder.Options;
            _context = new AppDbContext(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}
