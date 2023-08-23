using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface ICursoService : IBaseService<CursoCreateRequest,CursoResponse,CursoEditRequest>
    {

    }
}
