using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        public Aluno ObterAlunoPorMatricula(string matricula)
        {
            return _alunoRepository.ObterAlunoPorMatricula(matricula);
        }

        public IQueryable<Aluno> ObterAlunoPorNome(string nome)
        {
            return _alunoRepository.ObterAlunoPorNome(nome);
        }
       
        public bool VerificarSeMatriculaExiste(string matricula)
        {
            return _alunoRepository.VerificarSeMatriculaExiste(matricula);
        }
    }
}
