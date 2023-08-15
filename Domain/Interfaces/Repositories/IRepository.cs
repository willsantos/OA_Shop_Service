using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entidade
    {
        public void CriarEntidade(T entidade);
        public T BuscarEntidadePorId(Guid entidadeId);
        public IEnumerable<T> BuscarEntidades();
        public void EditarEntidade(T entidade);
        public void DeletarEntidade(T entidade);
    }
}
