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
    public class NotificacoesController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public NotificacoesController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Notificacoes
        public async Task<IActionResult> Index(string searchString, string secao = "", int pagina = 1)
        {
            try
            {
                if(User.IsInRole("Admin")) {
                    secao = "";
                }
                int idUsuarioLogado = GetIdUsuarioLogado();
                var applicationDbContext = _context.Notificacoes!.Include(n => n.Turma).Include(n => n.NotificacoesLidas);

                var notificacoes = from n in applicationDbContext select n;

                if (User.IsInRole("ResponsavelAluno"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueResponsavelTemAcesso(idUsuarioLogado);
                    notificacoes = notificacoes.Where(n => idAgendasSelecionadas.Contains((int)n.TurmaId!) || n.Turma == null);
                    notificacoes = notificacoes.Where(n => (int)n.Perfil == 1 || n.Perfil == 0);
                }
                else if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(idUsuarioLogado);
                    notificacoes = notificacoes.Where(n => idAgendasSelecionadas.Contains((int)n.TurmaId!) || n.Turma == null);
                    notificacoes = notificacoes.Where(n => (int)n.Perfil == 2 || n.Perfil == 0);
                }
                else if (!User.IsInRole("Admin"))
                {
                    notificacoes = notificacoes.Where(n => n.TurmaId == null || n.Turma == null);
                    notificacoes = notificacoes.Where(n => n.Perfil == 0);
                }

                if (secao.Equals("Visualizadas"))
                {
                    notificacoes = notificacoes.Where(n => n.NotificacoesLidas!.Any(nl => nl.UsuarioId == idUsuarioLogado));
                }
                else
                {
                    notificacoes = notificacoes.Where(n => !n.NotificacoesLidas!.Any(nl => nl.UsuarioId == idUsuarioLogado));
                }

                notificacoes = notificacoes.OrderByDescending(a => a.Id);

                if (searchString != null)
                {
                    notificacoes = notificacoes.Where(n => n.Assunto!.Contains(searchString));
                }
                ViewData["TituloDaSecao"] = secao;
                return View(await notificacoes.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Notificacoes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo");
            return View();
        }

        // POST: Notificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Assunto,Conteudo,TurmaId,Perfil")] Notificacao notificacao)
        {
            if (notificacao.TurmaId == 0)
            {
                notificacao.TurmaId = null;
            }
            notificacao.DataCriacao = DateTime.Now.Date;
            notificacao.NotificacoesLidas = new List<UsuarioLeuNotificacao>();
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Codigo", notificacao.TurmaId);
            return View(notificacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarComoVista([Bind("notificacaoId")] int notificacaoId)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var usuarioLeuNotificacao = await _context.UsuarioLeuNotificacao!.FirstOrDefaultAsync(u => u.UsuarioId == idDoUsuarioLogado && u.NotificacaoId == notificacaoId);
                if (usuarioLeuNotificacao == null)
                {
                    UsuarioLeuNotificacao novoUsuarioLeuNotificacao = new()
                    {
                        UsuarioId = idDoUsuarioLogado,
                        NotificacaoId = notificacaoId
                    };
                    _context.Add(novoUsuarioLeuNotificacao);
                    await _context.SaveChangesAsync();
                }
                return RedirectToRoute(new { controller = "Notificacoes", action = "Index" });
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Notificacoes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .Include(n => n.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notificacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notificacoes'  is null.");
            }
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(int id)
        {
          return (_context.Notificacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
