using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        public UsuarioResponse CriarEntidade(UsuarioCreateRequest usuarioRequest);
        public UsuarioResponse BuscarUsuarioPorId(Guid id);
        public IEnumerable<UsuarioResponse> BuscarUsuarios();
        public void DeletarEntidade(Guid id);
        public UsuarioResponse EditarEntidade(UsuarioEditRequest usuarioEditRequest, Guid id);
    }
}
