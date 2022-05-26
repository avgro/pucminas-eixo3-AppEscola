using App_comunicacao_escolar.Controllers;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace App_comunicacao_escolar.ViewComponents
{
    public class ContadorDeAutorizacoesNovasViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ContadorDeAutorizacoesNovasViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int idUsuarioLogado = -1)
        {
            int numeroDeNovasMensagensNaConversa = 0;
            if (_context.NumeroDeNovasMensagensNaConversa != null && _context.UsuariosQueArquivaramConversa != null) { 
                var mensagensNaoLidasDoUsuarioAtual = _context.NumeroDeNovasMensagensNaConversa.Where(n => n.UsuarioId == idUsuarioLogado);
                
                var mensagensArquivadasDoUsuarioAtual = _context.UsuariosQueArquivaramConversa.Where(u => u.UsuarioId == idUsuarioLogado);
                foreach (var item in mensagensNaoLidasDoUsuarioAtual)
                {
                    if (!mensagensArquivadasDoUsuarioAtual.Any(m => m.ConversaId == item.ConversaId))
                    {
                        numeroDeNovasMensagensNaConversa += item.NumeroDeMensagensNaoLidas;
                    }
                }
            }
            numeroDeNovasMensagensNaConversa += 7;
            ViewBag.NumeroDeMensagensNovas = numeroDeNovasMensagensNaConversa;
            
            return View();
        }

    }
}
