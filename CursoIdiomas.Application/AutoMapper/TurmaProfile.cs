using AutoMapper;
using CursoIdiomas.Application.DTO;
using CursoIdiomas.Domain.Entities;

namespace CursoIdiomas.Presentation.WebApp.AutoMapper
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            TurmaMap();
        }

        private void TurmaMap()
        {
            CreateMap<TurmaDTO, Turma>()
                .ForMember(destino => destino.Id, origem => origem.MapFrom(x => x.Id))
                .ForMember(destino => destino.DataCriacao, origem => origem.Ignore())
                .ForMember(destino => destino.DataModificacao, origem => origem.Ignore())
                .ForMember(destino => destino.Codigo, origem => origem.MapFrom(x => x.Codigo))
                .ForMember(destino => destino.Idioma, origem => origem.MapFrom(x => x.Idioma))
                .ForMember(destino => destino.Alunos, origem => origem.MapFrom(x => x.Alunos));

            CreateMap<Turma, TurmaDTO>()
                .ForMember(destino => destino.Id, origem => origem.MapFrom(x => x.Id))
                .ForMember(destino => destino.Codigo, origem => origem.MapFrom(x => x.Codigo))
                .ForMember(destino => destino.Idioma, origem => origem.MapFrom(x => x.Idioma))
                .ForMember(destino => destino.Alunos, origem => origem.MapFrom(x => x.Alunos));
        }
    }
}
