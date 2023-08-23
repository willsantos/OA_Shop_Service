using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class CursoService : BaseService<Curso, CursoCreateRequest,CursoResponse,CursoEditRequest>, ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Guid Adicionar(CursoCreateRequest request)
        {
            var curso = _mapper.Map<Curso>(request);

            _repository.CriarEntidade(curso);

            foreach(var categoriaId  in request.Categorias)
            {
                curso.CursoCategoria.Add(new CursoCategoria { CategoriaId = categoriaId, CursoId = curso.Id });
            }

            _repository.EditarEntidade(curso);

            return curso.Id;
        }
    }
}
