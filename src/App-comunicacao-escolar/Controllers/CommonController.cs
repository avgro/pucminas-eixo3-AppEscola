using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace App_comunicacao_escolar.Controllers
{
    public class CommonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> UpdateMsg()
        {
            int idUsuarioLogado = GetIdUsuarioLogado();
            var mensagensNaoLidasDoUsuarioAtual = await Task.Run(() => _context.numeroDeNovasMensagensNaConversa.Where(n => n.UsuarioId == idUsuarioLogado));
            int numeroDeNovasMensagensNaConversa = 0;
            foreach (var item in mensagensNaoLidasDoUsuarioAtual)
            {
                numeroDeNovasMensagensNaConversa += item.NumeroDeMensagensNaoLidas;
            }
            ViewBag.NumeroDeMensagensNovas = numeroDeNovasMensagensNaConversa;
            return PartialView("ContadorMsg");
        }
        
        // Metodos comuns
        public int GetIdUsuarioLogado()
        {
            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = User;
                return Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            return -1;
        }

    }
}
