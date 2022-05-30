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
    [Authorize(Roles = "Admin, ResponsavelAluno")]
    public class AutorizacoesEventosController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public AutorizacoesEventosController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: AutorizacoesEventos
        public async Task<IActionResult> Index(string secao = "", int pagina = 1)
        {
            try {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var applicationDbContext = _context.AutorizacoesEventos!.Include(a => a.Aluno).Include(a => a.Evento);
                var autorizacoes = from a in applicationDbContext select a;
                var responsavel = await _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefaultAsync(r => r.ResponsavelId == idDoUsuarioLogado);
                var listaIdDependentes = new List<int>();

                if (responsavel != null) { 
                    if (responsavel.Alunos != null) { 
                        foreach (var aluno in responsavel.Alunos)
                        {
                            listaIdDependentes.Add(aluno.Id);
                        }
                    }
                }
                if (secao.Equals("Assinados"))
                {
                    autorizacoes = autorizacoes.Where(a => listaIdDependentes.Contains((int)a.AlunoId!) && a.Autorizado != null);
                }
                else { 
                    autorizacoes = autorizacoes.Where(a => listaIdDependentes.Contains((int)a.AlunoId!) && a.Autorizado == null);
                }
                ViewData["TituloDaSecao"] = secao;
                return View(await autorizacoes.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: AutorizacoesEventos/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id, string secao = "")
        {
            try
            {
                if (id == null || _context.AutorizacoesEventos == null)
                {
                    return NotFound();
                }

                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var responsavel = await _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefaultAsync(r => r.ResponsavelId == idDoUsuarioLogado);
                var listaIdDependentes = new List<int>();

                if (responsavel != null)
                {
                    if (responsavel.Alunos != null)
                    {
                        foreach (var aluno in responsavel.Alunos)
                        {
                            listaIdDependentes.Add(aluno.Id);
                        }
                    }
                }

                var autorizacaoEvento = await _context.AutorizacoesEventos
                    .Include(a => a.Aluno)
                    .Include(a => a.Evento)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (autorizacaoEvento == null)
                {
                    return NotFound();
                }

                // Verificar se responsável tem permissão para acessar essa URL
                if (autorizacaoEvento.AlunoId != null)
                {
                    if (!listaIdDependentes.Contains((int)autorizacaoEvento.AlunoId))
                    {
                        return Forbid();
                    }
                }
                ViewData["TituloDaSecao"] = secao;
                return View(autorizacaoEvento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: EventosDaAgenda/Visualizar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Visualizar(int id, [Bind("Autorizar")] bool autorizar)
        {
            try { 
                var autorizarEvento = await _context.AutorizacoesEventos!.FirstOrDefaultAsync(a => a.Id == id);
                if (autorizarEvento == null)
                {
                    return NotFound();
                }
                if (autorizarEvento == null)
                {
                    return NotFound();
                }

                int idUsuarioLogado = GetIdUsuarioLogado();
                var usuarioLogado = await _context.Usuarios!.FirstOrDefaultAsync(u => u.Id == idUsuarioLogado);
            
                if (usuarioLogado != null) { 
                    var nomeUsuarioLogado = usuarioLogado!.NomeDisplayLista;
                    autorizarEvento.AssinadoPor = nomeUsuarioLogado;
                }
                autorizarEvento.Autorizado = autorizar;
        
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(autorizarEvento);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AutoriazacoesEventosExists(autorizarEvento.Id))
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
                return View(autorizarEvento);
            }
            catch { 
                return BadRequest();
            }
        }
        private bool AutoriazacoesEventosExists(int id)
        {
            if (_context.AutorizacoesEventos != null) {
                return _context.AutorizacoesEventos.Any(e => e.Id == id);
            }
            return false;
        }

    }
}
