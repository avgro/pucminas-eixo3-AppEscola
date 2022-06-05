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
    public class AlunosLinhaDoTempoController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public AlunosLinhaDoTempoController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: AlunosLinhaDoTempo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AlunosLinhaDoTempo!.Include(a => a.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Visualizar(int? id, int? post, int? numeroComentarios = 0, bool mostrarTodosComentarios = false)
        {
            if (id == null || _context.AlunosLinhaDoTempo == null)
            {
                return NotFound();
            }
            var alunoLinhaDoTempo = await _context.AlunosLinhaDoTempo
            .Include(a => a.Postagens!.OrderByDescending(p => p.DataAtualizacao))
            .ThenInclude(p => p.Autor)
            .Include(a => a.Postagens!.OrderByDescending(p => p.DataAtualizacao))
            .ThenInclude(p => p.Comentarios!)
            .ThenInclude(c => c.Autor)
            .Include(a => a.Aluno)
            .FirstOrDefaultAsync(m => m.Id == id);
            ViewData["Id"] = id;

            ViewBag.linhaDoTempoId = id;
            ViewBag.postId = post;
            ViewBag.numeroComentarios = 10;
            ViewBag.mostrarTodosComentarios = mostrarTodosComentarios;
            if (post != null) {
                ViewBag.numeroComentarios = numeroComentarios + 5;
            }
            return View(alunoLinhaDoTempo);
        }

        // GET: AlunosLinhaDoTempo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunosLinhaDoTempo == null)
            {
                return NotFound();
            }

            var alunoLinhaDoTempo = await _context.AlunosLinhaDoTempo
                .Include(a => a.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoLinhaDoTempo == null)
            {
                return NotFound();
            }

            return View(alunoLinhaDoTempo);
        }

        // GET: AlunosLinhaDoTempo/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "NomeAlunoComCodigoEntreParenteses"); ;
            return View();
        }

        // POST: AlunosLinhaDoTempo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId")] AlunoLinhaDoTempo alunoLinhaDoTempo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoLinhaDoTempo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "CodigoDoAluno", alunoLinhaDoTempo.AlunoId);
            return View(alunoLinhaDoTempo);
        }

        // GET: ComentariosPostagensLinhaDoTempo/CreateComentario
        public IActionResult CreateComentario()
        {
            return RedirectToRoute(new { controller = "AlunosLinhaDoTempo", action = "Visualizar", id = 1 });
        }

        // POST: ComentariosPostagensLinhaDoTempo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComentario([Bind("ConteudoComentario")] string ConteudoComentario,
            [Bind("PostagemId")] string PostagemId,
            [Bind("LinhaDoTempoId")] string LinhaDoTempoId)
        {
            ComentarioPostagemLinhaDoTempo comentarioPostagemLinhaDoTempo = new();
            comentarioPostagemLinhaDoTempo.Conteudo = ConteudoComentario;
            comentarioPostagemLinhaDoTempo.DataCriacao = DateTime.Now;
            comentarioPostagemLinhaDoTempo.AutorId = GetIdUsuarioLogado();
            comentarioPostagemLinhaDoTempo.PostagemLinhaDoTempoId = Int32.Parse(PostagemId);

            if (ModelState.IsValid)
            {
                var postagem = await _context.PostagensLinhaDoTempo!.FirstOrDefaultAsync(m => m.Id == comentarioPostagemLinhaDoTempo.PostagemLinhaDoTempoId);
                postagem!.DataAtualizacao = comentarioPostagemLinhaDoTempo.DataCriacao;
                _context.Update(postagem);
                _context.Add(comentarioPostagemLinhaDoTempo);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "AlunosLinhaDoTempo", action = "Visualizar", 
                    id = Int32.Parse(LinhaDoTempoId), 
                    post = Int32.Parse(PostagemId), 
                    mostrarTodosComentarios = true });
            }
            return RedirectToRoute(new { controller = "AlunosLinhaDoTempo", action = "Visualizar", id = Int32.Parse(LinhaDoTempoId) });
        }

        // GET: AlunosLinhaDoTempo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunosLinhaDoTempo == null)
            {
                return NotFound();
            }

            var alunoLinhaDoTempo = await _context.AlunosLinhaDoTempo.FindAsync(id);
            if (alunoLinhaDoTempo == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "CodigoDoAluno", alunoLinhaDoTempo.AlunoId);
            return View(alunoLinhaDoTempo);
        }

        // POST: AlunosLinhaDoTempo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId")] AlunoLinhaDoTempo alunoLinhaDoTempo)
        {
            if (id != alunoLinhaDoTempo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoLinhaDoTempo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoLinhaDoTempoExists(alunoLinhaDoTempo.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "CodigoDoAluno", alunoLinhaDoTempo.AlunoId);
            return View(alunoLinhaDoTempo);
        }

        // GET: AlunosLinhaDoTempo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunosLinhaDoTempo == null)
            {
                return NotFound();
            }

            var alunoLinhaDoTempo = await _context.AlunosLinhaDoTempo
                .Include(a => a.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoLinhaDoTempo == null)
            {
                return NotFound();
            }

            return View(alunoLinhaDoTempo);
        }

        // POST: AlunosLinhaDoTempo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunosLinhaDoTempo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlunosLinhaDoTempo'  is null.");
            }
            var alunoLinhaDoTempo = await _context.AlunosLinhaDoTempo.FindAsync(id);
            if (alunoLinhaDoTempo != null)
            {
                _context.AlunosLinhaDoTempo.Remove(alunoLinhaDoTempo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoLinhaDoTempoExists(int id)
        {
          return (_context.AlunosLinhaDoTempo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
