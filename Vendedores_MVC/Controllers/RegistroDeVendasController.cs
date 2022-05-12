using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vendedores_MVC.Models;
using Vendedores_MVC.Models.Enums;
using Vendedores_MVC.Models.ViewModels;
using Vendedores_MVC.Service;

namespace Vendedores_MVC.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendaService _service;
        private readonly VendedorService _vendedorService;

        public RegistroDeVendasController(RegistroDeVendaService service, VendedorService vendedorService)
        {
            _service = service;
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (dataInicial.HasValue)
            {
                ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
                dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            }

            if (dataFinal.HasValue)
            {
                ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            }

            var list = await _service.BuscarPorDataAsync(dataInicial, dataFinal);

            return View(list);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
                dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

            if (!dataFinal.HasValue)
                dataInicial = DateTime.Now;

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            var list = await _service.BuscarPorDataAgrupadaAsync(dataInicial, dataFinal);

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var ViewModel = new RegistroDeVendasFormViewModel()
            {
                Vendedores = await _vendedorService.RetornarTodosAsync(),
                ListStatus = Enum.GetValues(typeof(VendaStatus)).Cast<VendaStatus>().ToList()
            };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroDeVenda RegistroDeVenda)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Error), new { mensagem = "Model Inválido" });

            await _service.CadastrarNovaVendaAsync(RegistroDeVenda);
            TempData["AlertaSucesso"] = "Venda Cadastrada Com Sucesso :)";
            return RedirectToAction(nameof(Create));
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
