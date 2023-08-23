using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : BaseController<CursoCreateRequest, CursoResponse,CursoEditRequest>
    {
        public CursoController(ICursoService service) : base(service)
        {
        }
    }
}
