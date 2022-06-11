#nullable disable
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;
using System.Globalization;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace App_comunicacao_escolar.Controllers
{
    [Authorize]
    public class AgendasController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public AgendasController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Agendas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string searchString, int pagina = 1)
        {
            try
            {
                var applicationDbContext = _context.Agendas.Include(a => a.Turma);

                var agendas = from a in applicationDbContext select a;

                agendas = agendas.OrderBy(a => a.Nome);

                if (searchString != null)
                {
                    agendas = agendas.Where(a => a.Nome.Contains(searchString));
                }

                return View(await agendas.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Agendas/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var agenda = await _context.Agendas.Include(a => a.Turma)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (agenda == null)
                {
                    return NotFound();
                }
                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Agendas/Visualizar/5
        public async Task<object> Visualizar(int? id, int? selecionarMes = -1, int? selecionarAno = -1)
        {
            try
            {
                var dataSelecionada = DateTime.Now;
                int diaAtual = dataSelecionada.Day;

                if (selecionarMes != -1 && selecionarAno != -1)
                {
                    if (dataSelecionada.Month != selecionarMes || dataSelecionada.Year != selecionarAno)
                    {
                        diaAtual = -1;
                    }
                    dataSelecionada = new DateTime((int)selecionarAno, (int)selecionarMes, 1);
                }

                string mesSelecionadoNome = dataSelecionada.ToString("MMMM");
                int mesSelecionadoNumero = dataSelecionada.Month;
                int anoSelecionado = dataSelecionada.Year;
                int numeroDeDiasDoMesSelecionado = DateTime.DaysInMonth(anoSelecionado, mesSelecionadoNumero);

                var inicioMes = new DateTime(anoSelecionado, mesSelecionadoNumero, 1);

                var fimMes = new DateTime(anoSelecionado, mesSelecionadoNumero, numeroDeDiasDoMesSelecionado);

                int inicioMesDiaDaSemana = (int)inicioMes.DayOfWeek;

                int numeroDeDiasDoMesAnterior = 0;
                if (mesSelecionadoNumero == 1)
                {
                    numeroDeDiasDoMesAnterior = DateTime.DaysInMonth((anoSelecionado - 1), 12);
                }
                else
                {
                    numeroDeDiasDoMesAnterior = DateTime.DaysInMonth(anoSelecionado, (mesSelecionadoNumero - 1));
                }

                ViewData["diaAtual"] = diaAtual;
                ViewData["mesNumero"] = mesSelecionadoNumero;
                ViewData["mesNome"] = mesSelecionadoNome;
                ViewData["anoSelecionado"] = anoSelecionado;
                ViewData["inicioMesDiaDaSemana"] = inicioMesDiaDaSemana;
                ViewData["numeroDeDiasDoMesSelecionado"] = numeroDeDiasDoMesSelecionado;
                ViewData["numeroDeDiasDoMesAnterior"] = numeroDeDiasDoMesAnterior;

                var inicioSelecaoEventos = inicioMes.AddDays(-6);
                var fimSelecaoEventos = fimMes.AddDays(14);

                var eventos = _context.EventosDaAgenda.Where(e => e.InicioDoEvento >= inicioSelecaoEventos && e.FimDoEvento <= fimSelecaoEventos).OrderBy(e => e.InicioDoEvento);

                var agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome), "Id", "Nome");

                Agenda agenda = new();
                string agendaNome = "";

                if (User.IsInRole("Admin"))
                {
                    agendaNome = "Todas as agendas";
                    if (id != null)
                    {
                        agenda = await _context.Agendas.FirstOrDefaultAsync(a => a.Id == id);
                        agendaNome = agenda.Nome;

                        var agendaSelected = agendaSelectList.Where(a => a.Text == agendaNome).First();
                        agendaSelected.Selected = true;
                        int[] idAgendasSelecionadas = { (int)id };
                        eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e => e.AgendaId == id);
                    }
                }
                else if (User.IsInRole("ResponsavelAluno"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueResponsavelTemAcesso(GetIdUsuarioLogado());

                    eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e =>
                        (idAgendasSelecionadas.Contains((int)e.Agenda.TurmaId) || e.Agenda.TurmaId == null)
                        &&
                        ((int)e.Agenda.Perfil == 0 || (int)e.Agenda.Perfil == 1 || e.Agenda == null)
                    );
                }
                else if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());

                    agendaNome = "Todas as agendas";
                    agendaSelectList = new SelectList(_context.Agendas.OrderBy(a => a.Nome).Where(a => idAgendasSelecionadas.Contains((int)a.TurmaId)), "Id", "Nome");
                    if (id != null)
                    {
                        agenda = await _context.Agendas.FirstOrDefaultAsync(a => a.Id == id);
                        agendaNome = agenda.Nome;

                        var agendaSelected = agendaSelectList.Where(a => a.Text == agendaNome).First();
                        agendaSelected.Selected = true;
                        eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e => e.AgendaId == id);
                    }
                    else
                    {
                        eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e =>
                            (((int)e.Agenda.Perfil == 0 || (int)e.Agenda.Perfil == 2) && (idAgendasSelecionadas.Contains((int)e.Agenda.TurmaId) || e.Agenda.TurmaId == null ))
                            ||
                            (e.Agenda == null)
                        );
                    }
                }
                else
                {
                    eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e =>
                        (((int)e.Agenda.Perfil == 0 && e.Agenda.TurmaId == null) || e.Agenda == null)
                    );
                }
                ViewData["AgendaNome"] = agendaNome.ToString();
                ViewData["AgendaId"] = agendaSelectList;

                string[] eventosDoMes = new string[42];
                foreach (var evento in eventos)
                {
                    var inicioDoEvento = (DateTime) evento.InicioDoEvento;
                    var fimDoEvento = (DateTime)evento.FimDoEvento;
                    int diaDoEvento = inicioDoEvento.Day;
                    int mesDoEvento = inicioDoEvento.Month;
                    if (mesDoEvento == 1 && mesSelecionadoNumero == 12)
                    {
                        mesDoEvento = 13;
                    }
                    if (mesDoEvento == 12 && mesSelecionadoNumero == 1)
                    {
                        mesDoEvento = 0;
                    }

                    string dataDoEvento = inicioDoEvento.Date.ToString().Substring(0,10);
                    string inicioDoEventoHoras = inicioDoEvento.TimeOfDay.ToString().Substring(0,5);
                    string fimDoEventoHoras = fimDoEvento.TimeOfDay.ToString().Substring(0, 5);

                    try
                    {
                        if (mesDoEvento == mesSelecionadoNumero)
                        {
                            eventosDoMes[diaDoEvento + inicioMesDiaDaSemana - 1] += evento.Nome.ToString() + ";" + dataDoEvento + ";" + inicioDoEventoHoras + ";" + fimDoEventoHoras + ";" + evento.Id + ";;";
                        }
                        else if (mesDoEvento > mesSelecionadoNumero)
                        {
                            eventosDoMes[diaDoEvento + inicioMesDiaDaSemana + numeroDeDiasDoMesSelecionado - 1] += evento.Nome.ToString() + ";" + dataDoEvento + ";" + inicioDoEventoHoras + ";" + fimDoEventoHoras + ";" + evento.Id + ";;";
                        }
                        else if (mesDoEvento < mesSelecionadoNumero)
                        {
                            eventosDoMes[diaDoEvento - numeroDeDiasDoMesAnterior + inicioMesDiaDaSemana - 1] += evento.Nome.ToString() + ";" + dataDoEvento + ";" + inicioDoEventoHoras + ";" + fimDoEventoHoras + ";" + evento.Id + ";;";
                        }
                    }
                    catch { 
                    }
                }

                ViewBag.EventosDoMes = eventosDoMes;
                ViewBag.MesAtualSelecionado = true;
                ViewData["Id"] = id;
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Agendas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            try
            {
                ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Agendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Nome,TurmaId","Perfil")] Agenda agenda)
        {
            try
            {
                if (agenda.TurmaId == 0)
                {
                    agenda.TurmaId = null;
                }
                if (ModelState.IsValid)
                {
                    _context.Add(agenda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Agendas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var agenda = await _context.Agendas.FindAsync(id);
                if (agenda == null)
                {
                    return NotFound();
                }
                ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Agendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TurmaId", "Perfil")] Agenda agenda)
        {
            try
            {
                if (id != agenda.Id)
                {
                    return NotFound();
                }

                if (agenda.TurmaId == 0)
                {
                    agenda.TurmaId = null;
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(agenda);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AgendaExists(agenda.Id))
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
                ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Agendas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var agenda = await _context.Agendas
                 .FirstOrDefaultAsync(m => m.Id == id);
                if (agenda == null)
                {
                    return NotFound();
                }

                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Agendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var agenda = await _context.Agendas.FindAsync(id);
                _context.Agendas.Remove(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.Id == id);
        }
    }
}
