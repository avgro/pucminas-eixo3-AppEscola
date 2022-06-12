using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace App_comunicacao_escolar.Controllers
{
    [Authorize(Roles = "Professor, ResponsavelAluno")]
    public class AlunosLinhaDoTempoController : CommonController
    {
        private readonly ApplicationDbContext _context;
        public AlunosLinhaDoTempoController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: AlunosLinhaDoTempo
        public async Task<IActionResult> Index(int pagina = 1)
        {
            try { 
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var applicationDbContext = _context.AlunosLinhaDoTempo!.Include(l => l.Aluno).ThenInclude(a => a!.Turma);
                var linhaDoTempoAlunos = from l in applicationDbContext select l;
                if (User.IsInRole("Professor"))
                {
                    var professor = await _context.Professores!.Include(p => p.Disciplinas).FirstOrDefaultAsync(p => p.ProfessorId == idDoUsuarioLogado);
                    var idsTurmasDoProfessor = from d in professor!.Disciplinas select d.TurmaId;
                    linhaDoTempoAlunos = linhaDoTempoAlunos.Where(l => idsTurmasDoProfessor.Contains((int)l.Aluno!.TurmaId!));
                }
                if (User.IsInRole("ResponsavelAluno"))
                {
                    var responsavel = await _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefaultAsync(p => p.ResponsavelId == idDoUsuarioLogado);
                    var idsDependentes = from d in responsavel!.Alunos select d.Id;
                    linhaDoTempoAlunos = linhaDoTempoAlunos.Where(l => idsDependentes.Contains((int)l.Aluno!.Id));
                }
                return View(await linhaDoTempoAlunos.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Visualizar(int? id, int? post, int? numeroComentarios = 0, bool mostrarTodosComentarios = false)
        {
            try { 
                if (id == null || _context.AlunosLinhaDoTempo == null)
                {
                    return NotFound();
                }
                if (User.IsInRole("Professor"))
                {
                    if (ProfessorNaoTemAcessoALinhaDoTempo((int)id))
                    {
                        return Forbid();
                    }
                }
                if (User.IsInRole("ResponsavelAluno"))
                {
                    if (ResponsavelNaoTemAcessoALinhaDoTempo((int)id))
                    {
                        return Forbid();
                    }
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
            catch
            {
                return BadRequest();
            }
        }

        // GET: ComentariosPostagensLinhaDoTempo/CreateComentario
        public IActionResult CreateComentario()
        {
            try { 
                return RedirectToRoute(new { controller = "AlunosLinhaDoTempo", action = "Visualizar", id = 1 });
            }
            catch
            {
                return BadRequest();
            }
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
            try { 
            int linhaDoTempoId = Int32.Parse(LinhaDoTempoId);

            if (User.IsInRole("Professor"))
            {
                if (ProfessorNaoTemAcessoALinhaDoTempo(linhaDoTempoId))
                {
                    return Forbid();
                }
            }
            if (User.IsInRole("ResponsavelAluno"))
            {
                if (ResponsavelNaoTemAcessoALinhaDoTempo(linhaDoTempoId))
                {
                    return Forbid();
                }
            }

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
            catch
            {
                return BadRequest();
            }
        }

        private bool AlunoLinhaDoTempoExists(int id)
        {
          return (_context.AlunosLinhaDoTempo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
