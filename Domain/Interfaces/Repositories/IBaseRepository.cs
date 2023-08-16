using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entidade
    {
        public void CriarEntidade(T entidade);
        public T BuscarEntidadePorId(Guid entidadeId);
        public T BuscarEntidade(Expression<Func<T, bool>> expression);
        public IEnumerable<T> BuscarEntidades();
        public IEnumerable<T> BuscarEntidades(Expression<Func<T, bool>> expression);
        public void EditarEntidade(T entidade);
        public void DeletarEntidade(T entidade);
    }
}
