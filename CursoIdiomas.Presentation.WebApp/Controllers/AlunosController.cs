using AutoMapper;
using CursoIdiomas.Application.DTO;
using CursoIdiomas.Application.Interfaces.Services;
using CursoIdiomas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Presentation.WebApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoAppService _alunoAppService;
        private readonly ITurmaAppService _turmaAppService;
        private readonly IMapper _mapper;

        public AlunosController(IAlunoAppService alunoAppService, ITurmaAppService turmaAppService, IMapper mapper)
        {
            _alunoAppService = alunoAppService;
            _turmaAppService = turmaAppService;
            _mapper = mapper;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            try
            {
                var alunos = await _alunoAppService.ReadAllAsync();
                var alunosDTO = _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoDTO>>(alunos);

                foreach (AlunoDTO adto in alunosDTO)
                {
                    adto.CodigoTurma = _turmaAppService.ObterCodigoPorId(adto.TurmaId);
                }
                return View(alunosDTO);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var aluno = await _alunoAppService.ReadAsync(id);
                if (aluno == null)
                    return NotFound();

                var alunoDTO = _mapper.Map<Aluno, AlunoDTO>(aluno);

                var turma = await _turmaAppService.ReadAsync(aluno.TurmaId);
                alunoDTO.CodigoTurma = turma.Codigo;

                return View(alunoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula, Nome, Sobrenome, Telefone, Email, Endereco, CodigoTurma")] AlunoDTO alunoDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _mapper.Map<AlunoDTO, Aluno>(alunoDTO);
                    if (!_alunoAppService.VerificarSeMatriculaExiste(aluno.Matricula))
                    {
                        var turma = _turmaAppService.ObterTurmaPorCodigo(alunoDTO.CodigoTurma);
                        if (turma == null)
                            return NotFound("Falha: O código de turma informado não existe."); //substituir por mostrar uma mensagem na tela

                        if (!_turmaAppService.VerificarSeHaVagasDisponiveis(turma))
                            return BadRequest("Falha: Não há vagas disponíveis nesta turma"); //substituir por mostrar uma mensagem na tela

                        aluno.TurmaId = turma.Id;
                        await _alunoAppService.CreateAsync(aluno);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return BadRequest("Falha: Esta matrícula já existe"); //substituir por mostrar uma mensagem na tela
                    }
                }
                return View(alunoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var aluno = await _alunoAppService.ReadAsync(id);
                if (aluno == null)
                    return NotFound();

                var alunoDTO = _mapper.Map<Aluno, AlunoDTO>(aluno);

                var turma = await _turmaAppService.ReadAsync(aluno.TurmaId);
                alunoDTO.CodigoTurma = turma.Codigo;

                return View(alunoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: Alunos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, AlunoDTO alunoDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _mapper.Map<AlunoDTO, Aluno>(alunoDTO);
                    var turma = _turmaAppService.ObterTurmaPorCodigo(alunoDTO.CodigoTurma);

                    if (turma != null)
                    {
                        if (aluno.TurmaId == turma.Id)
                        {
                            _alunoAppService.Update(aluno);
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            if (!_turmaAppService.VerificarSeHaVagasDisponiveis(turma))
                                return BadRequest("Falha: Não há vagas disponíveis nesta turma"); //Substituir por mostrar uma mensagem na tela

                            aluno.Turma = turma;
                            aluno.TurmaId = turma.Id;
                            _alunoAppService.Update(aluno);
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        return NotFound("Falha: O código de turma informado não existe."); //Substituir por mostrar uma mensagem na tela
                    }

                }
                return View(alunoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var aluno = await _alunoAppService.ReadAsync(id);
                var alunoDTO = _mapper.Map<Aluno, AlunoDTO>(aluno);

                var turma = await _turmaAppService.ReadAsync(aluno.TurmaId);
                alunoDTO.CodigoTurma = turma.Codigo;

                return View(alunoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _alunoAppService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}