using AutoMapper;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{
    [Trait("Service", "Curso Service")]
    public class CursoServiceTest
    {
        private readonly Mock<ICursoRepository> _cursoRepository;
        private readonly Mock<IMapper> _mapperMock;

        public CursoServiceTest()
        {
            _cursoRepository = new Mock<ICursoRepository>();
            _mapperMock = new Mock<IMapper>();
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

            var cursoResponses = cursos.Select(curso => new CursoResponse { Nome = curso.Nome }).ToList();
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CursoResponse>>(cursos))
                       .Returns(cursoResponses);

            var cursoService = new CursoService(_cursoRepository.Object, _mapperMock.Object);

            var result = cursoService.ObterTodos();

            Assert.Equal(cursoResponses, result);
        }

        [Fact(DisplayName = "Adicionar um Curso")]
        public void Adicionar()
        {
            var cursoRequest = new CursoRequest { Nome = "Novo Curso" };
            var cursoEntity = new Curso { Id = Guid.NewGuid(), Nome = "Novo Curso" };

            _mapperMock.Setup(mapper => mapper.Map<Curso>(cursoRequest))
                       .Returns(cursoEntity);

            var cursoService = new CursoService(_cursoRepository.Object, _mapperMock.Object);

            cursoService.Adicionar(cursoRequest);

            _cursoRepository.Verify(repo => repo.CriarEntidade(cursoEntity), Times.Once);
        }
    }
}
