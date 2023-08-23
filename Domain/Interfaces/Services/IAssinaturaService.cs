using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface IAssinaturaService : IBaseService<AssinaturaRequest,AssinaturaResponse,AssinaturaRequest>
    {
    }
}
