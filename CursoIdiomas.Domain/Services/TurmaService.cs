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

        public string ObterCodigoPorId(Guid id)
        {
            return _turmaRepository.ObterCodigoPorId(id);
        }

        public int ObterNumeroDeVagasDisponiveis(Turma turma)
        {
            return _turmaRepository.ObterNumeroDeVagasDisponiveis(turma);
        }

        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return _turmaRepository.ObterTurmaPorCodigo(codigoTurma);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis()
        {
            return _turmaRepository.ObterTurmasComVagasDisponiveis();
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
