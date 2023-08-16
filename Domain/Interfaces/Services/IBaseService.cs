using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T>
    {
        public IEnumerable<T> ObterTodos(Expression<Func<T, bool>> expression);

        public T ObterAsync(Expression<Func<T, bool>> expression);

        public IEnumerable<T> ObterTodosAsync();

        public T BuscarEntidadePorId(Guid id);

        public void AdicionarAsync(T entity);

        public void DeletarAsync(Guid id);

        public void AlterarAsync(T entity);
    }
}
