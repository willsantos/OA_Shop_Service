using AutoFixture;
using Domain.Entities;
using Repository.Repositories;
using Test.Config;

namespace Test.Repository
{
    public class UsuarioRepositoryTest : IDisposable
    {
        private readonly Fixture _fixture;
        private DatabaseConfig _dataBaseConfig;

        public UsuarioRepositoryTest()
        {
            _dataBaseConfig = new DatabaseConfig();
            _fixture = FixtureConfig.GetFixture();
        }
        public void Dispose()
        {
            _dataBaseConfig.Dispose();
        }

        [Fact]
        public void TesteCriarUsuarios()
        {

            var user = _fixture.Build<Usuario>().With(u => u.Id , Guid.Empty).Create();

            var repo = new UsuarioRepository(_dataBaseConfig.context);

            repo.CriarEntidade(user);
 
            Assert.NotEqual(user.Id, Guid.Empty);
        }

        [Fact]
        public void TesteObterUsuarioPorId()
        {
            var databaseConfig = new DatabaseConfig();

            var user = _fixture.Build<Usuario>().With(u => u.Id, Guid.Empty).Create();

            var repo = new UsuarioRepository(_dataBaseConfig.context);

            repo.CriarEntidade(user);

            var userDoBanco = repo.BuscarEntidadePorId(user.Id);
            Assert.Equal(user, userDoBanco);
        }

        [Fact]
        public void TesteEditarUsuario()
        {
            var user = _fixture.Build<Usuario>().With(u => u.Id, Guid.Empty).Create();

            var repo = new UsuarioRepository(_dataBaseConfig.context);

            repo.CriarEntidade(user);

            user.Nome = "Anastacio";

            repo.EditarEntidade(user);

            var userEditado = repo.BuscarEntidadePorId(user.Id);
            Assert.Equal(user.Nome, userEditado.Nome);
        }

        [Fact]
        public void TesteDeletarUsuario()
        {
            var user = _fixture.Build<Usuario>().With(u => u.Id, Guid.Empty).Create();

            var repo = new UsuarioRepository(_dataBaseConfig.context);

            repo.CriarEntidade(user);

            repo.DeletarEntidade(user);
            var nullUser = repo.BuscarEntidadePorId(user.Id);
            Assert.Null(nullUser);
        }

        [Fact]
        public void TesteObterUsuarios()
        {
            var users = _fixture.Build<Usuario>().With(u => u.Id, Guid.Empty).CreateMany(7).ToList();


            var repo = new UsuarioRepository(_dataBaseConfig.context);

            repo.CriarEntidade(users[0]);
            repo.CriarEntidade(users[1]);
            repo.CriarEntidade(users[2]);


            var usersDoBanco = repo.BuscarEntidades();
            var contagemDoBanco = usersDoBanco.Count();

            Assert.Equal(3, contagemDoBanco);
        }
    }
}
