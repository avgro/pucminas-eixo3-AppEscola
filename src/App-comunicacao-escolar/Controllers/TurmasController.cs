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
    public class TurmasController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Turmas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string searchString, int pagina = 1)
        {
            try
            {
                var applicationDbContext = _context.Turmas.OrderBy(t => t.NomeComCodigoEntreParenteses);

                var turmas = from t in applicationDbContext select t;

                turmas = turmas.OrderBy(t => t.NomeComCodigoEntreParenteses);

                if (searchString != null)
                {
                    turmas = turmas.Where(t => t.NomeComCodigoEntreParenteses.Contains(searchString));
                }

                return View(await turmas.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: TurmasProfessor
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> TurmasProfessor(string searchString, int pagina = 1)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var professor = await _context.Professores.Include(p => p.Disciplinas).FirstOrDefaultAsync(p => p.ProfessorId == idDoUsuarioLogado);
                var professorTurmas = from p in professor.Disciplinas select p.TurmaId;

                var applicationDbContext = _context.Turmas
                    .Include(t => t.Disciplinas.Where(d => d.Professores.Any(p => p.ProfessorId == idDoUsuarioLogado)))
                    .OrderBy(t => t.NomeComCodigoEntreParenteses);

                var turmas = from t in applicationDbContext select t;
                turmas = turmas.Where(t => professorTurmas.Contains(t.Id));

                turmas = turmas.OrderBy(t => t.NomeComCodigoEntreParenteses);

                if (searchString != null)
                {
                    turmas = turmas.Where(t => t.NomeComCodigoEntreParenteses.Contains(searchString));
                }

                return View(await turmas.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Turmas/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var turma = await _context.Turmas.Include(t => t.Disciplinas.OrderBy(d => d.NomeComCodigoEntreParenteses)).Include(t => t.Alunos.OrderBy(a => a.NomeAlunoComCodigoEntreParenteses))
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (turma == null)
                {
                    return NotFound();
                }

                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Turmas/AlunosTurma/5
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> AlunosTurma(string searchString, int? id, int pagina = 1)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var professor = await _context.Professores.Include(p => p.Disciplinas).FirstOrDefaultAsync(p => p.ProfessorId == idDoUsuarioLogado);
                var professorTurmas = from p in professor.Disciplinas select p.TurmaId;

                if (!professorTurmas.Contains(id))
                {
                    return Forbid();
                }

                var turma = await _context.Turmas
                    .Include(t => t.Alunos.OrderBy(a => a.NomeAlunoComCodigoEntreParenteses))
                    .ThenInclude(a => a.Responsaveis)
                    .ThenInclude(r => r.Usuario)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (turma == null)
                {
                    return NotFound();
                }

                ViewData["NomeDaTurma"] = turma.NomeComCodigoEntreParenteses;

                if (searchString != null)
                {
                    return View(await turma.Alunos
                        .Where(a => a.NomeAlunoComCodigoEntreParenteses.Contains(searchString)).ToPagedListAsync(pagina, 50));
                }

                return View(await turma.Alunos.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Turmas/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codigo,NomeComCodigoEntreParenteses")] Turma turma)
        {
            try
            {
                turma.Codigo = turma.Codigo.Trim();
                List<string> listarErrosDeValidacao = IsValidCustomizado(turma);
                while (listarErrosDeValidacao.Count > 0)
                {
                    ViewData["Error"] = "Error";
                    ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                    ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                    listarErrosDeValidacao.RemoveRange(0, 2);
                }

                if (ModelState.IsValid)
                {
                    turma.NomeComCodigoEntreParenteses = turma.Nome + " (" + turma.Codigo + ")";
                    _context.Add(turma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GerenciarDisciplinas", new { id = turma.Id });
                }
                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Turmas/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
                ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas.Where(d => d.TurmaId == null).OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codigo,NomeComCodigoEntreParenteses")] Turma turma)
        {
            try
            {
                if (id != turma.Id)
                {
                    return NotFound();
                }

                turma.Codigo = turma.Codigo.Trim();
                List<string> listarErrosDeValidacao = IsValidCustomizado(turma, turma.Id);
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
                        turma.NomeComCodigoEntreParenteses = turma.Nome + " (" + turma.Codigo + ")";
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
                    return RedirectToAction("GerenciarDisciplinas", new { id = turma.Id });
                }
                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Turmas/GerenciarDisciplinas/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GerenciarDisciplinas(int? id, int? tentarAssociarDisciplina)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var turma = await _context.Turmas.Include(t => t.Disciplinas.OrderBy(d => d.NomeComCodigoEntreParenteses)).ThenInclude(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(t => t.Id == id);
                if (turma == null)
                {
                    return NotFound();
                }
                ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas.Where(d => d.TurmaId == null).OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");
                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Turmas/GerenciarDisciplinas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GerenciarDisciplinas(int id, 
            [Bind("numeroDaDisciplinaQueDesejaAdicionar")] int numeroDaDisciplinaQueDesejaAdicionar,
            [Bind("adicionarOuRemover")] string adicionarOuRemover)

            {
            try { 
                Turma turma = await _context.Turmas.Include(t => t.Disciplinas.OrderBy(d => d.NomeComCodigoEntreParenteses)).ThenInclude(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(t => t.Id == id);

                string horarioInicioLista = "";
                string horarioFimLista = "";
                string diaDaSemanaListaNumber = "";
                string nomeDisciplinaLista = "";
                foreach (var disciplinaCadastrada in turma.Disciplinas)
                {
                    foreach (var horarioCadastrado in disciplinaCadastrada.HorariosDaDisciplina)
                    {
                        horarioInicioLista += horarioCadastrado.HorarioInicio + ";";
                        horarioFimLista += horarioCadastrado.HorarioFim + ";";
                        diaDaSemanaListaNumber += horarioCadastrado.DiaDaSemana + ";";
                        nomeDisciplinaLista += disciplinaCadastrada.NomeComCodigoEntreParenteses.Replace(";",":") + ";";
                    }
                }

                ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas.Where(d => d.TurmaId == null).OrderBy(d => d.NomeComCodigoEntreParenteses), "Id", "NomeComCodigoEntreParenteses");

                Disciplina disciplina = await _context.Disciplinas.Include(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(d => d.Id == numeroDaDisciplinaQueDesejaAdicionar);
             
                if (disciplina.TurmaId != null && adicionarOuRemover.Equals("adicionar"))
                {
                    string errorMessage = "Disciplina \"" + disciplina.NomeComCodigoEntreParenteses + "\" já está associada a uma turma!";
                    ModelState.AddModelError("Disciplinas", errorMessage);
                }

                if (adicionarOuRemover.Equals("adicionar")) { 
                    foreach (var horario in disciplina.HorariosDaDisciplina)
                    {
                        horarioInicioLista += horario.HorarioInicio + ";";
                        horarioFimLista += horario.HorarioFim + ";";
                        diaDaSemanaListaNumber += horario.DiaDaSemana + ";";
                        nomeDisciplinaLista += disciplina.NomeComCodigoEntreParenteses.Replace(";", ":") + ";";

                    }
                    List<string> listarErrosDeValidacao = IsValidCustomizadoHorarios(horarioInicioLista, horarioFimLista, diaDaSemanaListaNumber, nomeDisciplinaLista);

                    while (listarErrosDeValidacao.Count > 0)
                    {
                        ViewData["Error"] = "Error";
                        string disciplinaEmConflito1 = "";
                        string disciplinaEmConflito2 = "";
                        if (TempData.ContainsKey("NomeDaDisciplinaEmConflito1"))
                            disciplinaEmConflito1 = TempData["NomeDaDisciplinaEmConflito1"].ToString();
                        if (TempData.ContainsKey("NomeDaDisciplinaEmConflito2"))
                            disciplinaEmConflito2 = TempData["NomeDaDisciplinaEmConflito2"].ToString();
                        string errorMessage = "Horários da disciplina \"" + disciplinaEmConflito1 + "\" entram em conflito com os da disciplina \"" + disciplinaEmConflito2 + "\"!";
                        ModelState.AddModelError("Disciplinas", errorMessage);
                        listarErrosDeValidacao.RemoveRange(0, 2);
                    }
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
                    return RedirectToAction(nameof(GerenciarDisciplinas));
                }
                turma = await _context.Turmas.Include(t => t.Disciplinas.OrderBy(d => d.NomeComCodigoEntreParenteses)).ThenInclude(d => d.HorariosDaDisciplina).FirstOrDefaultAsync(t => t.Id == id);
                if (turma == null)
                {
                    return NotFound();
                }
                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Turmas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var turma = await _context.Turmas.Include(t => t.Disciplinas.OrderBy(d => d.NomeComCodigoEntreParenteses)).Include(t => t.Alunos.OrderBy(a => a.NomeAlunoComCodigoEntreParenteses))
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (turma == null)
                {
                    return NotFound();
                }

                return View(turma);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var turma = await _context.Turmas.FindAsync(id);
                _context.Turmas.Remove(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.Id == id);
        }
        private List<string> IsValidCustomizado(Turma turma, int idTurmaSendoAtualizada = 0)
        {
            List<string> errorMessage = new();
            if (_context.Turmas.Any(t => t.Codigo == turma.Codigo && t.Id != idTurmaSendoAtualizada))
            {
                errorMessage.Add("Codigo");
                errorMessage.Add("Código já utilizado por outra turma!");
            }

            return errorMessage;
        }
    }
}
