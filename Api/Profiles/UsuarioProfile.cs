using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;

namespace Api.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario,UsuarioResponse>().ReverseMap();
        }
    }
}
