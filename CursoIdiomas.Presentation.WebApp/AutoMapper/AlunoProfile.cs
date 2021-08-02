using AutoMapper;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Presentation.WebApp.ViewModels;

namespace CursoIdiomas.Presentation.WebApp.AutoMapper
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<AlunoViewModel, Aluno>();
        }
    }
}
