using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : BaseController<AssinaturaRequest, AssinaturaResponse, AssinaturaRequest>
    {
        public AssinaturaController(IAssinaturaService service) : base(service)
        {
        }
    }
}
