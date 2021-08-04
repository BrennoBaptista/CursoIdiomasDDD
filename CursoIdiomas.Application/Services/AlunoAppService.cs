using CursoIdiomas.Application.Interfaces.Services;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIdiomas.Application.Services
{
    public class AlunoAppService : BaseAppService<Aluno, Guid>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService)
            : base(alunoService)
        {
            _alunoService = alunoService;
        }

        public Aluno ObterAlunoPorMatricula(string matricula)
        {
            return _alunoService.ObterAlunoPorMatricula(matricula);
        }

        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return _alunoService.ObterAlunoPorNome(nome);
        }

        public bool VerificarSeMatriculaExiste(string matricula)
        {
            return _alunoService.VerificarSeMatriculaExiste(matricula);
        }
    }
}