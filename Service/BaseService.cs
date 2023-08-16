using AutoMapper;
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
    public abstract class BaseService<TEntity, TRequest, TResponse> : IBaseService<TEntity, TRequest, TResponse>
       where TEntity : Entidade
       where TRequest : class
       where TResponse : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TResponse> ObterTodos(Expression<Func<TResponse, bool>> expression)
        {
            var entities = _repository.BuscarEntidades(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            return _mapper.Map<IEnumerable<TResponse>>(entities);
        }

        public TResponse Obter(Expression<Func<TResponse, bool>> expression)
        {
            var entity = _repository.BuscarEntidade(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado");

            return _mapper.Map<TResponse>(entity);
        }

        public IEnumerable<TResponse> ObterTodos()
        {
            var entities = _repository.BuscarEntidades();
            return _mapper.Map<IEnumerable<TResponse>>(entities);
        }

        public TResponse BuscarEntidadePorId(Guid id)
        {
            var entity = _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            return _mapper.Map<TResponse>(entity);
        }

        public void Adicionar(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _repository.CriarEntidade(entity);
        }

        public void Deletar(Guid id)
        {
            var entity = _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            _repository.DeletarEntidade(entity);
        }

        public void Alterar(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            var find = _repository.BuscarEntidadePorId(entity.Id);
            if (find == null)
            {
                throw new ArgumentException($"Nenhum dado encontrado para o Id {entity.Id}");
            }

            _repository.EditarEntidade(entity);
        }
    }
}