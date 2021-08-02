using CursoIdiomas.Application.Interfaces;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Linq;

namespace CursoIdiomas.Application
{
    public class AlunoAppService : BaseAppService<Aluno, Guid>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService)
            : base(alunoService)
        {
            _alunoService = alunoService;
        }

        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return _alunoService.ObterAlunoPorNome(nome);
        }
    }
}