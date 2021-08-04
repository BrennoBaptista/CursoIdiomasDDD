using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Infrastructure.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno, Guid>, IAlunoRepository
    {
        public AlunoRepository()
            : base(new GuidFactory())
        { }

        public Aluno ObterAlunoPorMatricula(string matricula)
        {
            return db.Alunos.FirstOrDefault(t => t.Matricula == matricula);
        }

        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return db.Alunos.Where(p => p.Nome == nome);
        }

        public bool VerificarSeMatriculaExiste(string matricula)
        {
            return db.Alunos.Where(a => a.Matricula == matricula).Count() != 0;
        }
    }
}
