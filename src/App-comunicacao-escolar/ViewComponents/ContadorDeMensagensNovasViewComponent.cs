using App_comunicacao_escolar.Controllers;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace App_comunicacao_escolar.ViewComponents
{
    public class ContadorDeMensagensNovasViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ContadorDeMensagensNovasViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int idUsuarioLogado = -1)
        {
            var mensagensNaoLidasDoUsuarioAtual = _context.numeroDeNovasMensagensNaConversa.Where(n => n.UsuarioId == idUsuarioLogado);
            int numeroDeNovasMensagensNaConversa = 0;
            foreach (var item in mensagensNaoLidasDoUsuarioAtual)
            {
                numeroDeNovasMensagensNaConversa += item.NumeroDeMensagensNaoLidas;
            }
            ViewBag.NumeroDeMensagensNovas = numeroDeNovasMensagensNaConversa;
            
            return View();
        }

    }
}
