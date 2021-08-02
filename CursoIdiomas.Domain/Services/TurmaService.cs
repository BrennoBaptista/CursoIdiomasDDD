using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoIdiomas.Domain.Services
{
    public class TurmaService : BaseService<Turma, Guid>, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaService(ITurmaRepository turmaRepository) 
            : base(turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return _turmaRepository.ObterTurmaPorCodigo(codigoTurma);
        }

        public Turma ObterTurmaPorId(Guid id)
        {
            return _turmaRepository.ObterTurmaPorId(id);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis(IEnumerable<Turma> turmas)
        {
            return _turmaRepository.ObterTurmasComVagasDisponiveis(turmas);
        }

        public bool VerificarSeCodigoExiste(string codigoTurma)
        {
            return _turmaRepository.VerificarSeCodigoExiste(codigoTurma);
        }

        public bool VerificarSeHaAlunosNaTurma(Turma turma)
        {
            return _turmaRepository.VerificarSeHaAlunosNaTurma(turma);
        }

        public bool VerificarSeHaVagasDisponiveis(Turma turma)
        {
            return _turmaRepository.VerificarSeHaVagasDisponiveis(turma);
        }
    }
}
