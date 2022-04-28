using Microsoft.AspNetCore.Mvc;
using Vendedores_MVC.Service;

namespace Vendedores_MVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _service;

        public VendedoresController(VendedorService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {

            return View(_service.RetornarTodos());
        }
    }
}
