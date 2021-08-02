using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Domain.ValueObjects
{
    public class Endereco
    {
        public Endereco(string cep, string logradouro, string bairro, string cidade, string estado, string lote, string complemento)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Lote = lote;
            Complemento = complemento;
        }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Lote { get; set; }
        public string Complemento { get; set; }
    }
}
