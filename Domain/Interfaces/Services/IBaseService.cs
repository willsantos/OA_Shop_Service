using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T, TRequest, TResponse>
    {
        public IEnumerable<TResponse> ObterTodos(Expression<Func<TResponse, bool>> expression);

        public TResponse Obter(Expression<Func<TResponse, bool>> expression);

        public IEnumerable<TResponse> ObterTodos();

        public TResponse BuscarEntidadePorId(Guid id);

        public void Adicionar(TRequest entity);

        public void Deletar(Guid id);

        public void Alterar(TRequest entity);
    }
}
