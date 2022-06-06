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
using Microsoft.AspNetCore.Authorization;

namespace App_comunicacao_escolar.Controllers
{
    [Authorize]
    public class EventosDaAgendaController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public EventosDaAgendaController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: EventosDaAgenda
        [Authorize(Roles = "Admin, Professor")]
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
                
                if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());
                    eventosAgenda = eventosAgenda.Where(e =>
                            (idAgendasSelecionadas.Contains((int)e.Agenda.TurmaId) || e.Agenda == null)
                            &&
                            ((int)e.Agenda.Perfil == 0 || (int)e.Agenda.Perfil == 2 || e.Agenda == null)
                            );
                }

                eventosAgenda.OrderBy(a => a.InicioDoEvento);
                ViewBag.IdUsuarioLogado = GetIdUsuarioLogado();

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
            try { 
                if (id == null)
                {
                    return NotFound();
                }

                var eventoDaAgenda = await _context.EventosDaAgenda
                    .Include(e => e.Agenda)
                    .Include(e => e.Autorizacoes).ThenInclude(a => a.Aluno)
                    .Include(e => e.Usuario)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (eventoDaAgenda == null)
                {
                    return NotFound();
                }

                if (UsuarioNaoPossuiAcessoEsteEvento(eventoDaAgenda))
                {
                    return Forbid();
                }

                ViewData["IdVoltarAgenda"] = eventoDaAgenda.AgendaId;
                ViewBag.IdUsuarioLogado = GetIdUsuarioLogado();
                return View(eventoDaAgenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EventosDaAgenda/Create
        [Authorize(Roles = "Admin, Professor")]
        public IActionResult Create(int? id)
        {
            try
            {
                var agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome), "Id", "Nome");
               
                if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());
                    agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome).Where(a => idAgendasSelecionadas.Contains((int)a.TurmaId)), "Id", "Nome");
                }

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
        [Authorize(Roles = "Admin, Professor")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgenda)
        {
            try
            {
                eventoDaAgenda.Id = 0;

                eventoDaAgenda.IdUsuarioQueCadastrouEvento = GetIdUsuarioLogado();

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
        [Authorize(Roles = "Admin, Professor")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var eventoDaAgenda = await _context.EventosDaAgenda.FindAsync(id);
                var agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome), "Id", "Nome");

                if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());
                    agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome).Where(a => idAgendasSelecionadas.Contains((int)a.TurmaId)), "Id", "Nome");
                }

                string agendaNome = "Todas as agendas";
                if (eventoDaAgenda.AgendaId != null)
                {
                    agendaNome = _context.Agendas.FirstOrDefault(a => a.Id == eventoDaAgenda.AgendaId).Nome;

                    var agendaSelected = agendaSelectList.Where(a => a.Text == agendaNome).First();
                    agendaSelected.Selected = true;
                }

                if (eventoDaAgenda == null)
                {
                    return NotFound();
                }

                if (UsuarioNaoPossuiAcessoEsteEvento(eventoDaAgenda))
                {
                    return Forbid();
                }

                if (UsuarioNaoPodeEditarEvento(eventoDaAgenda))
                {
                    return Forbid();
                }

                ViewData["AgendaId"] = agendaSelectList;
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
        [Authorize(Roles = "Admin, Professor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,InicioDoEvento,FimDoEvento,AgendaId,RequerAutorizacao")] EventoDaAgenda eventoDaAgendaNovasInformacoes)
        {
            try { 
                if (id != eventoDaAgendaNovasInformacoes.Id)
                {
                    return NotFound();
                }

                var eventoDaAgenda = await _context.EventosDaAgenda.FirstOrDefaultAsync(e => e.Id == id);

                eventoDaAgenda.Nome = eventoDaAgendaNovasInformacoes.Nome;
                eventoDaAgenda.InicioDoEvento = eventoDaAgendaNovasInformacoes.InicioDoEvento;
                eventoDaAgenda.FimDoEvento = eventoDaAgendaNovasInformacoes.FimDoEvento;
                eventoDaAgenda.IdUsuarioQueCadastrouEvento = GetIdUsuarioLogado();

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
        [Authorize(Roles = "Admin, Professor")]
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

                if (UsuarioNaoPossuiAcessoEsteEvento(eventoDaAgenda))
                {
                    return Forbid();
                }

                if (UsuarioNaoPodeEditarEvento(eventoDaAgenda))
                {
                    return Forbid();
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
        [Authorize(Roles = "Admin, Professor")]
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

        private bool UsuarioNaoPossuiAcessoEsteEvento(EventoDaAgenda eventoDaAgenda)
        {
            if (User.IsInRole("Professor")) {
                List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());

                // Checar instancias nulas
                if (eventoDaAgenda.Agenda == null)
                {
                    return false;
                }
                if (eventoDaAgenda.Agenda.TurmaId == null)
                {
                    eventoDaAgenda.Agenda.TurmaId = 0;
                }

                // Verificar se professor tem acesso a evento, caso agenda do evento não seja nula;
                if (!((idAgendasSelecionadas.Contains((int)eventoDaAgenda.Agenda.TurmaId) || eventoDaAgenda.Agenda == null)
                    &&
                    ((int)eventoDaAgenda.Agenda.Perfil == 0 || (int)eventoDaAgenda.Agenda.Perfil == 2 || eventoDaAgenda.Agenda == null)
                    ))
                {
                    return true;
                }
            }
            else if (User.IsInRole("ResponsavelAluno"))
            {
                List<int> idAgendasSelecionadas = ListarAgendasQueResponsavelTemAcesso(GetIdUsuarioLogado());

                // Checar instancias nulas
                if (eventoDaAgenda.Agenda == null)
                {
                    return false;
                }
                if (eventoDaAgenda.Agenda.TurmaId == null)
                {
                    eventoDaAgenda.Agenda.TurmaId = 0;
                }

                // Verificar se responsavel tem acesso a evento, caso agenda do evento não seja nula;

                if (!((idAgendasSelecionadas.Contains((int)eventoDaAgenda.Agenda.TurmaId) || eventoDaAgenda.Agenda == null)
                    &&
                    ((int)eventoDaAgenda.Agenda.Perfil == 0 || (int)eventoDaAgenda.Agenda.Perfil == 1 || eventoDaAgenda.Agenda == null)
                    ))
                {
                    return true;
                }
            }
            else if (!User.IsInRole("Admin"))
            {
                // Checar instancias nulas
                if (eventoDaAgenda.Agenda == null)
                {
                    return false;
                }
                if (eventoDaAgenda.Agenda.TurmaId == null)
                {
                    eventoDaAgenda.Agenda.TurmaId = 0;
                }

                // Verificar se usuario tem acesso a evento, caso agenda do evento não seja nula;

                if (!(((int)eventoDaAgenda.Agenda.Perfil == 0 && (int)eventoDaAgenda.Agenda.TurmaId == 0) || eventoDaAgenda.Agenda == null))
                {
                    return true;
                }
            }
            return false;
        }

        private bool UsuarioNaoPodeEditarEvento(EventoDaAgenda eventoDaAgenda)
        {
        if (eventoDaAgenda.IdUsuarioQueCadastrouEvento == GetIdUsuarioLogado())
        {
                return false;
        }
            return true;
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
