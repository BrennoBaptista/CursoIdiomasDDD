using AutoMapper;
using CursoIdiomas.Application.DTO;
using CursoIdiomas.Domain.Entities;

namespace CursoIdiomas.Presentation.WebApp.AutoMapper
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoDTO, Aluno>()
                .ForMember(destino => destino.Id, origem => origem.MapFrom(x => x.Id))
                .ForMember(destino => destino.TurmaId, origem => origem.MapFrom(x => x.TurmaId))
                .ForMember(destino => destino.DataCriacao, origem => origem.Ignore())
                .ForMember(destino => destino.DataModificacao, origem => origem.Ignore())
                .ForMember(destino => destino.Matricula, origem => origem.MapFrom(x => x.Matricula))
                .ForMember(destino => destino.Nome, origem => origem.MapFrom(x => x.Nome))
                .ForMember(destino => destino.Sobrenome, origem => origem.MapFrom(x => x.Sobrenome))
                .ForMember(destino => destino.Telefone, origem => origem.MapFrom(x => x.Telefone))
                .ForMember(destino => destino.Email, origem => origem.MapFrom(x => x.Email))
                .ForMember(destino => destino.Endereco, origem => origem.MapFrom(x => x.Endereco))
                .ForMember(destino => destino.Turma, origem => origem.Ignore());

            CreateMap<Aluno, AlunoDTO>()
                .ForMember(destino => destino.Id, origem => origem.MapFrom(x => x.Id))
                .ForMember(destino => destino.TurmaId, origem => origem.MapFrom(x => x.TurmaId))
                .ForMember(destino => destino.Matricula, origem => origem.MapFrom(x => x.Matricula))
                .ForMember(destino => destino.Nome, origem => origem.MapFrom(x => x.Nome))
                .ForMember(destino => destino.Sobrenome, origem => origem.MapFrom(x => x.Sobrenome))
                .ForMember(destino => destino.Telefone, origem => origem.MapFrom(x => x.Telefone))
                .ForMember(destino => destino.Email, origem => origem.MapFrom(x => x.Email))
                .ForMember(destino => destino.Endereco, origem => origem.MapFrom(x => x.Endereco))
                .ForMember(destino => destino.CodigoTurma, origem => origem.Ignore());
        }
    }
}