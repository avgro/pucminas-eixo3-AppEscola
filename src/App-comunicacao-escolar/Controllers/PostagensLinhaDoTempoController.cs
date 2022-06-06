using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Authorization;

namespace App_comunicacao_escolar.Controllers
{
    [Authorize]
    public class PostagensLinhaDoTempoController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public PostagensLinhaDoTempoController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        [Authorize(Roles = "Professor")]
        public IActionResult Create(int? id)
        {
            try { 
                if (id == null)
                {
                    return NotFound();
                }
                ViewData["LinhaDoTempoId"] = new SelectList(_context.AlunosLinhaDoTempo, "Id", "Id");
                ViewBag.linhaDoTempoId = id;
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: PostagensLinhaDoTempo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> Create([Bind("Id,Assunto,Conteudo,CodigoImagemPostada,LinhaDoTempoId")] PostagemLinhaDoTempo postagemLinhaDoTempo,
            IFormFile? arquivo)
        {
            try { 
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
            catch
            {
                return BadRequest();
            }
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
