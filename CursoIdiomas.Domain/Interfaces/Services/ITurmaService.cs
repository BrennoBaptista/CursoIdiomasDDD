using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Interfaces.Services
{
    public interface ITurmaService : IBaseService<Turma, Guid>
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
