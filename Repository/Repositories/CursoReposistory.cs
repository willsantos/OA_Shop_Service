using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        private readonly AppDbContext _dbContext;
        public CursoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
