using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
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
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entidade

    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<object> ObterTodos(Expression<Func<object, bool>> expression)
        {
            var entities = _repository.BuscarEntidades(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            return _mapper.Map<IEnumerable<object>>(entities);
        }
        
        public object Obter(Expression<Func<object, bool>> expression)
        {
            var entity = _repository.BuscarEntidade(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado");

            return _mapper.Map<object>(entity);
        }

        public IEnumerable<object> ObterTodos()
        {
            var entities = _repository.BuscarEntidades();
            return _mapper.Map<IEnumerable<object>>(entities);
        }

        public object BuscarEntidadePorId(Guid id)
        {
            var entity = _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            return _mapper.Map<object>(entity);
        }

        public void Adicionar(object request)
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

        public void Alterar(object request)
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