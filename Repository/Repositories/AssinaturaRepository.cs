using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class AssinaturaRepository : BaseRepository<Assinatura>, IAssinaturaRepository
    {
        private readonly AppDbContext _dbContext;
        public AssinaturaRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
