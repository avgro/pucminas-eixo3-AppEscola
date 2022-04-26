#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;

namespace App_comunicacao_escolar.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turmas.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codigo,NomeComCodigoEntreParenteses")] Turma turma)
        {
            turma.NomeComCodigoEntreParenteses = turma.Nome + " (" + turma.Codigo + ")";
            
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "NomeComCodigoEntreParenteses");
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codigo,NomeComCodigoEntreParenteses")] Turma turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            turma.NomeComCodigoEntreParenteses = turma.Nome + " (" + turma.Codigo + ")";
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(turma);
        }


        // GET: Turmas/AdicionarDisciplinas/5
        public async Task<IActionResult> AdicionarDisciplinas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.Include(t => t.Disciplinas).ThenInclude(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(t => t.Id == id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "NomeComCodigoEntreParenteses");
            return View(turma);
        }

        // POST: Turmas/AdicionarDisciplinas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarDisciplinas(int id, [Bind("Id,Nome,Codigo,NomeComCodigoEntreParenteses")] Turma turma, 
            [Bind("adicionarDisciplinasList")] string adicionarDisciplinasList,
            [Bind("adicionarOuRemover")] string adicionarOuRemover)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            turma.NomeComCodigoEntreParenteses = turma.Nome + " (" + turma.Codigo + ")";

            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "NomeComCodigoEntreParenteses");

            Disciplina disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == Int32.Parse(adicionarDisciplinasList));
            if (disciplina.TurmaId != null && adicionarOuRemover.Equals("adicionar"))
            {
                ModelState.AddModelError("Disciplinas", "Disciplina já associada a uma turma!");
            }
            if (ModelState.IsValid)
            {
                try
                {     
                    if (turma.Disciplinas == null)
                    {
                        turma.Disciplinas = new List<Disciplina>();
                    }
                    if (adicionarOuRemover.Equals("adicionar")) { 
                        turma.Disciplinas.Add(disciplina);
                    }
                    else if (adicionarOuRemover.Equals("remover"))
                    {
                        disciplina.TurmaId = null;
                        _context.Update(disciplina);
                    }
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdicionarDisciplinas));
            }
            turma = await _context.Turmas.Include(t => t.Disciplinas).ThenInclude(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(t => t.Id == id);
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.Id == id);
        }
    }
}
