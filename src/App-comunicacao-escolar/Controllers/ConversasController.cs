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
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace App_comunicacao_escolar.Controllers
{
    [Authorize]
    public class ConversasController : CommonController
    {
        private readonly ApplicationDbContext _context;

        public ConversasController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Conversas
        public async Task<IActionResult> Index(string searchString, string secao = "Caixa de entrada", int pagina = 1)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();

                var applicationDbContext = _context.Conversas.Include(c => c.Participantes).Include(c => c.NumeroDeNovasMensagensNaConversa).Include(c => c.UsuariosQueArquivaramConversa);

                var conversas = from c in applicationDbContext select c;

                conversas = conversas.OrderByDescending(c => c.Id);

                if (secao.Equals("Enviados"))
                {
                    conversas = conversas.Where(d => d.RemetenteId == idDoUsuarioLogado && !d.UsuariosQueArquivaramConversa.Any(u => u.UsuarioId == idDoUsuarioLogado));
                }
                else if (secao.Equals("Arquivados"))
                {
                    conversas = conversas.Where(d => d.UsuariosQueArquivaramConversa.Any(u => u.UsuarioId == idDoUsuarioLogado));
                }
                else
                {
                    conversas = conversas.Where(d => d.Participantes.Any(p => p.Id == idDoUsuarioLogado && !d.UsuariosQueArquivaramConversa.Any(u => u.UsuarioId == idDoUsuarioLogado)));
                }

                if (searchString != null)
                {
                    conversas = conversas.Where(d => d.Assunto.Contains(searchString) || d.Mensagens.Any(m => m.Conteudo.Contains(searchString)));
                }
                ViewBag.IdUsuarioLogado = idDoUsuarioLogado;
                ViewData["TituloDaSecao"] = secao;
                ViewData["pagina"] = pagina;
                ViewData["searchString"] = searchString;

                return View(await conversas.ToPagedListAsync(pagina, 50));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Conversas/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id, string secao)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var applicationDbContext = _context.Conversas.Include(c => c.Mensagens.Where(m => m.Participantes.Any(p => p.Id == idDoUsuarioLogado) || m.RemetenteId == idDoUsuarioLogado)).ThenInclude(m => m.Anexos).Include(c => c.Participantes);
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
                ViewData["ParticipanteId"] = new SelectList(_context.Usuarios.OrderBy(u => u.NomeDisplayLista), "Id", "NomeDisplayLista");

                // Zerar contador de mensagens da conversa
                var numeroDeNovasMensagensNaConversa = await _context.NumeroDeNovasMensagensNaConversa.FirstOrDefaultAsync(n => n.UsuarioId == idDoUsuarioLogado && n.ConversaId == conversa.Id);
                if (numeroDeNovasMensagensNaConversa != null)
                {
                    _context.NumeroDeNovasMensagensNaConversa.Remove(numeroDeNovasMensagensNaConversa);
                }
                await _context.SaveChangesAsync();

                GetCustomErrorMessagesFromTempData();

                if (TempData.ContainsKey("Conteudo"))
                    @ViewData["Conteudo"] = TempData["Conteudo"].ToString();

                if (TempData.ContainsKey("mensagemRespondidaId"))
                    @ViewData["mensagemRespondidaId"] = TempData["mensagemRespondidaId"].ToString();

                ViewData["TituloDaSecao"] = secao;
                return View(conversa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Arquivar([Bind("conversaId")] int conversaId)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                var usuariosQueArquivaramConversa = await _context.UsuariosQueArquivaramConversa.FirstOrDefaultAsync(n => n.UsuarioId == idDoUsuarioLogado && n.ConversaId == conversaId);
                if (usuariosQueArquivaramConversa == null)
                {
                    UsuariosQueArquivaramConversa novoUsuarioqueArquivouConversa = new()
                    {
                        UsuarioId = idDoUsuarioLogado,
                        ConversaId = conversaId
                    };
                    _context.Add(novoUsuarioqueArquivouConversa);
                    await _context.SaveChangesAsync();
                }
                return RedirectToRoute(new { controller = "Conversas", action = "Index" });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desarquivar([Bind("conversaId")] int conversaId)
        {
            try
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
            catch
            {
                return BadRequest();
            }
        }

        // GET: Conversas/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["ParticipanteId"] = new SelectList(_context.Usuarios.OrderBy(u => u.NomeDisplayLista), "Id", "NomeDisplayLista");

                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Conversas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,PrimeiraMensagem,RemetenteNome,RemetenteId")] Conversa conversa,
            [Bind("listaDePessoasPorId")] string listaDePessoasPorId,
            List<IFormFile> arquivos,
            Mensagem mensagem)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                mensagem.DataEnvio = DateTime.Now;
                mensagem.Conteudo = conversa.PrimeiraMensagem;
                mensagem.RemetenteId = idDoUsuarioLogado;
                mensagem.RemetenteNome = _context.Usuarios.FirstOrDefault(u => u.Id == idDoUsuarioLogado).NomeDisplayLista;

                conversa.RemetenteNome = mensagem.RemetenteNome;
                conversa.RemetenteId = mensagem.RemetenteId;
                mensagem.ListaDestinatarios = listaDePessoasPorId;

                // Faz validação dos atributos que não podem ser diretamente validados pelo Entity Framework e retorna as mensagens de erro como ViewData ou TempData.
                List<string> listarErrosDeValidacao = IsValidCustomizadoCreate(mensagem, arquivos);
                while (listarErrosDeValidacao.Count > 0)
                {
                    ViewData["Error"] = "Error";
                    ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                    ViewData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                    listarErrosDeValidacao.RemoveRange(0, 2);
                }
                // -----------------------------------------------------------------------------------------
                if (ModelState.IsValid)
                {
                    conversa.Participantes = new List<Usuario>();
                    conversa.Mensagens = new List<Mensagem>();
                    conversa.NumeroDeNovasMensagensNaConversa = new List<NumeroDeNovasMensagensNaConversa>();
                    mensagem.Participantes = new List<Usuario>();

                    mensagem = FazerUploadDosArquivosAnexados(mensagem, arquivos);

                    // Converte a string "listaDeDesinatariosPorId" em uma lista e realiza todas as operações necessárias para cada destinatário
                    List<string> listaRemetentes = listaDePessoasPorId.Split(";").ToList();
                    string listaDePessoasPorNome = "";
                    for (int i = 0; i < (listaRemetentes.Count - 1); i++)
                    {
                        int remetenteId = int.Parse(listaRemetentes[i]);
                        Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(s => s.Id == remetenteId);
                        conversa.Participantes.Add(usuario);
                        mensagem.Participantes.Add(usuario);

                        NumeroDeNovasMensagensNaConversa numeroDeNovasMensagensNaConversa = new()
                        {
                            UsuarioId = usuario.Id,
                            NumeroDeMensagensNaoLidas = 1
                        };
                        conversa.NumeroDeNovasMensagensNaConversa.Add(numeroDeNovasMensagensNaConversa);

                        listaDePessoasPorNome += usuario.NomeDisplayLista.Replace(";", ":") + "; ";
                    }
                    mensagem.ListaDestinatariosNome = listaDePessoasPorNome;
                    // -----------------------------------------------------------------------------------------

                    conversa.Mensagens.Add(mensagem);
                    _context.Add(conversa);
                    _context.Add(mensagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ParticipanteId"] = new SelectList(_context.Usuarios.OrderBy(u => u.NomeDisplayLista), "Id", "NomeDisplayLista");
                return View(conversa);
            }
            catch
            {
                return BadRequest();
            }
        }


        // POST: Conversas/CreateResposta
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResposta(Mensagem mensagem, [Bind("conteudoMensagem")] string conteudoMensagem,
            [Bind("conversaId")] int conversaId, [Bind("mensagemRespondidaId")] int mensagemRespondidaId,
            [Bind("listaDePessoasPorId")] string listaDePessoasPorId, List<IFormFile> arquivos)
        {
            try
            {
                int idDoUsuarioLogado = GetIdUsuarioLogado();
                mensagem.ConversaId = conversaId;
                mensagem.MensagemRespondidaId = mensagemRespondidaId;
                mensagem.DataEnvio = DateTime.Now;
                mensagem.Conteudo = conteudoMensagem;
                mensagem.ListaDestinatarios = listaDePessoasPorId;
                mensagem.RemetenteId = idDoUsuarioLogado;
                mensagem.RemetenteNome = _context.Usuarios.FirstOrDefault(u => u.Id == idDoUsuarioLogado).NomeDisplayLista;

                Conversa conversa = _context.Conversas.Include(c => c.Participantes).Include(c => c.NumeroDeNovasMensagensNaConversa).FirstOrDefault(u => u.Id == conversaId);

                // Bloquear o usuario de postar em conversa da qual não faz parte via inspetor de código.
                bool usuarioIsParticipanteDaConversa = conversa.Participantes.Any(p => p.Id == idDoUsuarioLogado) || conversa.RemetenteId == idDoUsuarioLogado;


                // Faz validação dos atributos que não podem ser diretamente validados pelo Entity Framework e retorna as mensagens de erro como ViewData ou TempData.
                List<string> listarErrosDeValidacao = IsValidCustomizadoCreateResposta(mensagem, arquivos);
                while (listarErrosDeValidacao.Count > 0)
                {
                    TempData["Error"] = "Error";
                    ModelState.AddModelError(listarErrosDeValidacao[0], listarErrosDeValidacao[1]);
                    TempData[listarErrosDeValidacao[0]] = listarErrosDeValidacao[1];
                    TempData["NomeDosErrosDeValidacao"] += listarErrosDeValidacao[0] + ";";
                    listarErrosDeValidacao.RemoveRange(0, 2);
                }
                // -----------------------------------------------------------------------------------------

                if (ModelState.IsValid! && usuarioIsParticipanteDaConversa)
                {
                    mensagem.Participantes = new List<Usuario>();

                    mensagem = FazerUploadDosArquivosAnexados(mensagem, arquivos);

                    // Converte a string "listaDeDesinatariosPorId" em uma lista e realiza todas as operações necessárias para cada destinatário
                    List<string> listaRemetentes = listaDePessoasPorId.Split(";").ToList();
                    string listaDePessoasPorNome = "";
                    for (int i = 0; i < (listaRemetentes.Count - 1); i++)
                    {
                        int remetenteId = int.Parse(listaRemetentes[i]);
                        Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == remetenteId);
                        if (usuario != null)
                        {
                            mensagem.Participantes.Add(usuario);

                            if (!conversa.Participantes.Contains(usuario))
                            {
                                conversa.Participantes.Add(usuario);

                            }

                            NumeroDeNovasMensagensNaConversa numeroDeNovasMensagensNaConversa = await _context.NumeroDeNovasMensagensNaConversa.FirstOrDefaultAsync(n => n.UsuarioId == usuario.Id && n.ConversaId == conversaId);
                            if (numeroDeNovasMensagensNaConversa == null)
                            {
                                numeroDeNovasMensagensNaConversa = new()
                                {
                                    UsuarioId = usuario.Id,
                                    ConversaId = conversaId,
                                    NumeroDeMensagensNaoLidas = 1
                                };
                                conversa.NumeroDeNovasMensagensNaConversa.Add(numeroDeNovasMensagensNaConversa);
                            }
                            else
                            {
                                numeroDeNovasMensagensNaConversa.NumeroDeMensagensNaoLidas += 1;
                                _context.Update(numeroDeNovasMensagensNaConversa);
                            }

                            listaDePessoasPorNome += usuario.NomeDisplayLista.Replace(";", ":") + "; ";
                        }
                    }
                    // -----------------------------------------------------------------------------------------

                    mensagem.ListaDestinatariosNome = listaDePessoasPorNome;
                    _context.Add(mensagem);
                    _context.Update(conversa);
                    await _context.SaveChangesAsync();
                }
                if (TempData.ContainsKey("Error"))
                {
                    if (mensagem.Conteudo == null)
                    {
                        mensagem.Conteudo = "";
                    }
                    TempData["Conteudo"] = mensagem.Conteudo;
                    TempData["mensagemRespondidaId"] = mensagem.MensagemRespondidaId;
                }
                return RedirectToAction("Visualizar", new { id = mensagem.ConversaId });
            }
            catch
            {
                return BadRequest();
            }
        }

        // Metodos

        private Mensagem FazerUploadDosArquivosAnexados(Mensagem mensagem, List<IFormFile> arquivos)
        {

            mensagem.Anexos = new List<MensagemArquivosAnexados>();
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var size = arquivos.Sum(a => a.Length);
            var filePaths = new List<string>();
            foreach (var formFile in arquivos)
            {
                if (formFile.Length > 0)
                {
                    MensagemArquivosAnexados anexo = new()
                    {
                        NomeOriginalDoArquivo = formFile.FileName,
                        NomeUnicoDoArquivo = idDoUsuarioLogado + "-" + DateTime.Now.Ticks
                    };
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "uploadsUsuarios", anexo.NomeUnicoDoArquivo);
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

        // Metodos - Validação de atributos cuja validação não é diretamente coberta pelo Entity Framework
        private List<string> IsValidCustomizadoCreate(Mensagem mensagem, List<IFormFile> arquivos)
        {
            List<string> errorMessage = new();
            if (mensagem.ListaDestinatarios == null)
            {
                errorMessage.Add("listaDePessoasPorIdError");
                errorMessage.Add("Selecione pelo menos um destinatário!");
            };
            long formFileTotalSyzeKb = 0;
            foreach (var formFile in arquivos)
            {
                formFileTotalSyzeKb += formFile.Length;
            }
            if (formFileTotalSyzeKb > 25000000)
            {
                errorMessage.Add("arquivosError");
                errorMessage.Add("Tamanho dos arquivos não pode exceder 25 MB!");
            };
            return errorMessage;
        }
        private List<string> IsValidCustomizadoCreateResposta(Mensagem mensagem, List<IFormFile> arquivos)
        {
            List<string> errorMessage = new();
            if (mensagem.ListaDestinatarios == null)
            {
                errorMessage.Add("listaDePessoasPorIdError");
                errorMessage.Add("Selecione pelo menos um destinatário!");
            };
            long formFileTotalSyzeKb = 0;
            foreach (var formFile in arquivos)
            {
                formFileTotalSyzeKb += formFile.Length;
            }
            if (mensagem.Conteudo == null)
            {
                errorMessage.Add("conteudoMensagemError");
                errorMessage.Add("Inserir conteúdo da mensagem!");
            };
            if (formFileTotalSyzeKb > 25000000)
            {
                errorMessage.Add("arquivosError");
                errorMessage.Add("Tamanho dos arquivos não pode exceder 25 MB!");
            };
            return errorMessage;
        }

    }
}
