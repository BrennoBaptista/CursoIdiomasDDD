using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class TurmaRepository : BaseRepository<Turma, Guid>, ITurmaRepository
    {
        public Turma ObterTurmaPorCodigo(string codigoTurma)
        {
            return db.Turmas.Single(t => t.Codigo == codigoTurma);
        }

        public Turma ObterTurmaPorId(Guid id)
        {
            return db.Turmas.Single(t => t.Id == id);
        }

        public IEnumerable<Turma> ObterTurmasComVagasDisponiveis(IEnumerable<Turma> turmas)
        {

            //var resultado = from t in db.Turmas
            //                join a in db.Alunos on t.Id equals a.Turma.Id
            //                select new
            //                {

            //                };

            List<Turma> turmasElegiveis = new List<Turma>();
            foreach (Turma t in turmas)
            {
                if (VerificarSeHaVagasDisponiveis(t))
                    turmasElegiveis.Add(t);
            }
            return turmasElegiveis;

            //testar: opção 1
            //return turmas.Where(t => t.VerificarSeHaVagasDisponiveis(t));
        }

        public bool VerificarSeCodigoExiste(string codigoTurma)
        {
            return ObterTurmaPorCodigo(codigoTurma) != null;
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
