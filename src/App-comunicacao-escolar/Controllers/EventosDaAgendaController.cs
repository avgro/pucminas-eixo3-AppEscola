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
    public class EventosDaAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventosDaAgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventosDaAgenda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventosDaAgenda.Include(e => e.Agenda);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventosDaAgenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoDaAgenda = await _context.EventosDaAgenda
                .Include(e => e.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoDaAgenda == null)
            {
                return NotFound();
            }

            return View(eventoDaAgenda);
        }

        // GET: EventosDaAgenda/Create
        public IActionResult Create()
        {
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome");
            return View();
        }

        // POST: EventosDaAgenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,InicioDoEvento,FimDoEvento,AgendaId")] EventoDaAgenda eventoDaAgenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventoDaAgenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", eventoDaAgenda.AgendaId);
            return View(eventoDaAgenda);
        }

        // GET: EventosDaAgenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoDaAgenda = await _context.EventosDaAgenda.FindAsync(id);
            if (eventoDaAgenda == null)
            {
                return NotFound();
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", eventoDaAgenda.AgendaId);
            return View(eventoDaAgenda);
        }

        // POST: EventosDaAgenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,InicioDoEvento,FimDoEvento,AgendaId")] EventoDaAgenda eventoDaAgenda)
        {
            if (id != eventoDaAgenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventoDaAgenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoDaAgendaExists(eventoDaAgenda.Id))
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
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", eventoDaAgenda.AgendaId);
            return View(eventoDaAgenda);
        }

        // GET: EventosDaAgenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoDaAgenda = await _context.EventosDaAgenda
                .Include(e => e.Agenda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoDaAgenda == null)
            {
                return NotFound();
            }

            return View(eventoDaAgenda);
        }

        // POST: EventosDaAgenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventoDaAgenda = await _context.EventosDaAgenda.FindAsync(id);
            _context.EventosDaAgenda.Remove(eventoDaAgenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoDaAgendaExists(int id)
        {
            return _context.EventosDaAgenda.Any(e => e.Id == id);
        }
    }
}
