using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace Service
{
    public class UsuarioService : BaseService<Usuario, UsuarioCreateRequest, UsuarioResponse>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UsuarioResponse CriarUsuario(UsuarioCreateRequest usuarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);
            usuario.Senha = GerarHash(usuario.Senha);
            _repository.CriarEntidade(usuario);
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public UsuarioResponse BuscarUsuarioPorId(Guid id)
        {
            var usuario = _repository.BuscarEntidadePorId(id);
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public IEnumerable<UsuarioResponse> BuscarUsuarios()
        {
            var usuarios = _repository.BuscarEntidades();
            return _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);
        }

        public void DeletarUsuario(Guid id)
        {
            var usuario = _repository.BuscarEntidadePorId(id);
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _repository.DeletarEntidade(usuario);
        }

        public UsuarioResponse EditarUsuario(UsuarioEditRequest usuarioEditRequest, Guid id)
        {
            var usuario = _repository.BuscarEntidadePorId(id);
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            if (!string.IsNullOrEmpty(usuarioEditRequest.Senha))
            {
                usuario.Senha = GerarHash(usuarioEditRequest.Senha);
            }
            if (!string.IsNullOrEmpty(usuarioEditRequest.Nome))
            {
                usuario.Nome = usuarioEditRequest.Nome;
            }
            if (!string.IsNullOrEmpty(usuarioEditRequest.Email))
            {
                usuario.Email = usuarioEditRequest.Email;
            }
            _repository.EditarEntidade(usuario);
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        private string GerarHash(string senha)
        {
            return BC.HashPassword(senha);
        }

        private bool VerificarSenha(string hash, string senhaDigitada)
        {
            return BC.Verify(senhaDigitada, hash);
        }
    }
}
