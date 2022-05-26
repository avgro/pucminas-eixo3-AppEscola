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
        public async Task<IActionResult> Index(int? id)
        {
            var applicationDbContext = _context.EventosDaAgenda.Include(e => e.Agenda);

            string agendaNome = "Todas as agendas";
            ViewData["Id"] = id;
            if (id != null) {
                agendaNome = _context.Agendas.FirstOrDefault(a => a.Id == id).Nome;
                ViewData["AgendaNome"] = agendaNome;
                return View(await applicationDbContext.Where(a => a.AgendaId == id).OrderBy(a => a.InicioDoEvento).ToListAsync());
            }
            ViewData["AgendaNome"] = agendaNome;
            return View(await applicationDbContext.OrderBy(a => a.InicioDoEvento).ToListAsync());
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
            @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
            return View(eventoDaAgenda);
        }

        // GET: EventosDaAgenda/Create
        public IActionResult Create(int? id)
        {
            var agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome), "Id", "Nome");

            string agendaNome = "Todas as agendas";
            if (id != null)
            {
                agendaNome = _context.Agendas.FirstOrDefault(a => a.Id == id).Nome;

                var agendaSelected = agendaSelectList.Where(a => a.Text == agendaNome).First();
                agendaSelected.Selected = true;
            }

            ViewData["AgendaId"] = agendaSelectList;
            ViewData["AgendaNome"] = agendaNome;
            ViewData["Id"] = id;
            return View();
        }

        // POST: EventosDaAgenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgenda)
        {
            eventoDaAgenda.Id = 0;

            List<string> listarErrosDeValidacao = IsValidCustomizado(eventoDaAgenda);
            while (listarErrosDeValidacao.Count > 0)
            {
                ViewData["Error"] = "Error";
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                listarErrosDeValidacao.RemoveRange(0, 2);
            }

            if (ModelState.IsValid)
            {
                _context.Add(eventoDaAgenda);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Agendas", action = "Visualizar", id = eventoDaAgenda.AgendaId });
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
            @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
            return View(eventoDaAgenda);
        }

        // POST: EventosDaAgenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgenda)
        {
            if (id != eventoDaAgenda.Id)
            {
                return NotFound();
            }

            List<string> listarErrosDeValidacao = IsValidCustomizado(eventoDaAgenda);
            while (listarErrosDeValidacao.Count > 0)
            {
                ViewData["Error"] = "Error";
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                listarErrosDeValidacao.RemoveRange(0, 2);
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
                return RedirectToRoute(new { controller = "Agendas", action = "Visualizar", id = eventoDaAgenda.AgendaId });
            }
            ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", eventoDaAgenda.AgendaId);
            @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
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
            @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
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
            @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
            return RedirectToRoute(new { controller = "Agendas", action = "Visualizar", id = eventoDaAgenda.AgendaId });
        }

        private bool EventoDaAgendaExists(int id)
        {
            return _context.EventosDaAgenda.Any(e => e.Id == id);
        }

        // Metodos - Validação de atributos cuja validação não é diretamente coberta pelo Entity Framework
        private List<string> IsValidCustomizado(EventoDaAgenda eventoDaAgenda)
        {
            List<string> errorMessage = new();
            DateTime inicioEvento = (DateTime) eventoDaAgenda.InicioDoEvento;
            DateTime fimEvento = (DateTime) eventoDaAgenda.FimDoEvento;

            if (!(inicioEvento.Day == fimEvento.Day && inicioEvento.Month == fimEvento.Month && inicioEvento.Year == fimEvento.Year))
            {
                errorMessage.Add("FimDoEvento");
                errorMessage.Add("Evento deve começar e terminar no mesmo dia!");
            };

            if (inicioEvento >= fimEvento)
            {
                errorMessage.Add("FimDoEvento");
                errorMessage.Add("Fim do evento deve ocorrer após o início do evento!");
            };
            return errorMessage;
        }
    }
}
