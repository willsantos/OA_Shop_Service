using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : BaseController<EnderecoRequest, EnderecoResponse, EnderecoRequest>
    {
        public EnderecoController(IEnderecoService service) : base(service)
        {
        }
    }
}
