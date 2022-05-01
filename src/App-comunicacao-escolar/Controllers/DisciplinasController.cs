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
    public class DisciplinasController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public DisciplinasController(ApplicationDbContext context) : base(context)
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
            ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ProfessorId", "Usuario.NomeDisplayLista");
            ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
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
            [Bind("diaDaSemanaListaNumber")] string diaDaSemanaListaNumber,
            [Bind("tentarCadastrarTurmaId")] int tentarCadastrarTurmaId)
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
                disciplina.NomeComCodigoEntreParenteses = disciplina.Nome + " (" + disciplina.Codigo + ")";
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
                if (tentarCadastrarTurmaId == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("GerenciarDisciplinas", "Turmas", new { id = tentarCadastrarTurmaId, tentarAssociarDisciplina = disciplina.Id });
                }
            }
            ViewData["Error"] = "Error";
            ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ProfessorId", "Usuario.NomeDisplayLista");
            ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
            return View(disciplina);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ProfessorId", "Usuario.NomeDisplayLista");
            ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");

            var disciplina = await _context.Disciplinas.Include(d => d.Professores).ThenInclude(p => p.Usuario).Include(d => d.HorariosDaDisciplina)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codigo")] Disciplina disciplinaAtualizar,
            [Bind("listaDeProfessoresDaDisciplinaPorId")] string listaDeProfessoresDaDisciplinaPorId,
            [Bind("horarioInicioLista")] string horarioInicioLista,
            [Bind("horarioFimLista")] string horarioFimLista,
            [Bind("diaDaSemanaListaNumber")] string diaDaSemanaListaNumber,
            [Bind("tentarCadastrarTurmaId")] int tentarCadastrarTurmaId)
        {
            try { 
                var disciplina = await _context.Disciplinas.Include(d => d.Professores).ThenInclude(p => p.Usuario).Include(d => d.HorariosDaDisciplina)
                    .FirstOrDefaultAsync(d => d.Id == id);

                disciplina.Nome = disciplinaAtualizar.Nome;
                disciplina.Codigo = disciplinaAtualizar.Codigo;

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
                    try
                    {
                        disciplina.NomeComCodigoEntreParenteses = disciplina.Nome + " (" + disciplina.Codigo + ")";
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
                        for (int i = 0; i < (diaDaSemanaToList.Count() - 1); i++)
                        {
                            HorariosDaDisciplina horario = new();
                            horario.DiaDaSemana = Int32.Parse(diaDaSemanaToList[i]);
                            horario.HorarioInicio = horarioInicioToList[i];
                            horario.HorarioFim = horarioFimToList[i];
                            disciplina.HorariosDaDisciplina.Add(horario);
                        }

                        disciplina.TurmaId = null;

                        _context.Update(disciplina);
                        await _context.SaveChangesAsync();
                        if (tentarCadastrarTurmaId == 0)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            return RedirectToAction("GerenciarDisciplinas", "Turmas", new { id = tentarCadastrarTurmaId, tentarAssociarDisciplina = disciplina.Id });
                        }
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }
                ViewData["Error"] = "Error";
                ViewData["ProfessorId"] = new SelectList(_context.Professores.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ProfessorId", "Usuario.NomeDisplayLista");
                ViewData["TurmaId"] = new SelectList(_context.Turmas.OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(disciplina);
            }
            catch
            {
                return BadRequest();
            }
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

    }
}
