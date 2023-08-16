using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
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
        public ActionResult<UsuarioResponse> CriarUsuario(UsuarioCreateRequest request)
        {
            var usuarioResponse = _usuarioService.CriarUsuario(request);
            return Ok(usuarioResponse);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UsuarioResponse> BuscarUsuarioPorId(Guid id)
        {
            var usuario = _usuarioService.BuscarUsuarioPorId(id);
            return usuario != null ? Ok(usuario) : NotFound();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<UsuarioResponse> EditarUsuario(UsuarioEditRequest usuarioEditRequest, Guid id)
        {
            var usuarioEditado = _usuarioService.EditarUsuario(usuarioEditRequest, id);
            return Ok(usuarioEditado);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioResponse>> BuscarUsuarios()
        {
            var usuarios = _usuarioService.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarUsuario(Guid id)
        {
            _usuarioService.DeletarUsuario(id);
            return NoContent();
        }

    }
}
