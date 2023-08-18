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
            CreateMap<Curso, CursoResponse>().ForMember(c => c.Categorias, src => src.MapFrom(s => s.CursoCategoria.Select(x => x.CategoriaId)));
            CreateMap<Curso, CursoCreateRequest>().ReverseMap();
            CreateMap<Curso, CursoEditRequest>().ReverseMap();
            CreateMap<Categoria, CategoriaResponse>().ForMember(c => c.Cursos, src => src.MapFrom(s => s.CursoCategoria.Select(x => x.CursoId)));
            CreateMap<Categoria,CategoriaRequest>().ReverseMap();
            CreateMap<Transacao, TransacaoResponse>().ReverseMap();
            CreateMap<Transacao, TransacaoRequest>().ReverseMap();
            CreateMap<Assinatura,AssinaturaRequest>().ReverseMap();
            CreateMap<Assinatura,AssinaturaResponse>().ReverseMap();
        }
    }
}
