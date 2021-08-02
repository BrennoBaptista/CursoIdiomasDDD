using CursoIdiomas.Application.Interfaces;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Application
{
    public class TurmaAppService : BaseAppService<Turma,Guid>, ITurmaAppService
    {
        private readonly ITurmaService _turmaService;

        public TurmaAppService(ITurmaService turmaService)
            :base(turmaService)
        {
            _turmaService = turmaService;
        }

        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return _turmaService.ObterTurmaPorCodigo(codigoTurma);
        }

        public Turma ObterTurmaPorId(Guid id)
        {
            return _turmaService.ObterTurmaPorId(id);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis(IEnumerable<Turma> turmas)
        {
            return _turmaService.ObterTurmasComVagasDisponiveis(turmas);
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
    }
}
