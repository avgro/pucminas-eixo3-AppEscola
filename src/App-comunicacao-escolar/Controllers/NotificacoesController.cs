using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;
using X.PagedList;

namespace App_comunicacao_escolar.Controllers
{
    public class NotificacoesController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public NotificacoesController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Notificacoes
        public async Task<IActionResult> Index(string searchString, int pagina = 1)
        {
            try
            {
                var applicationDbContext = _context.Notificacoes!.Include(n => n.Turma);

                var agendas = from a in applicationDbContext select a;

                agendas = agendas.OrderByDescending(a => a.Id);

                if (searchString != null)
                {
                    agendas = agendas.Where(a => a.Assunto!.Contains(searchString));
                }

                return View(await agendas.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

            // GET: Notificacoes/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .Include(n => n.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // GET: Notificacoes/Create
        public IActionResult Create()
        {
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo");
            return View();
        }

        // POST: Notificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,Conteudo,TurmaId,Perfil")] Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", notificacao.TurmaId);
            return View(notificacao);
        }

        // GET: Notificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", notificacao.TurmaId);
            return View(notificacao);
        }

        // POST: Notificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assunto,Conteudo,TurmaId,Perfil")] Notificacao notificacao)
        {
            if (id != notificacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoExists(notificacao.Id))
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
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", notificacao.TurmaId);
            return View(notificacao);
        }

        // GET: Notificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .Include(n => n.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notificacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notificacoes'  is null.");
            }
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(int id)
        {
          return (_context.Notificacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
