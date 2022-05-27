using App_comunicacao_escolar.Controllers;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

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
            int numeroContador = 0;
            try {  
                var applicationDbContext = _context.AutorizacoesEventos!.Include(a => a.Aluno).Include(a => a.Evento);
                var autorizacoes = from a in applicationDbContext select a;
                var responsavel = await _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefaultAsync(r => r.ResponsavelId == idUsuarioLogado);
                var listaIdDependentes = new List<int>();
                if (responsavel != null) { 
                    if (responsavel.Alunos != null)
                    {
                        foreach (var aluno in responsavel.Alunos)
                        {
                            listaIdDependentes.Add(aluno.Id);
                        }
                    }
                }
                autorizacoes = autorizacoes.Where(a => listaIdDependentes.Contains((int)a.AlunoId!) && a.Autorizado == null);

                numeroContador = autorizacoes.Count();
            }
            catch
            {

            }
            ViewBag.NumeroContador = numeroContador;
            return View();
        }

    }
}
