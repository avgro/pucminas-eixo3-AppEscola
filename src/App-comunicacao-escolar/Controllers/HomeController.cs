using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace App_comunicacao_escolar.Controllers
{
    public class HomeController : CommonController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger) : base(context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity != null) { 
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("AreaDoUsuario");
                }
            }
            return View();
        }

        public IActionResult FaleConosco()
        {
            return View();
        }
        public IActionResult Solucoes()
        {
            return View();
        }
        [Authorize]
        public IActionResult AreaDoUsuario(string numeroDeEventosQuePaginaMostra)
        {
            try { 
                int idDoUsuarioLogado = GetIdUsuarioLogado();

                var eventos = from e in _context.EventosDaAgenda select e;

                if (User.IsInRole("ResponsavelAluno"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueResponsavelTemAcesso(GetIdUsuarioLogado());

                    eventos = eventos.Where(e =>
                        (idAgendasSelecionadas.Contains((int)e.Agenda!.TurmaId!) || e.Agenda == null)
                        &&
                        ((int)e.Agenda!.Perfil == 0 || (int)e.Agenda.Perfil == 1 || e.Agenda == null)
                    );
                }
                else if (User.IsInRole("Professor"))
                {
                    List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(GetIdUsuarioLogado());

                    eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e =>
                        ((int)e.Agenda!.Perfil == 0 || (int)e.Agenda.Perfil == 2 || e.Agenda == null)
                    );
                }
                else if (!User.IsInRole("Admin"))
                {
                    eventos = (IOrderedQueryable<EventoDaAgenda>)eventos.Where(e =>
                        (((int)e.Agenda!.Perfil == 0 && e.Agenda.TurmaId == null) || e.Agenda == null)
                    );
                }

                ViewData["NomeDoUsuario"] = "";
                if (User != null)
                {
                    ViewData["NomeDoUsuario"] = User!.Identity!.Name;
                }

                    ViewBag.numeroDeEventosQuePaginaMostra = 5;
                if (numeroDeEventosQuePaginaMostra != null) { 
                    ViewBag.numeroDeEventosQuePaginaMostra = Int32.Parse(numeroDeEventosQuePaginaMostra);
                }

                var dataAtual = DateTime.Now;
                var dataMaxima = dataAtual.AddDays(30);

                eventos = eventos.Where(e => e.InicioDoEvento >= dataAtual && e.InicioDoEvento <= dataMaxima);

                return View(eventos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MsgUpdate()
        {
            return PartialView("ContadorMsg");
        }
    }
}

public static class HttpExtensions
{
    public static bool IsAjaxRequest(this HttpRequest request)
    {
        if (request == null)
            return false;
        else if (request.Headers != null)
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        return false;
    }
}