using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace Service
{
    public class EnderecoService : BaseService<Endereco, EnderecoRequest,EnderecoResponse,EnderecoRequest>, IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
