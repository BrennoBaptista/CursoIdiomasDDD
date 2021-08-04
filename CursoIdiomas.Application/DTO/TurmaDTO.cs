using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Application.DTO
{
    public class TurmaDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Idioma")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Idioma { get; set; }

        [DisplayName("Vagas Disponíveis")]
        public int VagasDisponiveis { get; set; }

        public ICollection<AlunoDTO> Alunos { get; set; }
    }
}
