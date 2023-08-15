using Domain.Contracts.Requests;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        public void CriarEntidade(UsuarioRequest usuarioRequest);

    }
}
