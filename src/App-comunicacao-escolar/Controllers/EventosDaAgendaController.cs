#nullable disable
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
    public class EventosDaAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventosDaAgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventosDaAgenda
        public async Task<IActionResult> Index(int? id, string searchString, int pagina = 1)
        {
            try
            {
                var applicationDbContext = _context.EventosDaAgenda.Include(e => e.Agenda);

                var eventosAgenda = from e in applicationDbContext select e;

                string agendaNome = "Todas as agendas";
                ViewData["Id"] = id;
                if (id != null)
                {
                    agendaNome = _context.Agendas.FirstOrDefault(a => a.Id == id).Nome;
                    eventosAgenda = eventosAgenda.Where(a => a.AgendaId == id);
                }
                ViewData["AgendaNome"] = agendaNome;

                if (searchString != null)
                {
                    eventosAgenda = eventosAgenda.Where(e => e.Nome.Contains(searchString));
                }

                eventosAgenda.OrderBy(a => a.InicioDoEvento);

                return View(await eventosAgenda.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EventosDaAgenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var eventoDaAgenda = await _context.EventosDaAgenda
                    .Include(e => e.Agenda)
                    .Include(e => e.Autorizacoes).ThenInclude(a => a.Aluno)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (eventoDaAgenda == null)
                {
                    return NotFound();
                }
                @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
                return View(eventoDaAgenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EventosDaAgenda/Create
        public IActionResult Create(int? id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
        }

        // POST: EventosDaAgenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgenda)
        {
            try
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
                    if (eventoDaAgenda.RequerAutorizacao == true)
                    {
                        var alunos = _context.Alunos;
                        var selecionarAlunos = from a in alunos select a;
                        int? turmaDaAgendaId = _context.Agendas.FirstOrDefault(a => a.Id == eventoDaAgenda.AgendaId)?.TurmaId;
                        if (turmaDaAgendaId != null)
                        {
                            selecionarAlunos = selecionarAlunos.Where(a => a.TurmaId == turmaDaAgendaId);
                        }
                        eventoDaAgenda.Autorizacoes = new List<AutorizacaoEvento>();
                        foreach (var aluno in selecionarAlunos)
                        {
                            var autorizacaoEvento = new AutorizacaoEvento();
                            autorizacaoEvento.AlunoId = aluno.Id;
                            _context.Add(autorizacaoEvento);
                            eventoDaAgenda.Autorizacoes.Add(autorizacaoEvento);
                        }
                    }
                    _context.Add(eventoDaAgenda);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute(new { controller = "Agendas", action = "Visualizar", id = eventoDaAgenda.AgendaId });
                }

                ViewData["AgendaId"] = new SelectList(_context.Agendas, "Id", "Nome", eventoDaAgenda.AgendaId);
                return View(eventoDaAgenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EventosDaAgenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
        }

        // POST: EventosDaAgenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgendaNovasInformacoes)
        {
            try
            {
                if (id != eventoDaAgendaNovasInformacoes.Id)
                {
                    return NotFound();
                }

                var eventoDaAgenda = await _context.EventosDaAgenda.FirstOrDefaultAsync(e => e.Id == id);

                eventoDaAgenda.Nome = eventoDaAgendaNovasInformacoes.Nome;
                eventoDaAgenda.InicioDoEvento = eventoDaAgendaNovasInformacoes.InicioDoEvento;
                eventoDaAgenda.FimDoEvento = eventoDaAgendaNovasInformacoes.FimDoEvento;

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
            catch
            {
                return BadRequest();
            }
        }

        // GET: EventosDaAgenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch
            {
                return BadRequest();
            }
        }

        // POST: EventosDaAgenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var eventoDaAgenda = await _context.EventosDaAgenda.FindAsync(id);
                _context.EventosDaAgenda.Remove(eventoDaAgenda);
                await _context.SaveChangesAsync();
                @ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
                return RedirectToRoute(new { controller = "Agendas", action = "Visualizar", id = eventoDaAgenda.AgendaId });
            }
            catch
            {
                return BadRequest();
            }
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
