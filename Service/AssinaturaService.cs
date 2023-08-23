using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Utils;

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

            try
            {
            _repository.CriarEntidade(assinatura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            var token = JwtToken.GeradorTokenAssinatura(assinatura);

            return assinatura.Id;
        }
    }
}
