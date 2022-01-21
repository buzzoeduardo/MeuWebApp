using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Services;
using MeuWebApp.Models;

namespace MeuWebApp.Controllers
{
    public class OficiaisController : Controller
    {
        private readonly ServiceVendedor _servicoVendedor;

        public OficiaisController(ServiceVendedor serviceVendedor)
        {
            _servicoVendedor = serviceVendedor;
        }
        public IActionResult Index()
        {
            var lista = _servicoVendedor.FindAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] //Para indicar que a ação do Create é do tipo Post
        [ValidateAntiForgeryToken]//Para prevenir que a aplicação receba ataques CSFR, aquela que aproveita a sessão de autenticação e envia dados maliciosos aproveitando a autenticação
        public IActionResult Create(Oficial oficial)
        {
            _servicoVendedor.Inserir(oficial);
            return RedirectToAction(nameof(Index));
        }
    }
}
