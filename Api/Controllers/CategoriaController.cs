using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController<CategoriaRequest, CategoriaResponse, CategoriaRequest>
    {
        public CategoriaController(ICategoriaService service) : base(service)
        {
        }
    }
}
