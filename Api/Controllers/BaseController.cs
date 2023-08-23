using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TRequest, TResponse, TEditRequest> : ControllerBase 
        where TRequest : BaseRequest
        where TResponse : BaseResponse
        where TEditRequest : BaseRequest
    {
        private readonly IBaseService<TRequest, TResponse, TEditRequest> _service;

        public BaseController(IBaseService<TRequest, TResponse, TEditRequest> service)
        {
            _service = service;
        }
        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns>Lista com todos os registros encontrados.</returns>
        /// <response code="200">Lista de registros.</response>
        [HttpGet]
        public ActionResult<IEnumerable<TResponse>> ObterTodos()
        {
            var response = _service.ObterTodos();
            return Ok(response);
        }

        /// <summary>
        /// Adicionar um registro no banco.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        /// <response code="200">Registro adicionado.</response>
        /// <response code="400">Registro não adicionado.</response>
        [HttpPost]
        public ActionResult<TResponse> Adicionar(TRequest createRequest)
        {
            try
            {
                var id = _service.Adicionar(createRequest);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Buscar um registro no banco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Registro encontrado.</response>
        /// <response code="404">Registro não encontrado.</response>

        [HttpGet("{id}")]
        public ActionResult<TResponse> BuscarPorId(Guid id)
        {
            var response = _service.BuscarEntidadePorId(id);
            return response != null ?  Ok(response) : NotFound();
        }

        /// <summary>
        /// Deletar um registro no banco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Registro deletado.</response>
        /// <response code="400">Registro não deletado.</response>
        [HttpDelete]
        public ActionResult Deletar(Guid id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar um registro no banco.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editRequest"></param>
        /// <returns></returns>
        /// <response code="200">Registro alterado.</response>
        /// <response code="400">Registro não alterado.</response>

        [HttpPatch]
        public ActionResult Alterar(TEditRequest editRequest, Guid id)
        {
            try
            {
                _service.Alterar(editRequest, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
