using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {

            return View(await _service.RetornarTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            VendedorFormViewModel viewModel = new VendedorFormViewModel()
            {
                Departamentos = await _departamentoService.RetornarTodosAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                await _service.CadastrarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }

            VendedorFormViewModel viewModel = new VendedorFormViewModel() { Departamentos = await _departamentoService.RetornarTodosAsync(), Vendedor = vendedor };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não foi fornececido" }); ;

            try
            {
                await _service.DeletarAsync((int)id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Não é possivel Deletar esse vendedor, pois a vendas cadastradas a ele" }); ;
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" }); ;

            var obj = await _service.RetornarPorIdAsync((int)id);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });

            var vendedor = await _service.RetornarPorIdAsync((int)id);
            if (vendedor == null)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });

            VendedorFormViewModel obj = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = await _departamentoService.RetornarTodosAsync() };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
                return RedirectToAction(nameof(Error), new { mensagem = "Id não conrreponde com o objeto a editar" });

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AtualizarAsync(vendedor);

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

            VendedorFormViewModel obj = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = await _departamentoService.RetornarTodosAsync() };
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
