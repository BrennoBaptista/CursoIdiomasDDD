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

        // GET: AlunosController
        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoAppService.ReadAllAsync();
            var alunoViewModel = _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoViewModel>>(alunos);
            return View(alunoViewModel);
        }

        // GET: AlunosController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var aluno = await _alunoAppService.ReadAsync(id);
            if (aluno == null)
                return NotFound();

            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(aluno);

            return View(alunoViewModel);
        }

        // GET: AlunosController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel alunoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);
                    await _alunoAppService.CreateAsync(aluno);
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(alunoViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var aluno = await _alunoAppService.ReadAsync(id);
            if (aluno == null)
                return NotFound();

            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(aluno);
            return View(alunoViewModel);
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid Id, AlunoViewModel alunoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var aluno = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel);
                    _alunoAppService.Update(aluno);
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(alunoViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var aluno = await _alunoAppService.ReadAsync(id);
            var alunoViewModel = _mapper.Map<Aluno, AlunoViewModel>(aluno);

            return View(alunoViewModel);
        }

        // POST: AlunosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _alunoAppService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}