using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Service
{
    public abstract class BaseService<TEntity, TRequest,TResponse, TEditRequest> : IBaseService<TRequest, TResponse, TEditRequest> 
        where TEntity : Entidade
        where TRequest : BaseRequest
        where TEditRequest : BaseRequest
        where TResponse : BaseResponse

    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TResponse> ObterTodos(Expression<Func<TRequest, bool>> expression)
        {
            var entities = _repository.BuscarEntidades(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            return _mapper.Map<IEnumerable<TResponse>>(entities);
        }
        
        public TResponse Obter(Expression<Func<TRequest, bool>> expression)
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

        public virtual Guid Adicionar(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _repository.CriarEntidade(entity);
            return entity.Id;
        }

        public void Deletar(Guid id)
        {
            var entity = _repository.BuscarEntidadePorId(id);
            if (entity == null)
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");

            _repository.DeletarEntidade(entity);
        }

        public virtual void Alterar(TEditRequest request, Guid id)
        {
            var entity = _mapper.Map<TEntity>(request);
            var find = _repository.BuscarEntidadePorId(id);
            if (find == null)
            {
                throw new ArgumentException($"Nenhum dado encontrado para o Id {id}");
            }

            _repository.EditarEntidade(entity);
        }
    }
}