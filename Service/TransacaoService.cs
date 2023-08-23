using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class TransacaoService : BaseService<Transacao,TransacaoRequest,TransacaoResponse,TransacaoRequest>, ITransacaoService
    {
        private readonly ITransacaoRepository _repository;
        private readonly IMapper _mapper;

        public TransacaoService(ITransacaoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
