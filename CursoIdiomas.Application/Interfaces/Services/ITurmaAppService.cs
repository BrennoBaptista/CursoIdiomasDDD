using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Application.Interfaces.Services
{
    public interface ITurmaAppService : IBaseAppService <Turma, Guid>
    {
        Turma ObterTurmaPorCodigo(string codigoTurma);
        string ObterCodigoPorId(Guid id);
        int ObterNumeroDeVagasDisponiveis(Turma turma);
        bool VerificarSeCodigoExiste(string codigoTurma);
        bool VerificarSeHaVagasDisponiveis(Turma turma);
        bool VerificarSeHaAlunosNaTurma(Turma turma);
        IEnumerable<Turma> ObterTurmasComVagasDisponiveis();
    }
}
