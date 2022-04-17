#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_comunicacao_escolar.Models;
using System.Security.Claims;

namespace App_comunicacao_escolar.Controllers
{
    public class ConversasController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public ConversasController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Conversas
        public async Task<IActionResult> Index(string? searchString, string? secao = "Caixa de entrada")
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();

            var applicationDbContext = await Task.Run(() => _context.Conversas.Include(c => c.Participantes).Include(c => c.NumeroDeNovasMensagensNaConversa).Include(c => c.UsuariosQueArquivaramConversa));

            var conversas = await Task.Run(() => from c in applicationDbContext select c);

            conversas = conversas.OrderByDescending(c => c.Id);

            if (secao.Equals("Enviados"))
            {
                conversas = await Task.Run(() => conversas.Where(d => d.RemetenteId == idDoUsuarioLogado));
            }
            else
            {
                conversas = await Task.Run(() => conversas.Where(d => d.Participantes.Any(p => p.Id == idDoUsuarioLogado)));
            }

            if (secao.Equals("Arquivados"))
            {
                conversas = await Task.Run(() => conversas.Where(d => d.UsuariosQueArquivaramConversa.Any(u => u.UsuarioId == idDoUsuarioLogado)));
            }
            else
            {
                conversas = await Task.Run(() => conversas.Where(d => !d.UsuariosQueArquivaramConversa.Any(u => u.UsuarioId == idDoUsuarioLogado)));
            }

            if (searchString != null)
            {
                conversas = await Task.Run(() => conversas.Where(d => d.Assunto.Contains(searchString) || d.Mensagens.Any(m => m.Conteudo.Contains(searchString))));
            }
            ViewBag.IdUsuarioLogado = idDoUsuarioLogado;
            ViewData["TituloDaSecao"] = secao;
            ViewData["searchString"] = searchString;
            return View(conversas);
        }

        // GET: Conversas/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var applicationDbContext = await Task.Run(() => _context.Conversas.Include(c => c.Mensagens.Where(m => m.Participantes.Any(p => p.Id == idDoUsuarioLogado) || m.RemetenteId == idDoUsuarioLogado)).ThenInclude(m => m.Anexos).Include(c => c.Participantes));
            var conversa = await applicationDbContext
                .FirstOrDefaultAsync(c => c.Id == id);

            // Bloquear acesso de usuario via URL caso ele não seja participante da conversa.
            bool usuarioIsParticipanteDaConversa = conversa.Participantes.Any(p => p.Id == idDoUsuarioLogado) || conversa.RemetenteId == idDoUsuarioLogado;
            if (!usuarioIsParticipanteDaConversa)
            {
                return Forbid();
            }

            if (conversa == null)
            {
                return NotFound();
            }
            ViewData["ParticipanteId"] = new SelectList(_context.Usuarios, "Id", "Nome");

            // Zerar contador de mensagens da conversa
            var numeroDeNovasMensagensNaConversa = await _context.NumeroDeNovasMensagensNaConversa.FirstOrDefaultAsync(n => n.UsuarioId == idDoUsuarioLogado && n.ConversaId == conversa.Id);
            if (numeroDeNovasMensagensNaConversa != null)
            {
                _context.NumeroDeNovasMensagensNaConversa.Remove(numeroDeNovasMensagensNaConversa);
            }
            await _context.SaveChangesAsync();

            return View(conversa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Arquivar([Bind("conversaId")] int conversaId)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var usuariosQueArquivaramConversa = await _context.UsuariosQueArquivaramConversa.FirstOrDefaultAsync(n => n.UsuarioId == idDoUsuarioLogado && n.ConversaId == conversaId);
            if (usuariosQueArquivaramConversa == null)
            {
                UsuariosQueArquivaramConversa novoUsuarioqueArquivouConversa = new UsuariosQueArquivaramConversa();
                novoUsuarioqueArquivouConversa.UsuarioId = idDoUsuarioLogado;
                novoUsuarioqueArquivouConversa.ConversaId = conversaId;
                _context.Add(novoUsuarioqueArquivouConversa);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Conversas", action = "Index" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desarquivar([Bind("conversaId")] int conversaId)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var usuariosQueArquivaramConversa = await _context.UsuariosQueArquivaramConversa.FirstOrDefaultAsync(n => n.UsuarioId == idDoUsuarioLogado && n.ConversaId == conversaId);
            if (usuariosQueArquivaramConversa != null)
            {
                _context.Remove(usuariosQueArquivaramConversa);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Conversas", action = "Index", secao = "Arquivados" });
        }

        // GET: Conversas/Create
        public IActionResult Create()
        {
            ViewData["ParticipanteId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Conversas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,PrimeiraMensagem,RemetenteNome,RemetenteId")] Conversa conversa, 
            [Bind("listaDeDestinatariosPorId")] string listaDeDestinatariosPorId,
            List<IFormFile> arquivos,
            Mensagem mensagem)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            mensagem.DataEnvio = DateTime.Now;
            mensagem.Conteudo = conversa.PrimeiraMensagem;
            mensagem.RemetenteId = idDoUsuarioLogado;
            mensagem.RemetenteNome = await Task.Run(() => _context.Usuarios.FirstOrDefault(u => u.Id == idDoUsuarioLogado).Nome);

            conversa.RemetenteNome = mensagem.RemetenteNome;
            conversa.RemetenteId = mensagem.RemetenteId;
            mensagem.listaDestinatarios = listaDeDestinatariosPorId;

            List<string> listarErrosDeValidacao = isValidCustomizadoCreate(conversa, mensagem, arquivos);
            if (listarErrosDeValidacao.Count > 0)
            {
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
            }

            ViewBag.ValidationError = true;
            if (ModelState.IsValid)
            {
                ViewBag.ValidationError = false;
                conversa.Participantes = new List<Usuario>();
                conversa.Mensagens = new List<Mensagem>();
                conversa.NumeroDeNovasMensagensNaConversa = new List<NumeroDeNovasMensagensNaConversa>();
                mensagem.Participantes = new List<Usuario>();

                mensagem = await Task.Run(() => fazerUploadDosArquivosAnexados(mensagem, arquivos));


                List<string> listaRemetentes = listaDeDestinatariosPorId.Split(";").ToList();
        
                string listaDeDestinatariosPorNome = "";
                for (int i = 0; i < (listaRemetentes.Count - 1); i++)
                {
                    int remetenteId = int.Parse(listaRemetentes[i]);
                    Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(s => s.Id == remetenteId);
                    conversa.Participantes.Add(usuario);
                    mensagem.Participantes.Add(usuario);

                    NumeroDeNovasMensagensNaConversa numeroDeNovasMensagensNaConversa = new NumeroDeNovasMensagensNaConversa();
                    numeroDeNovasMensagensNaConversa.UsuarioId = usuario.Id;
                    numeroDeNovasMensagensNaConversa.NumeroDeMensagensNaoLidas = 1;
                    conversa.NumeroDeNovasMensagensNaConversa.Add(numeroDeNovasMensagensNaConversa);

                    listaDeDestinatariosPorNome += usuario.Nome + "; ";
                }

                mensagem.listaDestinatariosNome = listaDeDestinatariosPorNome;

                conversa.Mensagens.Add(mensagem);
                _context.Add(conversa);
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParticipanteId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View(conversa);
        }


        // POST: Conversas/CreateResposta
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResposta(Mensagem mensagem, [Bind("conteudoMensagem")] string conteudoMensagem, 
            [Bind("conversaId")] int conversaId, [Bind("mensagemRespondidaId")] int mensagemRespondidaId, 
            [Bind("listaDeDestinatariosPorId")] string listaDeDestinatariosPorId, List<IFormFile> arquivos)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            mensagem.ConversaId = conversaId;
            mensagem.MensagemRespondidaId = mensagemRespondidaId;
            mensagem.DataEnvio = DateTime.Now;
            mensagem.Conteudo = conteudoMensagem;
            mensagem.listaDestinatarios= listaDeDestinatariosPorId;
            mensagem.RemetenteId = idDoUsuarioLogado;
            mensagem.RemetenteNome = await Task.Run(() => _context.Usuarios.FirstOrDefault(u => u.Id == idDoUsuarioLogado).Nome);

            Conversa conversa = await Task.Run(() => _context.Conversas.Include(c => c.Participantes).Include(c => c.NumeroDeNovasMensagensNaConversa).FirstOrDefault(u => u.Id == conversaId));
            
            // Bloquear o usuario de postar em conversa da qual não faz parte via inspetor de código.
            bool usuarioIsParticipanteDaConversa = conversa.Participantes.Any(p => p.Id == idDoUsuarioLogado) || conversa.RemetenteId == idDoUsuarioLogado;

            List<string> listarErrosDeValidacao = isValidCustomizadoCreateResposta(mensagem, arquivos);
            if (listarErrosDeValidacao.Count > 0)
            {
                ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
            }

            ViewBag.ValidationError = true;
            if (ModelState.IsValid! && usuarioIsParticipanteDaConversa)
            {
                ViewBag.ValidationError = false;
                mensagem.Participantes = new List<Usuario>();

                mensagem = await Task.Run(() => fazerUploadDosArquivosAnexados(mensagem, arquivos));

                List<string> listaRemetentes = listaDeDestinatariosPorId.Split(";").ToList();

                string listaDeDestinatariosPorNome = "";
                for (int i = 0; i < (listaRemetentes.Count - 1); i++)
                {
                    int remetenteId = int.Parse(listaRemetentes[i]);
                    Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == remetenteId);
                    mensagem.Participantes.Add(usuario);

                    if (!conversa.Participantes.Contains(usuario))
                    {
                        conversa.Participantes.Add(usuario);

                    }

                    NumeroDeNovasMensagensNaConversa numeroDeNovasMensagensNaConversa = await Task.Run(() => _context.NumeroDeNovasMensagensNaConversa.FirstOrDefault(n => n.UsuarioId == usuario.Id && n.ConversaId == conversaId));
                    if (numeroDeNovasMensagensNaConversa == null)
                    {
                        numeroDeNovasMensagensNaConversa = new NumeroDeNovasMensagensNaConversa();
                        numeroDeNovasMensagensNaConversa.UsuarioId = usuario.Id;
                        numeroDeNovasMensagensNaConversa.ConversaId = conversaId;
                        numeroDeNovasMensagensNaConversa.NumeroDeMensagensNaoLidas = 1;
                        conversa.NumeroDeNovasMensagensNaConversa.Add(numeroDeNovasMensagensNaConversa);
                    }
                    else
                    {
                        numeroDeNovasMensagensNaConversa.NumeroDeMensagensNaoLidas += 1;
                        _context.Update(numeroDeNovasMensagensNaConversa);
                    }
                    
                    listaDeDestinatariosPorNome += usuario.Nome + "; ";
                }
                mensagem.listaDestinatariosNome = listaDeDestinatariosPorNome;
                _context.Add(mensagem);
                _context.Update(conversa);
                await _context.SaveChangesAsync();
            }
            ViewBag.ValidationError = true;
            return RedirectToRoute(new { controller = "Conversas", action = "Visualizar", id = mensagem.ConversaId });//
        }

        // Metodos


        private List<string> isValidCustomizadoCreate(Conversa conversa, Mensagem mensagem, List<IFormFile> arquivos)
        {
            List<string> errorMessage = new List<string>();
            if (mensagem.listaDestinatarios == null)
            {
                errorMessage.Add("Participantes");
                errorMessage.Add("Selecione pelo menos um destinatário!");
            };
            long formFileTotalSyzeKb = 0;
            foreach (var formFile in arquivos)
            {
                formFileTotalSyzeKb += formFile.Length;
            }
            if (formFileTotalSyzeKb > 2)
            {
                errorMessage.Add("Mensagens");
                errorMessage.Add("Tamanho dos arquivos não pode exceder 25 MB!");
            };
            return errorMessage;
        }
        private List<string> isValidCustomizadoCreateResposta(Mensagem mensagem, List<IFormFile> arquivos)
        {
            List<string> errorMessage = new List<string>();
            if (mensagem.listaDestinatarios == null)
            {
                errorMessage.Add("Participantes");
                errorMessage.Add("Selecione pelo menos um destinatário!");
            };
            long formFileTotalSyzeKb = 0;
            foreach (var formFile in arquivos)
            {
                formFileTotalSyzeKb += formFile.Length;
            }
            if (formFileTotalSyzeKb > 25000000)
            {
                errorMessage.Add("Mensagens");
                errorMessage.Add("Tamanho dos arquivos não pode exceder 25 MB!");
            };
            return errorMessage;
        }

        private Mensagem fazerUploadDosArquivosAnexados(Mensagem mensagem, List<IFormFile> arquivos)
        {

            mensagem.Anexos = new List<MensagemArquivosAnexados>();
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var size = arquivos.Sum(a => a.Length);
            var filePaths = new List<string>();
            foreach (var formFile in arquivos)
            {
                if (formFile.Length > 0)
                {
                    MensagemArquivosAnexados anexo = new MensagemArquivosAnexados();
                    anexo.NomeOriginalDoArquivo = formFile.FileName;
                    anexo.NomeUnicoDoArquivo = idDoUsuarioLogado + "-" + DateTime.Now.Ticks;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos", "UploadsUsuarios", anexo.NomeUnicoDoArquivo);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    mensagem.Anexos.Add(anexo);
                }

            }
            return mensagem;
        }

    }
}
