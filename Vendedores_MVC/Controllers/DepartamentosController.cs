using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>()
            {
                new Departamento
                {
                    Id = 1,
                    Nome = "Eletronicos"
                }
                ,
                new Departamento
                {
                    Id = 2,
                    Nome = "Fashion"
                }
            };

            return View(list);
        }
    }
}
