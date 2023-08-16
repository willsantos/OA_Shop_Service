using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class CursoCategoriaRepository : BaseRepository<CursoCategoria>, ICursoCategoriaRepository
    {
        private readonly AppDbContext _dbContext;
        public CursoCategoriaRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
