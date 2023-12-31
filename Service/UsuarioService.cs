﻿using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace Service
{
    public class UsuarioService : BaseService<Usuario, UsuarioCreateRequest, UsuarioResponse, UsuarioEditRequest>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override Guid Adicionar(UsuarioCreateRequest request)
        {
            var usuarioCreateRequest = request as UsuarioCreateRequest;
            var usuario = _mapper.Map<Usuario>(usuarioCreateRequest);
            usuario.Senha = GerarHash(usuario.Senha);
            _repository.CriarEntidade(usuario);
            return usuario.Id; 
        }

        public override void Alterar(UsuarioEditRequest request, Guid id)
        {
            var usuario = _repository.BuscarEntidadePorId(id);
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            if (!string.IsNullOrEmpty(request.Senha))
            {
                usuario.Senha = GerarHash(request.Senha);
            }
            if (!string.IsNullOrEmpty(request.Nome))
            {
                usuario.Nome = request.Nome;
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                usuario.Email = request.Email;
            }
            _repository.EditarEntidade(usuario);
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
