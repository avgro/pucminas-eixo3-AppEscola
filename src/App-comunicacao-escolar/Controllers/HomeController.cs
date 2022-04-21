using App_comunicacao_escolar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App_comunicacao_escolar.Controllers
{
    public class HomeController : CommonController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger) : base(context)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AreaDoUsuario");
            }
            else;
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
        public IActionResult AreaDoUsuario()
        {
            return View();
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