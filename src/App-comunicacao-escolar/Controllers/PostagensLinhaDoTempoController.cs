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
    public class PostagensLinhaDoTempoController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public PostagensLinhaDoTempoController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: PostagensLinhaDoTempo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PostagensLinhaDoTempo!.Include(p => p.LinhaDoTempo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PostagensLinhaDoTempo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostagensLinhaDoTempo == null)
            {
                return NotFound();
            }

            var postagemLinhaDoTempo = await _context.PostagensLinhaDoTempo
                .Include(p => p.LinhaDoTempo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagemLinhaDoTempo == null)
            {
                return NotFound();
            }

            return View(postagemLinhaDoTempo);
        }


        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["LinhaDoTempoId"] = new SelectList(_context.AlunosLinhaDoTempo, "Id", "Id");
            ViewBag.linhaDoTempoId = id;
            return View();
        }

        // POST: PostagensLinhaDoTempo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,Conteudo,CodigoImagemPostada,LinhaDoTempoId")] PostagemLinhaDoTempo postagemLinhaDoTempo,
            IFormFile? arquivo)
        {
            postagemLinhaDoTempo.Id = 0;
            postagemLinhaDoTempo = FazerUploadDaImagem(postagemLinhaDoTempo, arquivo);
            postagemLinhaDoTempo.DataCriacao = DateTime.Now;
            postagemLinhaDoTempo.DataAtualizacao = DateTime.Now;
            postagemLinhaDoTempo.AutorId = GetIdUsuarioLogado();

            if (ModelState.IsValid)
            {
                _context.Add(postagemLinhaDoTempo);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "AlunosLinhaDoTempo", action = "Visualizar", id = postagemLinhaDoTempo.LinhaDoTempoId });
            }
            ViewData["LinhaDoTempoId"] = new SelectList(_context.AlunosLinhaDoTempo, "Id", "Id", postagemLinhaDoTempo.LinhaDoTempoId);
            ViewBag.linhaDoTempoId = postagemLinhaDoTempo.LinhaDoTempoId;
            return View(postagemLinhaDoTempo);
        }

        // GET: PostagensLinhaDoTempo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostagensLinhaDoTempo == null)
            {
                return NotFound();
            }

            var postagemLinhaDoTempo = await _context.PostagensLinhaDoTempo.FindAsync(id);
            if (postagemLinhaDoTempo == null)
            {
                return NotFound();
            }
            ViewData["LinhaDoTempoId"] = new SelectList(_context.AlunosLinhaDoTempo, "Id", "Id", postagemLinhaDoTempo.LinhaDoTempoId);
            return View(postagemLinhaDoTempo);
        }

        // POST: PostagensLinhaDoTempo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assunto,Conteudo,CodigoImagemPostada,LinhaDoTempoId")] PostagemLinhaDoTempo postagemLinhaDoTempo)
        {
            if (id != postagemLinhaDoTempo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagemLinhaDoTempo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemLinhaDoTempoExists(postagemLinhaDoTempo.Id))
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
            ViewData["LinhaDoTempoId"] = new SelectList(_context.AlunosLinhaDoTempo, "Id", "Id", postagemLinhaDoTempo.LinhaDoTempoId);
            return View(postagemLinhaDoTempo);
        }

        // GET: PostagensLinhaDoTempo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostagensLinhaDoTempo == null)
            {
                return NotFound();
            }

            var postagemLinhaDoTempo = await _context.PostagensLinhaDoTempo
                .Include(p => p.LinhaDoTempo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagemLinhaDoTempo == null)
            {
                return NotFound();
            }

            return View(postagemLinhaDoTempo);
        }

        // POST: PostagensLinhaDoTempo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostagensLinhaDoTempo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PostagensLinhaDoTempo'  is null.");
            }
            var postagemLinhaDoTempo = await _context.PostagensLinhaDoTempo.FindAsync(id);
            if (postagemLinhaDoTempo != null)
            {
                _context.PostagensLinhaDoTempo.Remove(postagemLinhaDoTempo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemLinhaDoTempoExists(int id)
        {
          return (_context.PostagensLinhaDoTempo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private PostagemLinhaDoTempo FazerUploadDaImagem(PostagemLinhaDoTempo postagem, IFormFile arquivo)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            if (arquivo == null) {
                return postagem;
            }
            if (arquivo!.Length > 0)
            {
                string NomeUnicoDoArquivo = idDoUsuarioLogado + "-" + DateTime.Now.Ticks;
                var TipoDeArquivo = arquivo.FileName.ToString().Split(".");
                NomeUnicoDoArquivo = NomeUnicoDoArquivo + "." + TipoDeArquivo[TipoDeArquivo.Length - 1];
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "uploadsUsuarios", NomeUnicoDoArquivo);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }
                postagem.CodigoImagemPostada = NomeUnicoDoArquivo;
            }

            return postagem;
        }

    }
}
