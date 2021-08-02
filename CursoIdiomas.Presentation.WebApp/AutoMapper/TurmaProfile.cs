using AutoMapper;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Presentation.WebApp.ViewModels;

namespace CursoIdiomas.Presentation.WebApp.AutoMapper
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<Turma, TurmaViewModel>();
            CreateMap<TurmaViewModel, Turma>();
        }
    }
}
