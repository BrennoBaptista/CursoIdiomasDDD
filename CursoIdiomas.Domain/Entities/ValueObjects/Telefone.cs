using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Domain.Entities.ValueObjects
{
    public class Telefone
    {
        public Telefone(string residencial, string celular)
        {
            Residencial = residencial;
            Celular = celular;
        }

        public string Residencial { get; set; }
        public string Celular { get; set; }
    }
}
