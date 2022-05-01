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
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alunos.Include(a => a.Turma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Responsaveis.OrderBy(r => r.Usuario.NomeDisplayLista))
                .ThenInclude(r => r.Usuario)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo");
            ViewData["ResponsavelId"] = new SelectList(_context.Responsaveis.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ResponsavelId", "Usuario.NomeDisplayLista");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,CodigoDoAluno,DataDeNascimento,NomeAlunoComCodigoEntreParenteses,TurmaId")] Aluno aluno, [Bind("listaDeResponsaveisDoAlunoPorId")] string listaDeResponsaveisDoAlunoPorId)
        {       
            List<string> listarErrosDeValidacao = IsValidCustomizado(aluno, listaDeResponsaveisDoAlunoPorId);

            while (listarErrosDeValidacao.Count > 0)
            {
                ViewData["Error"] = "Error";
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                listarErrosDeValidacao.RemoveRange(0, 2);
            }

            if (ModelState.IsValid)
            {
                aluno.NomeAlunoComCodigoEntreParenteses = aluno.Nome + "" + aluno.Sobrenome + " (" + aluno.CodigoDoAluno + ")";
                aluno.Responsaveis= new List<Responsavel>();
                List<string> listaResponsaveis = listaDeResponsaveisDoAlunoPorId.Split(";").ToList();
                for (int i = 0; i < (listaResponsaveis.Count - 1); i++)
                {
                    int responsavelId = int.Parse(listaResponsaveis[i]);
                    var responsavel = await _context.Responsaveis.FirstOrDefaultAsync(r => r.ResponsavelId == responsavelId);
                    aluno.Responsaveis.Add(responsavel);
                }
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", aluno.TurmaId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsaveis.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ResponsavelId", "Usuario.NomeDisplayLista");
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Responsaveis.OrderBy(r => r.Usuario.NomeDisplayLista))
                .ThenInclude(r => r.Usuario)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", aluno.TurmaId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsaveis.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ResponsavelId", "Usuario.NomeDisplayLista");
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,CodigoDoAluno,DataDeNascimento,NomeAlunoComCodigoEntreParenteses,TurmaId")] Aluno alunoAtualizar,
            [Bind("listaDeResponsaveisDoAlunoPorId")] string listaDeResponsaveisDoAlunoPorId)
        {
            var aluno = await _context.Alunos
                .Include(a => a.Responsaveis)
                .ThenInclude(r => r.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);

            aluno.Nome = alunoAtualizar.Nome;
            aluno.Sobrenome = alunoAtualizar.Sobrenome;
            aluno.CodigoDoAluno = alunoAtualizar.CodigoDoAluno;
            aluno.DataDeNascimento = alunoAtualizar.DataDeNascimento;
            aluno.TurmaId = alunoAtualizar.TurmaId;

            List<string> listarErrosDeValidacao = IsValidCustomizado(aluno, listaDeResponsaveisDoAlunoPorId);

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
                    aluno.NomeAlunoComCodigoEntreParenteses = aluno.Nome + "" + aluno.Sobrenome + " (" + aluno.CodigoDoAluno + ")";
                    aluno.Responsaveis = new List<Responsavel>();
                    List<string> listaResponsaveis = listaDeResponsaveisDoAlunoPorId.Split(";").ToList();
                    for (int i = 0; i < (listaResponsaveis.Count - 1); i++)
                    {
                        int responsavelId = int.Parse(listaResponsaveis[i]);
                        var responsavel = await _context.Responsaveis.FirstOrDefaultAsync(r => r.ResponsavelId == responsavelId);
                        aluno.Responsaveis.Add(responsavel);
                    }
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", aluno.TurmaId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsaveis.Include(p => p.Usuario).OrderBy(p => p.Usuario.NomeDisplayLista), "ResponsavelId", "Usuario.NomeDisplayLista");
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Responsaveis.OrderBy(r => r.Usuario.NomeDisplayLista))
                .ThenInclude(r => r.Usuario)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }

        public List<string> IsValidCustomizado(Aluno aluno, string listaDeResponsaveisDoAlunoPorId)
        {
            List<string> errorMessage = new();
            if (listaDeResponsaveisDoAlunoPorId == null)
            {
                errorMessage.Add("Responsaveis");
                errorMessage.Add("Selecionar ao menos um responsável para o aluno!");

            }
            if (aluno.TurmaId == null)
            {
                errorMessage.Add("TurmaId");
                errorMessage.Add("Selecionar turma do aluno!");

            }
            return errorMessage;
        }
    }
}
