using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface ITransacaoService : IBaseService<TransacaoRequest, TransacaoResponse,TransacaoRequest>
    {
    }
}
