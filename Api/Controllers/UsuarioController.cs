using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult CriarUsuario(UsuarioRequest request)
        {
            _usuarioService.CriarEntidade(request);
            return Ok();
        }

    }
}
