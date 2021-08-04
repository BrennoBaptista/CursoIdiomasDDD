using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno, Guid>
    {
        IQueryable<Aluno> ObterAlunoPorNome(string nome);
        Aluno ObterAlunoPorMatricula(string matricula);
        bool VerificarSeMatriculaExiste(string matricula);
    }
}
