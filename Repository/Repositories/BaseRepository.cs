using Domain.Entities;
using Domain.Interfaces.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entidade
    {
        private readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T BuscarEntidadePorId(Guid entidadeId)
        {
            return _dbContext.Set<T>().FirstOrDefault(e => e.Id == entidadeId);
        }

        public IEnumerable<T> BuscarEntidades()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void CriarEntidade(T entidade)
        {
            _dbContext.Set<T>().Add(entidade);
            _dbContext.SaveChanges();
        }

        public void DeletarEntidade(T entidade)
        {
            _dbContext.Set<T>().Remove(entidade);
            _dbContext.SaveChanges();
        }

        public void EditarEntidade(T entidade)
        {
            _dbContext.Set<T>().Update(entidade);
            _dbContext.SaveChanges();
        }
    }
}
