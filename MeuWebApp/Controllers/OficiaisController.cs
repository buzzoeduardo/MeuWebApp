using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Services;
using MeuWebApp.Models;
using MeuWebApp.Models.ViewModels;
using MeuWebApp.Services.Exception;
using System.Diagnostics;

namespace MeuWebApp.Controllers
{
    public class OficiaisController : Controller
    {
        private readonly ServiceVendedor _servicoVendedor;
        private readonly DepartmentService _departmentService;

        public OficiaisController(ServiceVendedor serviceVendedor, DepartmentService departmentService)
        {
            _servicoVendedor = serviceVendedor;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var lista = _servicoVendedor.FindAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FinsAll();
            var viewModel = new ModelodeFormOficiais { Departments = departments };
            return View(viewModel);
        }
        [HttpPost] //Para indicar que a ação do Create é do tipo Post
        [ValidateAntiForgeryToken]//Para prevenir que a aplicação receba ataques CSFR, aquela que aproveita a sessão de autenticação e envia dados maliciosos aproveitando a autenticação
        public IActionResult Create(Oficial oficial)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FinsAll();
                var viewModel = new ModelodeFormOficiais { Oficial = oficial, Departments = departments };
                return View(oficial);
            }
            _servicoVendedor.Inserir(oficial);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id) // A interrogação é para indicar que é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }
            var obj =_servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro inexistente" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro inexistente" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro inexistente" });
            }

            List<Department> departments = _departmentService.FinsAll();
            ModelodeFormOficiais viewModel = new ModelodeFormOficiais { Oficial = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Oficial oficial)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FinsAll();
                var viewModel = new ModelodeFormOficiais { Oficial = oficial, Departments = departments };
                return View(oficial);
            }
            if (id != oficial.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _servicoVendedor.Update(oficial);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
