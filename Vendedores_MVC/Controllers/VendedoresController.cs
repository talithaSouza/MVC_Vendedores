using Microsoft.AspNetCore.Mvc;
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

            return View(vendedor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            if (!_service.Deletar((int)id))
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var obj = _service.RetornarPorId((int)id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var vendedor = _service.RetornarPorId((int)id);
            if (vendedor == null)
                return NotFound();

            VendedorFormViewModel obj = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = _departamentoService.RetornarTodos() };

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
                return BadRequest();

            try
            {
                _service.Atualizar(vendedor);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }
    }
}
