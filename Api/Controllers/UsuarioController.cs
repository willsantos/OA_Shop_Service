using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<UsuarioCreateRequest,UsuarioResponse,UsuarioEditRequest>
    {
        public UsuarioController(IUsuarioService usuarioService) : base(usuarioService)
        {
        }
    }
}
