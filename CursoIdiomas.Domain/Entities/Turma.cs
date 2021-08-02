using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities
{
    public class Turma : EntidadeBase<Guid>
    {
        public Turma()
        { }

        public string Codigo { get; set; }
        public string Idioma { get; set; }
        public ICollection<Aluno> Alunos { get; set; }

        //testar: opção 1
        //public bool VerificarSeHaVagasDisponiveis(Turma turma)
        //{
        //    return turma.Alunos.Count < 5;
        //}
    }
}