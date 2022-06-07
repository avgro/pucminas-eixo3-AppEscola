using App_comunicacao_escolar.Controllers;
using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace App_comunicacao_escolar.ViewComponents
{
    public class ContadorDeNotificacoesNovasViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ContadorDeNotificacoesNovasViewComponent(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(int idUsuarioLogado = -1)
        {
            int numeroContador = 0;
            try
            {
                if (_context.UsuarioLeuNotificacao != null && _context.Notificacoes != null)
                {
                    var notificacoes = from n in _context.Notificacoes select n;
                    if (User.IsInRole("ResponsavelAluno"))
                    {
                        List<int> idAgendasSelecionadas = ListarAgendasQueResponsavelTemAcesso(idUsuarioLogado);
                        notificacoes = notificacoes.Where(n => idAgendasSelecionadas.Contains((int)n.TurmaId!) || n.Turma == null);
                        notificacoes = notificacoes.Where(n => (int)n.Perfil == 1 || n.Perfil == 0);
                    }
                    else if (User.IsInRole("Professor"))
                    {
                        List<int> idAgendasSelecionadas = ListarAgendasQueProfessorTemAcesso(idUsuarioLogado);
                        notificacoes = notificacoes.Where(n => idAgendasSelecionadas.Contains((int)n.TurmaId!) || n.Turma == null);
                        notificacoes = notificacoes.Where(n => (int)n.Perfil == 2 || n.Perfil == 0);
                    }
                    else if (!User.IsInRole("Admin"))
                    {
                        notificacoes = notificacoes.Where(n => n.TurmaId == null || n.Turma == null);
                        notificacoes = notificacoes.Where(n => n.Perfil == 0);
                    }

                    var notificacoesLidas = _context.UsuarioLeuNotificacao.Where(u => u.UsuarioId == idUsuarioLogado);
                    numeroContador = notificacoes.Count() - notificacoesLidas.Count();
                }
            }
            catch 
            {
            }
            ViewBag.NumeroContador = numeroContador;
            
            return View();
        }

        public List<int> ListarAgendasQueResponsavelTemAcesso(int responsavelId)
        {
            List<int> idAgendasSelecionadas = new();
            var responsavel = _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefault(r => r.ResponsavelId == responsavelId);
            if (responsavel != null)
            {
                foreach (var dependente in responsavel.Alunos!)
                {
                    if (dependente.TurmaId != null)
                    {
                        idAgendasSelecionadas.Add((int)dependente.TurmaId);
                    }
                }
            }
            return idAgendasSelecionadas;
        }

        public List<int> ListarAgendasQueProfessorTemAcesso(int professorId)
        {
            List<int> idAgendasSelecionadas = new();
            var professor = _context.Professores!.Include(r => r.Disciplinas).FirstOrDefault(r => r.ProfessorId == professorId);
            if (professor != null)
            {
                foreach (var disciplina in professor.Disciplinas!)
                {
                    if (disciplina.TurmaId != null)
                    {
                        idAgendasSelecionadas.Add((int)disciplina.TurmaId);
                    }
                }
            }
            return idAgendasSelecionadas;
        }

    }
}
