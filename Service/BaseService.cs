using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : Entidade
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> ObterTodos(Expression<Func<T, bool>> expression)
        {
            return _repository.BuscarEntidades(expression);
        }

        public T ObterAsync(Expression<Func<T, bool>> expression)
        {
            var entity =  _repository.BuscarEntidade(expression);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado");

            return entity;
        }

        public IEnumerable<T> ObterTodosAsync()
        {
            return _repository.BuscarEntidades();
        }

        public T BuscarEntidadePorId(Guid id)
        {
            var entity =  _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            return entity;
        }

        public void AdicionarAsync(T entity)
        {
            _repository.CriarEntidade(entity);
        }

        public void DeletarAsync(Guid id)
        {
            var entity = _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            _repository.EditarEntidade(entity);
        }

        public void AlterarAsync(T entity)
        {
            var find = _repository.BuscarEntidade(x => x.Id == entity.Id);
            if (find == null)
            {
                throw new ArgumentException($"Nenhum dado encontrado para o Id {entity.Id}");
            }

            _repository.EditarEntidade(entity);
        }
    }
}
