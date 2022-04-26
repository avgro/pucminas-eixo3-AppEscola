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
    public class DisciplinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisciplinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disciplinas.Include(d => d.Turma).ToListAsync());
        }

        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.Include(d => d.Professores).ThenInclude(p => p.Usuario)
                .Include(d => d.HorariosDaDisciplina)
                .Include(d => d.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public IActionResult Create()
        {
            ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario), "ProfessorId", "Usuario.NomeDisplayLista");
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codigo")] Disciplina disciplina,
            [Bind("listaDeProfessoresDaDisciplinaPorId")] string listaDeProfessoresDaDisciplinaPorId,
            [Bind("horarioInicioLista")] string horarioInicioLista,
            [Bind("horarioFimLista")] string horarioFimLista,
            [Bind("diaDaSemanaListaNumber")] string diaDaSemanaListaNumber)
        {
            if (listaDeProfessoresDaDisciplinaPorId == null)
            {
                ModelState.AddModelError("Professores", "Selecionar pelo menos um professor para a disciplina!");
            }

            List<string> listarErrosDeValidacao = IsValidCustomizadoHorarios(horarioInicioLista, horarioFimLista, diaDaSemanaListaNumber);

            while (listarErrosDeValidacao.Count > 0)
            {
                ViewData["Error"] = "Error";
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                listarErrosDeValidacao.RemoveRange(0, 2);
            }

            if (ModelState.IsValid)
            {
                disciplina.NomeComCodigoEntreParenteses = disciplina.Nome + "(" + disciplina.Codigo + ")";
                disciplina.Professores = new List<Professor>();
                List<string> listaProfessores = listaDeProfessoresDaDisciplinaPorId.Split(";").ToList();
                for (int i = 0; i < (listaProfessores.Count - 1); i++)
                {
                    int professorId = int.Parse(listaProfessores[i]);
                    Professor professor = await _context.Professores.FirstOrDefaultAsync(s => s.ProfessorId == professorId);
                    disciplina.Professores.Add(professor);
                }

                disciplina.HorariosDaDisciplina = new List<HorariosDaDisciplina>();

                List<string> horarioInicioToList = horarioInicioLista.Split(";").ToList();
                List<string> horarioFimToList = horarioFimLista.Split(";").ToList();
                List<string> diaDaSemanaToList = diaDaSemanaListaNumber.Split(";").ToList();
                for (int i = 0; i < (diaDaSemanaToList.Count() - 1); i++) {
                    HorariosDaDisciplina horario = new();
                    horario.DiaDaSemana = Int32.Parse(diaDaSemanaToList[i]);
                    horario.HorarioInicio = horarioInicioToList[i];
                    horario.HorarioFim = horarioFimToList[i];
                    disciplina.HorariosDaDisciplina.Add(horario);
                }
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Error"] = "Error";
            ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario), "ProfessorId", "Usuario.NomeDisplayLista");
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.Include(d => d.Professores).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Disciplina disciplina)
        {
            if (id != disciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.Id))
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
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplinas.Any(e => e.Id == id);
        }
        private List<string> IsValidCustomizadoHorarios(string horarioInicioLista, string horarioFimLista, string diaDaSemanaListaNumber)
        {
            List<string> errorMessage = new();
            if (horarioInicioLista == null || horarioFimLista == null || diaDaSemanaListaNumber == null)
            {
                errorMessage.Add("HorariosDaDisciplina");
                errorMessage.Add("Informar horários das disciplinas!");
                return errorMessage;
            }

            List<string> horarioInicioToList = horarioInicioLista.Split(";").ToList();
            List<string> horarioFimToList = horarioFimLista.Split(";").ToList();
            List<string> diaDaSemanaToList = diaDaSemanaListaNumber.Split(";").ToList();

            if (horarioFimToList.Count != horarioFimToList.Count && horarioInicioToList.Count != diaDaSemanaToList.Count)
            {
                errorMessage.Add("HorariosDaDisciplina");
                errorMessage.Add("Informar horários das disciplinas!");
                return errorMessage;
            }

            // Checar se há conflito de horários 

            List<int> conflitosInicioParaChecar = new();
            List<int> conflitosFimParaChecar = new();

            bool horariosEmConflito = false;
            for (int i = 0; i < (diaDaSemanaToList.Count - 1); i++)
            {
                try { 
                    int horasInicio = Int32.Parse(horarioInicioToList[i].Substring(0, 2));
                    int minutosInicio = Int32.Parse(horarioInicioToList[i].Substring(3,2));
                    int horasFim = Int32.Parse(horarioFimToList[i].Substring(0, 2));
                    int minutosFim = Int32.Parse(horarioFimToList[i].Substring(3, 2));
                    var diaDaSemana = Int32.Parse(diaDaSemanaToList[i]);

                    int converterHorarioInicioParaMinutos = minutosInicio + horasInicio * 60 + diaDaSemana * 1440;
                    int converterHorarioFimParaMinutos = minutosFim + horasFim * 60 + diaDaSemana * 1440;

                    // Se o horário de fim da aula for maior que o de inicio, considerar que a aula acaba no dia seguinte.
                    if (converterHorarioInicioParaMinutos > converterHorarioFimParaMinutos)
                    {
                        errorMessage.Add("HorariosDaDisciplina");
                        errorMessage.Add("Horário de fim da disciplina não pode ser antes que o horário de início!");
                        return errorMessage;
                    }


                    for (int j = 0; j < conflitosInicioParaChecar.Count(); j++) {
                        if (converterHorarioInicioParaMinutos >= conflitosInicioParaChecar[j] && converterHorarioInicioParaMinutos < conflitosFimParaChecar[j]) {
                            horariosEmConflito = true;
                        }
                        if (converterHorarioFimParaMinutos > conflitosInicioParaChecar[j] && converterHorarioFimParaMinutos <= conflitosFimParaChecar[j])
                        {
                            horariosEmConflito = true;
                        }

                        if (converterHorarioInicioParaMinutos < conflitosFimParaChecar[j] && converterHorarioFimParaMinutos > conflitosInicioParaChecar[j])
                        {
                            horariosEmConflito = true;
                        }
                    }
                    conflitosInicioParaChecar.Add(converterHorarioInicioParaMinutos);
                    conflitosFimParaChecar.Add(converterHorarioFimParaMinutos);

                    if (horariosEmConflito) {
                        errorMessage.Add("HorariosDaDisciplina");
                        errorMessage.Add("Horários da disciplina entram em conflito!");
                        return errorMessage;
                    }
                    
                }
                catch
                {
                    errorMessage.Add("HorariosDaDisciplina");
                    errorMessage.Add("Informar horários das disciplinas!");
                    return errorMessage;
                }
                // -----------------------------------------------------------------
            }


            return errorMessage;
        }
    }
}
