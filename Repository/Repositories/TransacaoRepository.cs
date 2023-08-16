using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        private readonly AppDbContext _dbContext;
        public TransacaoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
