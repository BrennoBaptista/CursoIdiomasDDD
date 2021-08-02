using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Domain.Entities
{
    public abstract class EntidadeBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
