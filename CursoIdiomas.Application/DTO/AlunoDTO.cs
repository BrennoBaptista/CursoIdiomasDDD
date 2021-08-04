using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoIdiomas.Application.DTO
{
    public class AlunoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Matrícula")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(13, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código da Turma")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Turma")]
        public string CodigoTurma { get; set; }
        public Guid TurmaId { get; set; }
    }
}
