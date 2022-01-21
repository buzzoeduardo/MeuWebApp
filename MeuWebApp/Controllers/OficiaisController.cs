using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Services;

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


    }
}
