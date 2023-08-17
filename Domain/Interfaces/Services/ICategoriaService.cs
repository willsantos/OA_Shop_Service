using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface ICategoriaService : IBaseService<CategoriaRequest,CategoriaResponse,CategoriaRequest>
    {
    }
}
