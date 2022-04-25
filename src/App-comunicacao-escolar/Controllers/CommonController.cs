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
        public IActionResult UpdateMsg()
        {
            int idUsuarioLogado = GetIdUsuarioLogado();
            int numeroDeNovasMensagensNaConversa = 0;
            if (_context.NumeroDeNovasMensagensNaConversa != null) { 
                var mensagensNaoLidasDoUsuarioAtual = _context.NumeroDeNovasMensagensNaConversa.Where(n => n.UsuarioId == idUsuarioLogado);
                foreach (var item in mensagensNaoLidasDoUsuarioAtual)
                {
                    numeroDeNovasMensagensNaConversa += item.NumeroDeMensagensNaoLidas;
                }
            }
            ViewBag.NumeroDeMensagensNovas = numeroDeNovasMensagensNaConversa;
            ViewData["idUsuarioLogado"] = idUsuarioLogado;
            return PartialView("ContadorMsg");
        }

        public FileResult DownloadFile(MensagemArquivosAnexados anexo)
        {
            string fileName = "";
            if (anexo.NomeUnicoDoArquivo != null) { 
                fileName = anexo.NomeUnicoDoArquivo;
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos", "UploadsUsuarios", fileName);
            try { 
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "application/octet-stream", anexo.NomeOriginalDoArquivo);
            }
            catch
            {
                byte[] bytes = Array.Empty<byte>();
                return File(bytes, "application/octet-stream", anexo.NomeOriginalDoArquivo);
            }
        }

        public void Upload()
        {
            
        }

        // Metodos comuns
        public int GetIdUsuarioLogado()
        {
            if (User.Identity != null) { 
                if (User.Identity.IsAuthenticated)
                {
                    ClaimsPrincipal currentUser = User;
                    int? IdUsuarioLogado = Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                    if (IdUsuarioLogado != null) { 
                        return Int32.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                    }
                }
            }
            return -1;

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

    }
}
