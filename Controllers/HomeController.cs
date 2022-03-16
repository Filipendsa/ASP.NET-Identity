using ASP.NET_Identity.Extensions;
using ASP.NET_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ASP.NET_Identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Secret()
        {
            try
            {
                throw new Exception("Algo não Legal Aconteceu!");
            }catch (Exception e)
            {
                _logger.LogError("Exception information: {0}", e);
                throw;
            }
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }
        //evolucao
        [ClaimsAuthorize("Produtos","Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int Id)
        {
            var modelErro = new ErrorViewModel();

            if (Id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente Novamente mais Tarde ou Contate nosso Suporte.";
                modelErro.Titulo = "Ocorreu um Erro";
                modelErro.ErrorCode = Id;
            }
            else if (Id == 404)
            {
                modelErro.Mensagem = "A Página que está Procurando não Existe! <br />Cheque o URL Inserido, Caso haja Dúvdas, Consulte nosso Suporte..";
                modelErro.Titulo = "Ops! Página não Encontrada";
                modelErro.ErrorCode = Id;
            }
            else if (Id == 403)
            {
                modelErro.Mensagem = "Oops! Parece que Você NÃO tem Permissão para Fazer Isto ";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErrorCode = Id;
            }
            else 
            {
                return StatusCode(500);
            }
            return View("Error", modelErro);
        }
    }
}
