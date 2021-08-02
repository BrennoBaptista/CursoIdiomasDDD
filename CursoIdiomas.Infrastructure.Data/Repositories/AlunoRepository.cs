using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno, Guid>, IAlunoRepository
    {
        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return db.Alunos.Where(p => p.Nome == nome);
        }
    }
}
