using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class AssinaturaService : BaseService<Assinatura, AssinaturaRequest, AssinaturaResponse, AssinaturaRequest>, IAssinaturaService
    {
        private readonly IMapper _mapper;
        private readonly IAssinaturaRepository _repository;
        public AssinaturaService(IAssinaturaRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override Guid Adicionar(AssinaturaRequest request)
        {
            var assinatura = _mapper.Map<Assinatura>(request);

            _repository.CriarEntidade(assinatura);

            return assinatura.Id;
        }
    }
}
