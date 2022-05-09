using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendedores_MVC.Service;

namespace Vendedores_MVC.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendaService _service;

        public RegistroDeVendasController(RegistroDeVendaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
                dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

            if (!dataFinal.HasValue)
                dataInicial = DateTime.Now;

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
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
    }
}
