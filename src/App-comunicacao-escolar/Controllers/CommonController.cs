using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace App_comunicacao_escolar.Controllers
{
    public class CommonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult UpdateMsg()
        {
            try
            {
                int idUsuarioLogado = GetIdUsuarioLogado();

                ViewData["idUsuarioLogado"] = idUsuarioLogado;
                return PartialView("ContadorMsg");
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult UpdateAutorizacao()
        {
            try
            {
                int idUsuarioLogado = GetIdUsuarioLogado();

                ViewData["idUsuarioLogado"] = idUsuarioLogado;
                return PartialView("ContadorAutorizacao");
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult UpdateNotificacao()
        {
            try
            {
                int idUsuarioLogado = GetIdUsuarioLogado();

                ViewData["idUsuarioLogado"] = idUsuarioLogado;
                return PartialView("ContadorNotificacao");
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        public FileResult DownloadFile(MensagemArquivosAnexados anexo)
        {
            string fileName = "";
            if (anexo.NomeUnicoDoArquivo != null)
            {
                fileName = anexo.NomeUnicoDoArquivo;
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "uploadsUsuarios", fileName);
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "application/octet-stream", anexo.NomeOriginalDoArquivo);
            }
            catch
            {
                byte[] bytes = Array.Empty<byte>();
                return File(bytes, "application/octet-stream", anexo.NomeOriginalDoArquivo);
            }
        }

        // Metodos comuns
        public int GetIdUsuarioLogado()
        {
            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    ClaimsPrincipal currentUser = User;
                    int? IdUsuarioLogado = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                    if (IdUsuarioLogado != null)
                    {
                        return Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                    }
                }
            }
            return -1;

        }

        public string ReplaceSemiColon(string input)
        {
            return input.Replace(";", ":");
        }

        public void GetCustomErrorMessagesFromTempData()
        {
            if (TempData.ContainsKey("Error"))
                @ViewData["Error"] = TempData["Error"]!.ToString();

            if (TempData.ContainsKey("NomeDosErrosDeValidacao"))
            {
                string NomeDosErrosDeValidacao = TempData["NomeDosErrosDeValidacao"]!.ToString()!;
                List<string> listarErrosDeValidacao = NomeDosErrosDeValidacao!.Split(";").ToList();
                listarErrosDeValidacao.RemoveAt(listarErrosDeValidacao.Count - 1);
                foreach (string error in listarErrosDeValidacao)
                {
                    ViewData[error] = TempData[error]!.ToString();
                }
            }

        }
        public List<string> IsValidCustomizadoHorarios(string horarioInicioLista, string horarioFimLista, string diaDaSemanaListaNumber, string nomeDisciplinaLista = "none;")
        {
            List<string> errorMessage = new();
            if (horarioInicioLista == null || horarioFimLista == null || diaDaSemanaListaNumber == null)
            {
                errorMessage.Add("HorariosDaDisciplina");
                errorMessage.Add("Informar horários das disciplinas!");
                return errorMessage;
            }

            List<string> horarioInicioToList = horarioInicioLista.Split(";").ToList();
            List<string> horarioFimToList = horarioFimLista.Split(";").ToList();
            List<string> diaDaSemanaToList = diaDaSemanaListaNumber.Split(";").ToList();
            if (nomeDisciplinaLista == null)
            {
                nomeDisciplinaLista = "none;";
            }
            List<string> nomeDisciplinaToList = nomeDisciplinaLista.Split(";").ToList();

            if (horarioFimToList.Count != horarioFimToList.Count && horarioInicioToList.Count != diaDaSemanaToList.Count)
            {
                errorMessage.Add("HorariosDaDisciplina");
                errorMessage.Add("Informar horários das disciplinas!");
                return errorMessage;
            }

            // Checar se há conflito de horários 

            List<int> conflitosInicioParaChecar = new();
            List<int> conflitosFimParaChecar = new();

            bool horariosEmConflito = false;
            for (int i = 0; i < (diaDaSemanaToList.Count - 1); i++)
            {
                try
                {
                    int horasInicio = Int32.Parse(horarioInicioToList[i].Substring(0, 2));
                    int minutosInicio = Int32.Parse(horarioInicioToList[i].Substring(3, 2));
                    int horasFim = Int32.Parse(horarioFimToList[i].Substring(0, 2));
                    int minutosFim = Int32.Parse(horarioFimToList[i].Substring(3, 2));
                    var diaDaSemana = Int32.Parse(diaDaSemanaToList[i]);

                    int converterHorarioInicioParaMinutos = minutosInicio + horasInicio * 60 + diaDaSemana * 1440;
                    int converterHorarioFimParaMinutos = minutosFim + horasFim * 60 + diaDaSemana * 1440;

                    // Se o horário de fim da aula for maior que o de inicio, considerar que a aula acaba no dia seguinte.
                    if (converterHorarioInicioParaMinutos > converterHorarioFimParaMinutos)
                    {
                        errorMessage.Add("HorariosDaDisciplina");
                        errorMessage.Add("Horário de fim da disciplina não pode ser antes que o horário de início!");
                        return errorMessage;
                    }

                    for (int j = 0; j < conflitosInicioParaChecar.Count; j++)
                    {
                        if (converterHorarioInicioParaMinutos >= conflitosInicioParaChecar[j] && converterHorarioInicioParaMinutos < conflitosFimParaChecar[j])
                        {
                            horariosEmConflito = true;
                        }
                        if (converterHorarioFimParaMinutos > conflitosInicioParaChecar[j] && converterHorarioFimParaMinutos <= conflitosFimParaChecar[j])
                        {
                            horariosEmConflito = true;
                        }

                        if (converterHorarioInicioParaMinutos < conflitosFimParaChecar[j] && converterHorarioFimParaMinutos > conflitosInicioParaChecar[j])
                        {
                            horariosEmConflito = true;
                        }
                        if (horariosEmConflito)
                        {
                            try
                            {
                                TempData["NomeDaDisciplinaEmConflito1"] = nomeDisciplinaToList[i];
                                TempData["NomeDaDisciplinaEmConflito2"] = nomeDisciplinaToList[j];
                            }
                            catch
                            {

                            }
                            break;
                        }
                    }
                    conflitosInicioParaChecar.Add(converterHorarioInicioParaMinutos);
                    conflitosFimParaChecar.Add(converterHorarioFimParaMinutos);

                    if (horariosEmConflito)
                    {
                        errorMessage.Add("HorariosDaDisciplina");
                        errorMessage.Add("Horários da disciplina entram em conflito!");
                        return errorMessage;
                    }

                }
                catch
                {
                    errorMessage.Add("HorariosDaDisciplina");
                    errorMessage.Add("Informar horários das disciplinas!");
                    return errorMessage;
                }
                // -----------------------------------------------------------------
            }


            return errorMessage;
        }

        public List<int> ListarAgendasQueResponsavelTemAcesso(int responsavelId)
        {
            List<int> idAgendasSelecionadas = new();
            var responsavel = _context.Responsaveis!.Include(r => r.Alunos).FirstOrDefault(r => r.ResponsavelId == responsavelId);
            if (responsavel != null) { 
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
            if (professor != null) { 
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

        public bool ResponsavelNaoTemAcessoALinhaDoTempo(int linhaDoTempoId)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var responsavel = _context.Responsaveis!.Include(r => r.Alunos)!.ThenInclude(a => a.AlunosLinhaDoTempo).FirstOrDefault(r => r.ResponsavelId == idDoUsuarioLogado);
            if (responsavel == null) {
                return true;
            }
            if (responsavel.Alunos == null)
            {
                return true;
            }
            if (responsavel.Alunos.Any(a => a.AlunosLinhaDoTempo!.Id == linhaDoTempoId))
            {
                return false;
            }
            return true;
        }
        public bool ProfessorNaoTemAcessoALinhaDoTempo(int linhaDoTempoId)
        {
            int idDoUsuarioLogado = GetIdUsuarioLogado();
            var professor = _context.Professores!.Include(p => p.Disciplinas).FirstOrDefault(p => p.ProfessorId == idDoUsuarioLogado);
            if (professor == null)
            {
                return true;
            }
            if (professor.Disciplinas == null)
            {
                return true;
            }
            var aluno = _context.Alunos!.Include(a => a.AlunosLinhaDoTempo).FirstOrDefault(a => a.AlunosLinhaDoTempo!.Id == linhaDoTempoId);
            if (aluno == null)
            {
                return true;
            }
            if (aluno.TurmaId == null)
            {
                return true;
            }
            if (professor.Disciplinas.Any(d => d.TurmaId == aluno.TurmaId))
            {
                return false;
            }

            return true;
        }
    }
}
