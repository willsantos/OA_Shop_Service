using System.Linq.Expressions;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<TRequest, TResponse, TEditRequest>
    {
        public IEnumerable<TResponse> ObterTodos(Expression<Func<TRequest, bool>> expression);

        public TResponse Obter(Expression<Func<TRequest, bool>> expression);

        public IEnumerable<TResponse> ObterTodos();

        public TResponse BuscarEntidadePorId(Guid id);

        public Guid Adicionar(TRequest request);
        public void Deletar(Guid id);
        public void Alterar(TEditRequest request, Guid id);
    }
}
