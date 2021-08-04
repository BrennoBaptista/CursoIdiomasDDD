using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Infrastructure.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class TurmaRepository : BaseRepository<Turma, Guid>, ITurmaRepository
    {
        public TurmaRepository()
            :base(new GuidFactory())
        { }

        public string ObterCodigoPorId(Guid id)
        {
            var resultado = db.Turmas.FirstOrDefault(t => t.Id == id);
            return resultado.Codigo;
        }

        public int ObterNumeroDeVagasDisponiveis(Turma turma)
        {
            return 5 - db.Alunos.Where(a => a.Turma.Id == turma.Id).Count();
        }

        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return db.Turmas.FirstOrDefault(t => t.Codigo == codigoTurma);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis()
        {
            var turmas = db.Turmas.ToList();
            List<Turma> turmasElegiveis = new List<Turma>();
            foreach (Turma t in turmas)
            {
                if (VerificarSeHaVagasDisponiveis(t))
                    turmasElegiveis.Add(t);
            }
            return turmasElegiveis;
        }

        public bool VerificarSeCodigoExiste(string codigoTurma)
        {
            return db.Turmas.Where(a => a.Codigo == codigoTurma).Count() != 0;
        }

        public bool VerificarSeHaAlunosNaTurma(Turma turma)
        {
            return db.Alunos.Where(a => a.Turma.Id == turma.Id).Count() != 0;
        }

        public bool VerificarSeHaVagasDisponiveis(Turma turma)
        {
            return db.Alunos.Where(a => a.Turma.Id == turma.Id).Count() < 5;
        }
    }
}
