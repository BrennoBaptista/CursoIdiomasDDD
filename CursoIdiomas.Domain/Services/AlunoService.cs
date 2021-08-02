using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace CursoIdiomas.Domain.Services
{
    public class AlunoService : BaseService<Aluno, Guid>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository)
            : base(alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return _alunoRepository.ObterAlunoPorNome(nome);
        }
    }
}
