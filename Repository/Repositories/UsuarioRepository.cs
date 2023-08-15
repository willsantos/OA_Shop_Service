using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
