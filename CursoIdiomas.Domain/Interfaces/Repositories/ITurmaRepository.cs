using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Interfaces.Repositories

{
    public interface ITurmaRepository : IBaseRepository<Turma, Guid>
    {
        Turma ObterTurmaPorCodigo(string codigoTurma);
        Turma ObterTurmaPorId(Guid id);
        bool VerificarSeCodigoExiste(string codigoTurma);
        bool VerificarSeHaVagasDisponiveis(Turma turma);
        bool VerificarSeHaAlunosNaTurma(Turma turma);
        IEnumerable<Turma> ObterTurmasComVagasDisponiveis(IEnumerable<Turma> turmas);
    }
}