using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Application.Interfaces.Services
{
    public interface IAlunoAppService : IBaseAppService<Aluno,Guid>
    {
        IQueryable<Aluno> ObterAlunoPorNome(string nome);
        Aluno ObterAlunoPorMatricula(string matricula);
        bool VerificarSeMatriculaExiste(string matricula);
    }
}
