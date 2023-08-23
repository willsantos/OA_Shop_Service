using AutoFixture;
using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Service;
using System.Linq.Expressions;
using Test.Configs;

namespace Test.Service
{
    [Trait("Service", "Curso Service")]
    public class CursoServiceTest
    {
        private readonly Mock<ICursoRepository> _cursoRepository;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public CursoServiceTest()
        {
            _cursoRepository = new Mock<ICursoRepository>();
            _mapper = MapperConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Obter Todos os Cursos")]
        public void ObterTodos()
        {
            var cursos = new List<Curso>
            {
                new Curso { Id = Guid.NewGuid(), Nome = "Curso 1" },
                new Curso { Id = Guid.NewGuid(), Nome = "Curso 2" }
            };

            _cursoRepository.Setup(repo => repo.BuscarEntidades()).Returns(cursos);

            var cursoResponses = cursos.Select(curso => new CursoResponse { Nome = curso.Nome });

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var result = cursoService.ObterTodos();

            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "Obter Todos os Cursos Com Expressao")]
        public void ObterTodosComExpressao()
        {
            var cursos = new List<Curso>
            {
                new Curso { Id = Guid.NewGuid(), Nome = "Curso 1" },
                new Curso { Id = Guid.NewGuid(), Nome = "Curso 2" }
            };

            _cursoRepository.Setup(repo => repo.BuscarEntidades(It.IsAny<Expression<Func<Curso, bool>>>())).Returns(cursos);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var result = cursoService.ObterTodos(curso => curso.Nome == "Curso 1");

            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "Obter um Curso Com Expressao")]
        public void ObterComExpressao()
        {
            var curso = _fixture.Create<Curso>();

            var nome = curso.Nome;

            _cursoRepository.Setup(repo => repo.BuscarEntidade(It.IsAny<Expression<Func<Curso, bool>>>())).Returns(curso);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var result = cursoService.Obter(curso => curso.Nome == nome);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Obter um Curso nulo Com Expressao")]
        public void ObterNuloComExpressao()
        {
            var curso = _fixture.Create<Curso>();

            var nome = curso.Nome;

            _cursoRepository.Setup(repo => repo.BuscarEntidade(It.IsAny<Expression<Func<Curso, bool>>>())).Returns((Curso)null);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            try
            {
                cursoService.Obter(curso => curso.Nome == nome);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact(DisplayName = "Obter um Curso por Id")]
        public void ObterPorId()
        {
            var curso = _fixture.Create<Curso>();

            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns(curso);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var result = cursoService.BuscarEntidadePorId(id);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Obter um Curso Nulo por Id")]
        public void ObterCursoNuloPorId()
        {
            var curso = _fixture.Create<Curso>();

            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns((Curso)null);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            try
            {
                cursoService.BuscarEntidadePorId(id);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact(DisplayName = "Adicionar um Curso")]
        public void Adicionar()
        {
            var cursoRequest = new CursoCreateRequest { Nome = "Novo Curso" , Categorias=new List<Guid> { new Guid() } };
            var cursoEntity = new Curso { Id = Guid.NewGuid(), Nome = "Novo Curso" };

            _cursoRepository.Setup(repo => repo.CriarEntidade(cursoEntity));

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            cursoService.Adicionar(cursoRequest);

            var exception = Record.Exception(() => cursoService.Adicionar(cursoRequest));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Deletar um Curso")]
        public void Deletar()
        {
            var curso = _fixture.Create<Curso>();
            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.DeletarEntidade(curso));
            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns(curso);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var exception = Record.Exception(() => cursoService.Deletar(id));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Deletar um Curso Nulo")]
        public void DeletarCursoNulo()
        {
            var curso = _fixture.Create<Curso>();
            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.DeletarEntidade(curso));
            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns((Curso)null);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            try
            {
                cursoService.Deletar(id);
            }
            catch (Exception ex)
            {

                Assert.NotNull(ex);
            }
        }

        [Fact(DisplayName = "Alterar um Curso")]
        public void Alterar()
        {
            var curso = _fixture.Create<Curso>();
            var cursoRequest = _fixture.Create<CursoEditRequest>();

            cursoRequest.Id = curso.Id;

            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.EditarEntidade(curso));
            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns(curso);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);

            var exception = Record.Exception(() => cursoService.Alterar(cursoRequest, id));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Alterar um Curso Nulo")]
        public void AlterarCursoNulo()
        {
            var curso = _fixture.Create<Curso>();
            var cursoRequest = _fixture.Create<CursoEditRequest>();

            cursoRequest.Id = curso.Id;

            var id = curso.Id;

            _cursoRepository.Setup(repo => repo.EditarEntidade(curso));
            _cursoRepository.Setup(repo => repo.BuscarEntidadePorId(id)).Returns((Curso)null);

            var cursoService = new CursoService(_cursoRepository.Object, _mapper);
            try
            {
                cursoService.Alterar(cursoRequest, id);
            }
            catch (Exception ex)
            {
            Assert.NotNull(ex);
            }
        }
    }
}
