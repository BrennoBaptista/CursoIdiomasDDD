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
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}