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
using Vendedores_MVC.Service.Exceptions;

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

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            RegistroDeVendasFormViewModel ViewModel;
            if (id.HasValue)
            {
                ViewModel = new RegistroDeVendasFormViewModel()
                {
                    RegistroDeVenda = await _service.RetornarVendaPorI((int)id),
                    Vendedores = await _vendedorService.RetornarTodosAsync(),
                    ListStatus = Enum.GetValues(typeof(VendaStatus)).Cast<VendaStatus>().ToList()
                };
                ViewData["Title"] = "Editar Venda";
            }
            else
            {
                ViewModel = new RegistroDeVendasFormViewModel()
                {
                    Vendedores = await _vendedorService.RetornarTodosAsync(),
                    ListStatus = Enum.GetValues(typeof(VendaStatus)).Cast<VendaStatus>().ToList()
                };
                ViewData["Title"] = "Novas Vendas";
            }
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id,RegistroDeVenda RegistroDeVenda)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Error), new { mensagem = "Model Inválido" });

                if (!id.HasValue)
                {
                    await _service.CadastrarNovaVendaAsync(RegistroDeVenda);
                    TempData["AlertaSucesso"] = "Venda Cadastrada Com Sucesso :)"; 
                }
                else
                {
                    if (id != RegistroDeVenda.Id)
                        return RedirectToAction(nameof(Error), new { mensagem = "Id não conrreponde com o objeto a editar" });
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            await _service.EditarVenda(RegistroDeVenda);

                            return RedirectToAction(nameof(BuscaSimples));
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
                }
                return RedirectToAction(nameof(CreateOrEdit));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { mensagem = ex.Message }); ;
            }
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
