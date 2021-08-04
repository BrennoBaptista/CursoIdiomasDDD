using AutoMapper;
using CursoIdiomas.Application.DTO;
using CursoIdiomas.Application.Interfaces.Services;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class TurmaAppService : BaseAppService<Turma,Guid>, ITurmaAppService
    {
        private readonly ITurmaService _turmaService;
        private readonly IMapper _mapper;

        public TurmaAppService(ITurmaService turmaService, IMapper mapper)
            : base(turmaService)
        {
            _turmaService = turmaService;
            _mapper = mapper;
        }

        public TurmaAppService(ITurmaService turmaService)
            : base(turmaService)
        {
            _turmaService = turmaService;
        }

        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return _turmaService.ObterTurmaPorCodigo(codigoTurma);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis()
        {
            return _turmaService.ObterTurmasComVagasDisponiveis();
        }

        public bool VerificarSeCodigoExiste(string codigoTurma)
        {
            return _turmaService.VerificarSeCodigoExiste(codigoTurma);
        }

        public bool VerificarSeHaAlunosNaTurma(Turma turma)
        {
            return _turmaService.VerificarSeHaAlunosNaTurma(turma);
        }

        public bool VerificarSeHaVagasDisponiveis(Turma turma)
        {
            return _turmaService.VerificarSeHaVagasDisponiveis(turma);
        }

        public int ObterNumeroDeVagasDisponiveis(Turma turma)
        {
            return _turmaService.ObterNumeroDeVagasDisponiveis(turma);
        }

        public string ObterCodigoPorId(Guid id)
        {
            return _turmaService.ObterCodigoPorId(id);
        }
    }
}
