using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entidade
    {
        private readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T BuscarEntidadePorId(Guid entidadeId)
        {
            return _dbContext.Set<T>().Find(entidadeId);
        }

        public T BuscarEntidade(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> BuscarEntidades()
        {
            return _dbContext.Set<T>().ToList();
        }

        public IEnumerable<T> BuscarEntidades(Expression<Func<T, bool>> expression)
        {
            return  _dbContext.Set<T>().Where(expression).ToList();
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
