using CursoIdiomas.Domain.Entities;
using System;
using System.Linq;

namespace CursoIdiomas.Application.Interfaces
{
    public interface IAlunoAppService : IBaseAppService<Aluno,Guid>
    {
        IQueryable<Aluno> ObterAlunoPorNome(string nome);
    }
}
