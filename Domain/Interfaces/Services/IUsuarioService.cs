using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<UsuarioCreateRequest, UsuarioResponse, UsuarioEditRequest>
    {
    }
}
