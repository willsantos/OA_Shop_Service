using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class CategoriaService : BaseService<Categoria, CategoriaRequest,CategoriaResponse,CategoriaRequest>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
