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
    public class TurmasController : Controller
    {
        private readonly ITurmaAppService _turmaAppService;
        private readonly IMapper _mapper;

        public TurmasController(ITurmaAppService turmaAppService, IMapper mapper)
        {
            _turmaAppService = turmaAppService;
            _mapper = mapper;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            try
            {
                var turmas = await _turmaAppService.ReadAllAsync();
                var turmasDTO = _mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaDTO>>(turmas);
                return View(turmasDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Turmas com vagas disponiveis
        public IActionResult TurmasComVagasDisponiveis()
        {
            try
            {
                var turmas = _turmaAppService.ObterTurmasComVagasDisponiveis();
                var turmasDTO = _mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaDTO>>(turmas);

                foreach (TurmaDTO tdto in turmasDTO)
                {
                    tdto.VagasDisponiveis = _turmaAppService.ObterNumeroDeVagasDisponiveis(_mapper.Map<TurmaDTO, Turma>(tdto));
                }

                return View(turmasDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var turma = await _turmaAppService.ReadAsync(id);
                if (turma == null)
                    return NotFound();

                var turmaDTO = _mapper.Map<Turma, TurmaDTO>(turma);
                turmaDTO.VagasDisponiveis = _turmaAppService.ObterNumeroDeVagasDisponiveis(turma);
                return View(turmaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo, Idioma")] TurmaDTO turmaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var turma = _mapper.Map<TurmaDTO, Turma>(turmaDTO);

                    if (!_turmaAppService.VerificarSeCodigoExiste(turma.Codigo))
                    {
                        await _turmaAppService.CreateAsync(turma);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return BadRequest("Falha: Este código de turma já existe"); //substituir por mostrar uma mensagem na tela
                    }
                }
                return View(turmaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        


        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var turma = await _turmaAppService.ReadAsync(id);
                if (turma == null)
                    return NotFound();

                var turmaDTO = _mapper.Map<Turma, TurmaDTO>(turma);
                return View(turmaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: Turmas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, TurmaDTO turmaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var turma = _mapper.Map<TurmaDTO, Turma>(turmaDTO);
                    _turmaAppService.Update(turma);
                    return RedirectToAction(nameof(Index));
                }
                return View(turmaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var turma = await _turmaAppService.ReadAsync(id);
                var turmaDTO = _mapper.Map<Turma, TurmaDTO>(turma);
                return View(turmaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                if (!_turmaAppService.VerificarSeHaAlunosNaTurma(await _turmaAppService.ReadAsync(id)))
                {
                    await _turmaAppService.DeleteAsync(id);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest("Falha: Existem alunos nesta turma"); //substituir por mostrar uma mensagem na tela
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}