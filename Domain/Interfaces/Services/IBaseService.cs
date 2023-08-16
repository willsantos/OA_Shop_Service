using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        public IEnumerable<object> ObterTodos(Expression<Func<object, bool>> expression);

        public object Obter(Expression<Func<object, bool>> expression);

        public IEnumerable<object> ObterTodos();

        public object BuscarEntidadePorId(Guid id);

        public void Adicionar(object entity);

        public void Deletar(Guid id);

        public void Alterar(object entity);
    }
}
