using AutoMapper;
using CursoIdiomas.Application.Interfaces;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Presentation.WebApp.ViewModels;
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
        public async Task<ActionResult> Index()
        {
            var turmas = await _turmaAppService.ReadAllAsync();
            var turmaViewModel = _mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaViewModel>>(turmas);
            return View(turmaViewModel);
        }

        // GET: Turmas/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var turma = await _turmaAppService.ReadAsync(id);
            if (turma == null)
                return NotFound();

            var turmaViewModel = _mapper.Map<Turma, TurmaViewModel>(turma);

            return View(turmaViewModel);
        }

        // GET: Turmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TurmaViewModel turmaViewModel)
        {
            if (ModelState.IsValid)
            {
                var turma = _mapper.Map<TurmaViewModel, Turma>(turmaViewModel);
                
                if (!_turmaAppService.VerificarSeCodigoExiste(turma.Codigo))
                {
                    await _turmaAppService.CreateAsync(turma);
                    //mensagem cadastro ok
                }
                else
                {
                    //mensagem falha
                }

                return RedirectToAction(nameof(Index));
            }

            return View(turmaViewModel);
        }

        // GET: Turmas/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var turma = await _turmaAppService.ReadAsync(id);
            if (turma == null)
                return NotFound();

            var turmaViewModel = _mapper.Map<Turma, TurmaViewModel>(turma);
            return View(turmaViewModel);
        }

        // POST: Turmas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid Id, TurmaViewModel turmaViewModel)
        {
            if (ModelState.IsValid)
            {
                var turma = _mapper.Map<TurmaViewModel, Turma>(turmaViewModel);
                _turmaAppService.Update(turma);
                return RedirectToAction(nameof(Index));
            }

            return View(turmaViewModel);
        }

        // GET: Turmas/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var turma = await _turmaAppService.ReadAsync(id);
            var turmaViewModel = _mapper.Map<Turma, TurmaViewModel>(turma);

            return View(turmaViewModel);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            if (!_turmaAppService.VerificarSeHaAlunosNaTurma(_turmaAppService.ObterTurmaPorId(id)))
            {
                await _turmaAppService.DeleteAsync(id);
                //mensagem cadastro ok
            }
            else
            {
                //mensagem falha
            }

            return RedirectToAction(nameof(Index));
        }
    }
}