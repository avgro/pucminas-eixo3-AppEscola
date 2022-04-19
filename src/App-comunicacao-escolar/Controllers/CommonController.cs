﻿using App_comunicacao_escolar.Models;
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
            var mensagensNaoLidasDoUsuarioAtual = _context.NumeroDeNovasMensagensNaConversa.Where(n => n.UsuarioId == idUsuarioLogado);
            int numeroDeNovasMensagensNaConversa = 0;
            foreach (var item in mensagensNaoLidasDoUsuarioAtual)
            {
                numeroDeNovasMensagensNaConversa += item.NumeroDeMensagensNaoLidas;
            }
            ViewBag.NumeroDeMensagensNovas = numeroDeNovasMensagensNaConversa;
            ViewData["idUsuarioLogado"] = idUsuarioLogado;
            return PartialView("ContadorMsg");
        }

        public FileResult DownloadFile(MensagemArquivosAnexados anexo)
        {
            string fileName = anexo.NomeUnicoDoArquivo;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos", "UploadsUsuarios", fileName);
            try { 
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "application/octet-stream", anexo.NomeOriginalDoArquivo);
            }
            catch
            {
                return null;
            }
        }

        public void Upload()
        {
            
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

        public void getCustomErrorMessagesFromTempData()
        {
            if (TempData.ContainsKey("Error"))
                @ViewData["Error"] = TempData["Error"].ToString();

            if (TempData.ContainsKey("NomeDosErrosDeValidacao"))
            {
                string NomeDosErrosDeValidacao = TempData["NomeDosErrosDeValidacao"].ToString();
                List<string> listarErrosDeValidacao = NomeDosErrosDeValidacao.Split(";").ToList();
                listarErrosDeValidacao.RemoveAt(listarErrosDeValidacao.Count - 1);
                foreach (string error in listarErrosDeValidacao)
                {
                    ViewData[error] = TempData[error].ToString();
                }
            }

        }

    }
}