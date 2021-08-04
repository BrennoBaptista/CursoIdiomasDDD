using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Domain.Interfaces.Services
{
    public interface IAlunoService : IBaseService<Aluno, Guid>
    {
        IQueryable<Aluno> ObterAlunoPorNome(string nome);
        Aluno ObterAlunoPorMatricula(string matricula);
        bool VerificarSeMatriculaExiste(string matricula);
    }
}
