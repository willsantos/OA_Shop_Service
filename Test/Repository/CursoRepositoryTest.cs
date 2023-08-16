using AutoFixture;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repository.Context;
using Repository.Repositories;
using Test.Configs;



namespace Test.Repository
{
    [Trait("Repository", "Curso Repository")]
    public class CursoRepositoryTest
    {
        private readonly Mock<AppDbContext> _appDbContext;
        private readonly Fixture _fixture;

        public CursoRepositoryTest()
        {
            _appDbContext = new Mock<AppDbContext>();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Cadastra um Curso")]
        public void Post()
        {
            var entidade = _fixture.Create<Curso>();
            var mockDbSet = new Mock<DbSet<Curso>>();

            _appDbContext.Setup(mock => mock.Set<Curso>()).Returns(mockDbSet.Object);

            var repository = new CursoRepository(_appDbContext.Object);

            repository.CriarEntidade(entidade);

            mockDbSet.Verify(dbSet => dbSet.Add(entidade), Times.Once);
            _appDbContext.Verify(dbContext => dbContext.SaveChanges(), Times.Once);           
        }

        [Fact(DisplayName = "Lista todos os Cursos")]
        public void Get()
        {
            var entidades = _fixture.CreateMany<Curso>().ToList();

            _appDbContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(entidades);

            var repository = new CursoRepository(_appDbContext.Object);

            var result = repository.BuscarEntidades();

            Assert.Equal(entidades.Count, result.Count());
        }

        [Fact(DisplayName = "Busca um Curso por Id")]
        public void GetById()
        {
            var entidade = _fixture.Create<Curso>();
            var id = entidade.Id;

            _appDbContext.Setup(mock => mock.Set<Curso>().Find(id)).Returns(entidade);

            var repository = new CursoRepository(_appDbContext.Object);
            
            var result = repository.BuscarEntidadePorId(id);

            Assert.Equal(entidade, result);
        }

        [Fact(DisplayName = "Busca uma Entidade por Expressão")]
        public void GetByExpression()
        {
            var entidade = _fixture.Create<Curso>();
            entidade.Duracao = 1;
            var entidades = _fixture.CreateMany<Curso>().ToList();
            entidades.Add(entidade);

            _appDbContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(entidades);

            var repository = new CursoRepository(_appDbContext.Object);

            var result = repository.BuscarEntidade(x => x.Duracao == 1);

            var expectedEntity = entidades.FirstOrDefault(x => x.Duracao == 1);
            Assert.Equal(expectedEntity, result);
        }

        [Fact(DisplayName = "Busca várias Entidade por Expressão")]
        public void GetManyByExpression()
        {
            var entidade = _fixture.Create<Curso>();
            entidade.Duracao = 1;
            var entidades = _fixture.CreateMany<Curso>().ToList();
            entidades.Add(entidade);

            _appDbContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(entidades);

            var repository = new CursoRepository(_appDbContext.Object);

            var result = repository.BuscarEntidades(x => x.Duracao == 1);

            var expectedEntity = entidades.Where(x => x.Duracao == 1);
            Assert.Equal(expectedEntity, result);
        }

        [Fact(DisplayName = "Deleta uma Entidade")]
        public void DeletarEntidade()
        {
            var entidade = _fixture.Create<Curso>();
            var mockDbSet = new Mock<DbSet<Curso>>();

            _appDbContext.Setup(mock => mock.Set<Curso>()).Returns(mockDbSet.Object);

            var repository = new CursoRepository(_appDbContext.Object);

            repository.DeletarEntidade(entidade);

            mockDbSet.Verify(dbSet => dbSet.Remove(entidade), Times.Once);
            _appDbContext.Verify(dbContext => dbContext.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Edita uma Entidade")]
        public void EditarEntidade()
        {
            var entidade = _fixture.Create<Curso>();
            var mockDbSet = new Mock<DbSet<Curso>>();

            _appDbContext.Setup(mock => mock.Set<Curso>()).Returns(mockDbSet.Object);

            var repository = new CursoRepository(_appDbContext.Object);

            repository.EditarEntidade(entidade);

            mockDbSet.Verify(dbSet => dbSet.Update(entidade), Times.Once);
            _appDbContext.Verify(dbContext => dbContext.SaveChanges(), Times.Once);
        }
    }
}