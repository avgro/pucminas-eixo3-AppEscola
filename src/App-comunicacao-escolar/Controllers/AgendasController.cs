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

namespace App_comunicacao_escolar.Controllers
{
    public class AgendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agendas.ToListAsync());
        }

        // GET: Agendas/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Agendas/Visualizar/5
        public async Task<object> Visualizar(int? id, int? selecionarMes = -1, int? selecionarAno = -1)
        {
            try { 
                if (id == null)
                {
                    return NotFound();
                }

                var agenda = await _context.Agendas
                    .Include(a => a.EventosDaAgenda)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (agenda == null)
                {
                    return NotFound();
                }

                var dataSelecionada = DateTime.Now;
                int diaAtual = dataSelecionada.Day;

                if (selecionarMes != -1 && selecionarAno != -1) {
                    if (dataSelecionada.Month != selecionarMes || dataSelecionada.Year != selecionarAno) {
                        diaAtual = -1;
                    }
                    dataSelecionada = new DateTime((int) selecionarAno, (int) selecionarMes, 1);
                }

                string mesSelecionadoNome = dataSelecionada.ToString("MMMM");
                int mesSelecionadoNumero = dataSelecionada.Month;
                int anoSelecionado = dataSelecionada.Year;
                int numeroDeDiasDoMesSelecionado = DateTime.DaysInMonth(anoSelecionado, mesSelecionadoNumero);

                var inicioMes = new DateTime(anoSelecionado, mesSelecionadoNumero, 1);
                var fimMes = new DateTime(anoSelecionado, mesSelecionadoNumero, numeroDeDiasDoMesSelecionado);

                int inicioMesDiaDaSemana = (int) inicioMes.DayOfWeek;

                int numeroDeDiasDoMesAnterior = 0;
                if (mesSelecionadoNumero == 1)
                {
                    numeroDeDiasDoMesAnterior = DateTime.DaysInMonth((anoSelecionado - 1), 12);
                }
                else { 
                    numeroDeDiasDoMesAnterior = DateTime.DaysInMonth(anoSelecionado, (mesSelecionadoNumero - 1));
                }

                ViewData["diaAtual"] = diaAtual;
                ViewData["mesNumero"] = mesSelecionadoNumero;
                ViewData["mesNome"] = mesSelecionadoNome;
                ViewData["anoSelecionado"] = anoSelecionado;
                ViewData["inicioMesDiaDaSemana"] = inicioMesDiaDaSemana;
                ViewData["numeroDeDiasDoMesSelecionado"] = numeroDeDiasDoMesSelecionado;
                ViewData["numeroDeDiasDoMesAnterior"] = numeroDeDiasDoMesAnterior;

                var eventos = _context.EventosDaAgenda.Where(e => e.AgendaId == agenda.Id && e.InicioDoEvento >= inicioMes && e.FimDoEvento <= fimMes).OrderBy(e => e.InicioDoEvento);

                string[] eventosDoMes = new string[42];
                foreach (var evento in eventos)
                {
                    var inicioDoEvento = (DateTime) evento.InicioDoEvento;
                    var fimDoEvento = (DateTime)evento.FimDoEvento;
                    int diaDoEvento = inicioDoEvento.Day;

                    string dataDoEvento = inicioDoEvento.Date.ToString().Substring(0,10);
                    string inicioDoEventoHoras = inicioDoEvento.TimeOfDay.ToString().Substring(0,5);
                    string fimDoEventoHoras = fimDoEvento.TimeOfDay.ToString().Substring(0, 5);

                    eventosDoMes[diaDoEvento - 1] += evento.Nome.ToString() + ";" + dataDoEvento + ";" + inicioDoEventoHoras + ";" + fimDoEventoHoras + ";;";
                }

                ViewBag.EventosDoMes = eventosDoMes;

                return View(agenda);
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Agendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        // GET: Agendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(agenda);
        }

        // POST: Agendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Agenda agenda)
        {
            if (id != agenda.Id)
            {
                return NotFound();
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
            return View(agenda);
        }

        // GET: Agendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Agendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.Id == id);
        }
    }
}
