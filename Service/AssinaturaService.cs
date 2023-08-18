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
        private readonly ITransacaoRepository _transacaoRepository;
        public AssinaturaService(IAssinaturaRepository repository, IMapper mapper, ITransacaoRepository transacaoRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _transacaoRepository = transacaoRepository;
        }

        public override Guid Adicionar(AssinaturaRequest request)
        {
            var assinatura = _mapper.Map<Assinatura>(request);

            _repository.CriarEntidade(assinatura);

            assinatura.Transacao = new Transacao { AssinaturaId = assinatura.Id,MetodoPagamento = request.MetodoPagamento, Valor = request.Valor };

            _repository.EditarEntidade(assinatura);

            return assinatura.Id;
        }
    }
}
