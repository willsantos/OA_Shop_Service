using AutoMapper;
using Domain.Contracts.Requests;
using Domain.Contracts.Responses;
using Domain.Entities;

namespace Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioCreateRequest>().ReverseMap();
            CreateMap<Usuario,UsuarioResponse>().ReverseMap();
            CreateMap<Curso, CursoResponse>().ReverseMap();
            CreateMap<Curso, CursoCreateRequest>().ReverseMap();
            CreateMap<Curso, CursoEditRequest>().ReverseMap();

        }
    }
}
