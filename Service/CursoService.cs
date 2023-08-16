using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace Service
{
    public class CursoService : BaseService<Curso, CursoCreateRequest, CursoResponse>, ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
