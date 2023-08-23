using Domain.Contracts.Requests;
using Domain.Contracts.Responses;

namespace Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<EnderecoRequest,EnderecoResponse,EnderecoRequest>
    {
    }
}
