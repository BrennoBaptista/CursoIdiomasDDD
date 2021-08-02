using CursoIdiomas.Domain.Entities.ValueObjects;
using CursoIdiomas.Domain.ValueObjects;
using System;

namespace CursoIdiomas.Domain.Entities
{
    public class Aluno : EntidadeBase<Guid>
    {
        public Aluno()
        {}

        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public bool MatriculaAtiva { get; set; }
        public Turma Turma { get; set; }

    }
}