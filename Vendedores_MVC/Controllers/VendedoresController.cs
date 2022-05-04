using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vendedores_MVC.Models;
using Vendedores_MVC.Models.ViewModels;
using Vendedores_MVC.Service;
using Vendedores_MVC.Service.Exceptions;

namespace Vendedores_MVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _service;
        private readonly DepartamentoService _departamentoService;


        public VendedoresController(VendedorService service, DepartamentoService departamentoService)
        {
            _service = service;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {

            return View(_service.RetornarTodos());
        }

        public IActionResult Create()
        {
            VendedorFormViewModel viewModel = new VendedorFormViewModel()
            {
                Departamentos = _departamentoService.RetornarTodos()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _service.Cadastrar(vendedor);
                return RedirectToAction(nameof(Index));
            }

            VendedorFormViewModel viewModel = new VendedorFormViewModel() { Departamentos = _departamentoService.RetornarTodos(), Vendedor = vendedor };
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não foi fornececido" }); ;

            if (!_service.Deletar((int)id))
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" }); ;

            var obj = _service.RetornarPorId((int)id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });

            var vendedor = _service.RetornarPorId((int)id);
            if (vendedor == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });

            VendedorFormViewModel obj = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = _departamentoService.RetornarTodos() };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não conrreponde com o objeto a editar" }); ;

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Atualizar(vendedor);

                    return RedirectToAction(nameof(Index));
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction(nameof(Error), new { mensagem = ex.Message });
                }
                catch (DbConcurrencyException ex)
                {
                    return RedirectToAction(nameof(Error), new { mensagem = ex.Message });
                } 
            }

            VendedorFormViewModel obj = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = _departamentoService.RetornarTodos() };
            return View(obj);

        }

        public IActionResult Error(string mensagem)
        {
            var viewModel = new ErrorViewModel()
            {
                Mensagem = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
