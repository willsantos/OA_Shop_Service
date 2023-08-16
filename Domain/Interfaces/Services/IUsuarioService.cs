using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        public UsuarioResponse CriarUsuario(UsuarioCreateRequest usuarioRequest);
        public UsuarioResponse BuscarUsuarioPorId(Guid id);
        public IEnumerable<UsuarioResponse> BuscarUsuarios();
        public void DeletarUsuario(Guid id);
        public UsuarioResponse EditarUsuario(UsuarioEditRequest usuarioEditRequest, Guid id);
    }
}
