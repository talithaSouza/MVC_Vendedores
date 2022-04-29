using Microsoft.AspNetCore.Mvc;
using Vendedores_MVC.Models;
using Vendedores_MVC.Models.ViewModels;
using Vendedores_MVC.Service;

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
    }
}
